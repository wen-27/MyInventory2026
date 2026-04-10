namespace MyInventory2026.src.Modules.Product.Domain.Aggregate;

using MyInventory2026.src.Modules.Product.Domain.ValueObject;

public sealed class Product
{
    public ProductId Id { get; private set; }
    public ProductName NameProduct { get; private set; }
    public CodeInv CodeInv { get; private set; }
    public ProductStockMin StockMin { get; private set; }
    public ProductStockMax StockMax { get; private set; }
    public ProductStock Stock { get; private set; }

    private Product(
        ProductId id,
        ProductName nameProduct,
        CodeInv codeInv,
        ProductStockMin stockMin,
        ProductStockMax stockMax,
        ProductStock stock)
    {
        Id = id;
        NameProduct = nameProduct;
        CodeInv = codeInv;
        StockMin = stockMin;
        StockMax = stockMax;
        Stock = stock;
    }

    public static Product Create(
        int id,
        string codeInv,
        string nameProduct,
        int stock,
        int stockMin,
        int stockMax)
    {
        return new Product(
            ProductId.Create(id),
            ProductName.Create(nameProduct),
            CodeInv.Create(codeInv),
            ProductStockMin.Create(stockMin),
            ProductStockMax.Create(stockMax),
            ProductStock.Create(stock)
        );
    }

    public void Update(
        string codeInv,
        string nameProduct,
        int stock,
        int stockMin,
        int stockMax)
    {
        CodeInv = CodeInv.Create(codeInv);
        NameProduct = ProductName.Create(nameProduct);
        Stock = ProductStock.Create(stock);
        StockMin = ProductStockMin.Create(stockMin);
        StockMax = ProductStockMax.Create(stockMax);
    }
}