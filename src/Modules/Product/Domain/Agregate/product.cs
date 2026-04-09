using MyInventory2026.src.Modules.Product.Domain.ValueObject;

namespace MyInventory2026.src.Modules.Product.Domain.Agregate;

public sealed class Product
{
    public ProductId Id { get; private set; }
    public ProductName nameProduct { get; private set; }
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
        ProductStock stock  )
        {
            Id = id;
            NameProduct = nameProduct;
            CodeInv = codeInv;
            StockMin = stockMin;
            StockMax = stockMax;
            Stock = stock;
        }
    public static Product Create(
        ProductId id,
        ProductName nameProduct,
        CodeInv codeInv,
        ProductStockMin stockMin,
        ProductStockMax stockMax,
        ProductStock stock  )
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
        int stockMin,
        int stockMax,
        int stock,
        string nameProduct
    )
    {
        CodeInv = ProductCodeInv.Create(codeInv);
        StockMin = ProductStockMin.Create(stockMin);
        StockMax = ProductStockMax.Create(stockMax);
        Stock = ProductStock.Create(stock);
        nameProduct = ProductName.Create(nameProduct);
    }
}