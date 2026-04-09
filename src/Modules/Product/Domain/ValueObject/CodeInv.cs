namespace MyInventory2026.src.Modules.Product.Domain.ValueObject;

public sealed record CodeInv 
{
    public string Value { get;}

    private CodeInv(string value)
    {
        Value = value;
    }

    public static CodeInv Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("El código de inventario no puede estar vacío.", nameof(value));
        }
        if (value.Length > 10)
        {
            throw new ArgumentException("El código de inventario debe tener como máximo 10 caracteres.", nameof(value));
        }
        return new CodeInv(value);
    }
    public override string ToString() => Value;
}