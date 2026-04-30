namespace HIMASHIFT.UserControls
{
    partial class anggota
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tabel = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)tabel).BeginInit();
            SuspendLayout();
            // 
            // tabel
            // 
            tabel.AllowUserToAddRows = false;
            tabel.AllowUserToDeleteRows = false;
            tabel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabel.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.Font = new Font("Inter", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.Highlight;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            tabel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            tabel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Inter", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            tabel.DefaultCellStyle = dataGridViewCellStyle2;
            tabel.Location = new Point(47, 49);
            tabel.Name = "tabel";
            tabel.ReadOnly = true;
            tabel.RowTemplate.Height = 25;
            tabel.Size = new Size(971, 522);
            tabel.TabIndex = 4;
            tabel.CellContentClick += tabel_CellContentClick;
            // 
            // anggota
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(tabel);
            Name = "anggota";
            Size = new Size(1064, 620);
            ((System.ComponentModel.ISupportInitialize)tabel).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView tabel;
    }
}
