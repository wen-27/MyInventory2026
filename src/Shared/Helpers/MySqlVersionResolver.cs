using System;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using MyInventory2026.src.Shared.Context;
using MySqlConnector; 


namespace MyInventory2026.src.Shared.Helpers;

public class MySqlVersionResolver
{
    public static Version DetectVersion(string connectionString)
    {
        using var conn = new MySqlConnection(connectionString);
        conn.Open();
        var raw = conn.ServerVersion;
        var clean = raw.Split('-')[0];
        return Version.Parse(clean);
    }
}
