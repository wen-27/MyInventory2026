using MyInventory2026.src.Shared.Helpers;

try
{
    var context = DbContextFactory.Create();

    if (context.Database.CanConnect())
    {
        Console.WriteLine("Conexión exitosa a la base de datos.");
    }
    else
    {
        Console.WriteLine("No se pudo conectar con la base de datos.");
    }
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Error al conectar con la base de datos: {ex.Message}");
    if (ex.InnerException != null)
    {
        Console.Error.WriteLine($"Detalle: {ex.InnerException.Message}");
    }
}
