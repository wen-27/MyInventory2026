using System;

namespace MyInventory2026.src.Modules.Product.Domain.ValueObject;

public sealed record ProductName 
{
    public string Value { get;}

    private ProductName(string value)
    {
        Value = value;
    }

    public static ProductName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("El nombre del producto no puede estar vacío.", nameof(value));
        }  
        if (value.Length > 50)
        {
            throw new ArgumentException("El nombre del producto debe tener como máximo 50 caracteres.", nameof(value));
        }
        return new ProductName(value);
    }
    public override string ToString() => Value;
}