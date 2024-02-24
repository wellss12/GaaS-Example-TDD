namespace GaaS.Example.TDD;

public class ShoppingCart
{
    private readonly List<Product> _products = new();
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetProductCount()
    {
        return _products.Count;
    }

    public void RemoveProduct(Product product)
    {
        _products.Remove(product);
    }

    public decimal CalculateTotalPrice()
    {
        var totalPrice = 0m;
        foreach (var product in _products)
        {
            totalPrice += product.Price;
        }

        return totalPrice;
    }
}