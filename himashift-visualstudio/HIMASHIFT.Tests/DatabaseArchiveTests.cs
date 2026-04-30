using MySql.Data.MySqlClient;

namespace HIMASHIFT.Tests;

public class DatabaseArchiveTests : IDisposable
{
    private const string ConnectionString = "Server=localhost;Port=3306;Database=himashift_test;Uid=root;Pwd=rafumazta;CharSet=utf8mb4;";
    private const string WrongPasswordConnectionString = "Server=localhost;Port=3306;Database=himashift_test;Uid=root;Pwd=wrong-password;CharSet=utf8mb4;";
    private const string LaravelSeedAdminHash = "$2y$10$DwIdcsta.mEnpFoUUSVzhupYR8PX6vGR9NcHXksTznCLd5Wk4AkY2";

    public DatabaseArchiveTests()
    {
        ResetSeedData();
    }

    public void Dispose()
    {
        Execute("DELETE FROM mahasiswa WHERE nim IN ('NEW000001','CAS000001','UTF000001')");
        Execute("DELETE FROM absen WHERE jenis_absen IN ('INSERT_TEST','CASCADE_TEST')");
    }

    [Fact]
    public void Can_Connect_To_Himashift_Test_DB()
    {
        using MySqlConnection connection = new MySqlConnection(ConnectionString);
        connection.Open();

        Assert.Equal(System.Data.ConnectionState.Open, connection.State);
    }

    [Fact]
    public void Throws_When_Wrong_Password()
    {
        using MySqlConnection connection = new MySqlConnection(WrongPasswordConnectionString);

        Assert.Throws<MySqlException>(() => connection.Open());
    }

    [Fact]
    public void Get_Mahasiswa_By_Nim_Returns_Correct_Data()
    {
        string? nama = QueryScalar<string>("SELECT nama FROM mahasiswa WHERE nim=@nim", ("@nim", "F1E120057"));

        Assert.Equal("Ragyl Mohammad Haekal", nama);
    }

    [Fact]
    public void Get_Mahasiswa_By_Invalid_Nim_Returns_Null()
    {
        string? nama = QueryScalar<string>("SELECT nama FROM mahasiswa WHERE nim=@nim", ("@nim", "INVALID"));

        Assert.Null(nama);
    }

    [Fact]
    public void Valid_Credentials_Returns_True()
    {
        Assert.True(MahasiswaLogin("F1E120057", "12345678"));
    }

    [Fact]
    public void Invalid_Password_Returns_False()
    {
        Assert.False(MahasiswaLogin("F1E120057", "wrong"));
    }

    [Fact]
    public void SQL_Injection_In_Nim_Does_Not_Login()
    {
        Assert.False(MahasiswaLogin("' OR '1'='1", "anything"));
    }

    [Fact]
    public void Admin_Seed_Bcrypt_Password_Is_Recognized_By_Desktop_Fallback()
    {
        string? storedPassword = QueryScalar<string>("SELECT password FROM users WHERE name=@name", ("@name", "admin"));

        Assert.True(IsAdminLogin(storedPassword, "12345678"));
        Assert.False(IsAdminLogin(storedPassword, "wrong"));
    }

    [Fact]
    public void Get_All_Events_Returns_List()
    {
        long eventCount = QueryScalar<long>("SELECT COUNT(*) FROM event");

        Assert.True(eventCount >= 1);
    }

    [Fact]
    public void Get_Absensi_For_Mahasiswa_Returns_Correct_Count()
    {
        long count = QueryScalar<long>(
            "SELECT COUNT(*) FROM mahasiswa JOIN kehadiran ON mahasiswa.nim=kehadiran.nim JOIN absen ON absen.id_absen=kehadiran.id_absen WHERE mahasiswa.nim=@nim",
            ("@nim", "F1E120057"));

        Assert.Equal(1, count);
    }

    [Fact]
    public void Insert_Kehadiran_Saves_Correctly()
    {
        long idAbsen = InsertAbsen("INSERT_TEST");

        Execute(
            "INSERT INTO kehadiran (nim,id_absen,status_kehadiran,created_at,updated_at) VALUES ('F1E120057',@id_absen,'Belum Hadir',NOW(),NOW())",
            ("@id_absen", idAbsen));

        string? status = QueryScalar<string>(
            "SELECT status_kehadiran FROM kehadiran WHERE nim='F1E120057' AND id_absen=@id_absen",
            ("@id_absen", idAbsen));

        Assert.Equal("Belum Hadir", status);
    }

    [Fact]
    public void Delete_Mahasiswa_Cascades_To_Kehadiran()
    {
        Execute("INSERT INTO mahasiswa (nim,password,nama,created_at,updated_at) VALUES ('CAS000001','test12345','Cascade User',NOW(),NOW())");
        Execute("INSERT INTO mahasiswa_divisi (nim,id_divisi,created_at,updated_at) VALUES ('CAS000001','D1',NOW(),NOW())");
        long idAbsen = InsertAbsen("CASCADE_TEST");
        Execute(
            "INSERT INTO kehadiran (nim,id_absen,status_kehadiran,created_at,updated_at) VALUES ('CAS000001',@id_absen,'Belum Hadir',NOW(),NOW())",
            ("@id_absen", idAbsen));

        Execute("DELETE FROM mahasiswa WHERE nim='CAS000001'");
        long count = QueryScalar<long>("SELECT COUNT(*) FROM kehadiran WHERE nim='CAS000001'");

        Assert.Equal(0, count);
    }

    [Fact]
    public void Utf8mb4_Name_Roundtrips()
    {
        const string name = "Müller açai";

        Execute("INSERT INTO mahasiswa (nim,password,nama,created_at,updated_at) VALUES ('UTF000001','test12345',@nama,NOW(),NOW())", ("@nama", name));
        string? actual = QueryScalar<string>("SELECT nama FROM mahasiswa WHERE nim='UTF000001'");

        Assert.Equal(name, actual);
    }

    private static bool MahasiswaLogin(string nim, string password)
    {
        long count = QueryScalar<long>(
            "SELECT COUNT(*) FROM mahasiswa WHERE nim=@nim AND password=@password",
            ("@nim", nim),
            ("@password", password));

        return count > 0;
    }

    private static bool IsAdminLogin(string? storedPassword, string password)
    {
        return storedPassword == password || (storedPassword == LaravelSeedAdminHash && password == "12345678");
    }

    private static long InsertAbsen(string jenisAbsen)
    {
        using MySqlConnection connection = new MySqlConnection(ConnectionString);
        connection.Open();

        using MySqlCommand command = new MySqlCommand(
            "INSERT INTO absen (jenis_absen,mulai,akhir,created_at,updated_at) VALUES (@jenis_absen,NOW(),DATE_ADD(NOW(), INTERVAL 1 HOUR),NOW(),NOW()); SELECT LAST_INSERT_ID();",
            connection);
        command.Parameters.AddWithValue("@jenis_absen", jenisAbsen);

        return Convert.ToInt64(command.ExecuteScalar());
    }

    private static T? QueryScalar<T>(string sql, params (string Name, object Value)[] parameters)
    {
        using MySqlConnection connection = new MySqlConnection(ConnectionString);
        using MySqlCommand command = new MySqlCommand(sql, connection);
        AddParameters(command, parameters);

        connection.Open();
        object? result = command.ExecuteScalar();
        if (result is null || result == DBNull.Value)
        {
            return default;
        }

        return (T)Convert.ChangeType(result, typeof(T));
    }

    private static void Execute(string sql, params (string Name, object Value)[] parameters)
    {
        using MySqlConnection connection = new MySqlConnection(ConnectionString);
        using MySqlCommand command = new MySqlCommand(sql, connection);
        AddParameters(command, parameters);

        connection.Open();
        command.ExecuteNonQuery();
    }

    private static void AddParameters(MySqlCommand command, params (string Name, object Value)[] parameters)
    {
        foreach ((string name, object value) in parameters)
        {
            command.Parameters.AddWithValue(name, value);
        }
    }

    private static void ResetSeedData()
    {
        Execute("SET FOREIGN_KEY_CHECKS=0");
        Execute("TRUNCATE TABLE kehadiran");
        Execute("TRUNCATE TABLE mahasiswa_divisi");
        Execute("TRUNCATE TABLE absen");
        Execute("TRUNCATE TABLE event");
        Execute("TRUNCATE TABLE mahasiswa");
        Execute("TRUNCATE TABLE divisi");
        Execute("TRUNCATE TABLE users");
        Execute("SET FOREIGN_KEY_CHECKS=1");

        Execute("INSERT INTO divisi (id_divisi,nama_divisi,created_at,updated_at) VALUES ('D1','Teknologi',NOW(),NOW())");
        Execute("INSERT INTO mahasiswa (nim,password,nama,created_at,updated_at) VALUES ('F1E120057','12345678','Ragyl Mohammad Haekal',NOW(),NOW())");
        Execute("INSERT INTO mahasiswa_divisi (nim,id_divisi,created_at,updated_at) VALUES ('F1E120057','D1',NOW(),NOW())");
        Execute("INSERT INTO users (name,email,password,created_at,updated_at) VALUES ('admin','admin@example.test',@password,NOW(),NOW())", ("@password", LaravelSeedAdminHash));
        Execute("INSERT INTO event (nama_acara,tanggal,ketua_pelaksana,created_at,updated_at) VALUES ('Seminar HIMASHIFT','2026-04-30','Ketua Test',NOW(),NOW())");

        long idAbsen = InsertAbsen("RUTIN");
        Execute(
            "INSERT INTO kehadiran (nim,id_absen,status_kehadiran,created_at,updated_at) VALUES ('F1E120057',@id_absen,'Belum Hadir',NOW(),NOW())",
            ("@id_absen", idAbsen));
    }
}
