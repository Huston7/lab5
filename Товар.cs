using System;
using System.Collections.Generic;
using System.Linq;

// Інтерфейс для пошукових операцій
public interface ISearchable<T>
{
    List<T> Search(Func<T, bool> criteria);
}

// Клас Товар
public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    // Додайте інші атрибути товару, якщо потрібно
}

// Клас Користувач
public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public List<Product> PurchaseHistory { get; set; } = new List<Product>();
}

// Клас Замовлення
public class Order
{
    public List<Product> Products { get; set; } = new List<Product>();
    public int Quantity { get; set; }
    public decimal TotalPrice => Products.Sum(p => p.Price * Quantity);
    public string Status { get; set; }
}

// Клас Магазин
public class Store : ISearchable<Product>
{
    public List<User> Users { get; set; } = new List<User>();
    public List<Product> Products { get; set; } = new List<Product>();
    public List<Order> Orders { get; set; } = new List<Order>();

    public void AddUser(User user)
    {
        Users.Add(user);
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public void PlaceOrder(User user, Product product, int quantity)
    {
        Order order = new Order
        {
            Products = new List<Product> { product },
            Quantity = quantity,
            Status = "Placed"
        };

        user.PurchaseHistory.Add(product);
        Orders.Add(order);
    }

    // Реалізація інтерфейсу ISearchable
    public List<Product> Search(Func<Product, bool> criteria)
    {
        return Products.Where(criteria).ToList();
    }
}

class Товар
{
    static void Main()
    {
        // Приклад використання системи
        Store myStore = new Store();

        User user1 = new User { Username = "user1", Password = "pass1" };
        User user2 = new User { Username = "user2", Password = "pass2" };

        Product product1 = new Product { Name = "Product 1", Price = 10.99m, Category = "Category A" };
        Product product2 = new Product { Name = "Product 2", Price = 24.99m, Category = "Category B" };

        myStore.AddUser(user1);
        myStore.AddUser(user2);
        myStore.AddProduct(product1);
        myStore.AddProduct(product2);

        myStore.PlaceOrder(user1, product1, 2);

        // Приклад пошуку за критерієм ціни
        List<Product> expensiveProducts = myStore.Search(p => p.Price > 20.0m);

        // Додаткові операції та виведення результатів
    }
}

