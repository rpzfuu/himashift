<?php

namespace Tests\Feature;

use Tests\TestCase;

class ExampleTest extends TestCase
{
    public function test_guest_can_view_login_page(): void
    {
        $response = $this->get('/');

        $response->assertStatus(200);
    }
}
