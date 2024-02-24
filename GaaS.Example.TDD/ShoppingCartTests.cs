using FluentAssertions;

namespace GaaS.Example.TDD;

public class ShoppingCartTests
{
    private ShoppingCart _shoppingCart;

    [Test]
    public void AddProductToCart()
    {
        // Arrange
        var cart = new ShoppingCart();
        var apple = new Product("Apple", 10m);

        // Act
        cart.AddProduct(apple);

        // Assert
        cart.GetProductCount().Should().Be(1);
    }

    [Test]
    public void RemoveProductToCart()
    {
        // Arrange
        var cart = new ShoppingCart();
        var apple = new Product("Apple", 10m);
        cart.AddProduct(apple);

        // Act
        cart.RemoveProduct(apple);

        // Assert
        cart.GetProductCount().Should().Be(0);
    }

    [Test]
    public void CalculateTotalPriceFromShoppingCart()
    {
        GivenShoppingCart(CreateProduct("Apple", 10m), CreateProduct("Banana", 30m));

        var totalPrice = _shoppingCart.CalculateTotalPrice();

        totalPrice.Should().Be(40m);
    }

    private void GivenShoppingCart(params Product[] products)
    {
        _shoppingCart = new ShoppingCart();
        foreach (var product in products)
        {
            _shoppingCart.AddProduct(product);
        }
    }

    private static Product CreateProduct(string name, decimal price)
    {
        return new Product(name, price);
    }
}