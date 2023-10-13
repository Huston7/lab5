#include <iostream>
#include <string>
#include <vector>

// Клас "Товар"
using static System.Formats.Asn1.AsnWriter;
using System.Diagnostics;
using System.Xml.Linq;

class Product
{
    public:
    std::string name;
    double price;
    std::string description;
    std::string category;
    // Додаткові характеристики товару, наприклад, рейтинг

    Product(const std::string& name, double price, const std::string& description, const std::string& category)
        : name(name), price(price), description(description), category(category) { }
};

// Клас "Користувач"
class User
{
    public:
    std::string username;
    std::string password;
    std::vector<Product> purchaseHistory;

    User(const std::string& username, const std::string& password)
        : username(username), password(password) { }
};

// Клас "Замовлення"
class Order
{
    public:
    std::vector<Product> products;
    int quantity;
    double totalCost;
    std::string status;

    Order(const std::vector<Product>& products, int quantity)
        : products(products), quantity(quantity), totalCost(0), status("Processing")
    {
        for (const Product&product : products) {
            totalCost += product.price * quantity;
        }
    }
};

// Інтерфейс "Пошуковий"
class ISearchable
{
    public:
    virtual std::vector<Product> searchByPrice(double minPrice, double maxPrice) = 0;
    virtual std::vector<Product> searchByCategory(const std::string& category) = 0;
    virtual std::vector<Product> searchByRating(int minRating) = 0;
};

// Клас "Магазин"
class Store : public ISearchable
{
public:
    std::vector<Product> products;
std::vector<User> users;
std::vector<Order> orders;

Store() {
    // Ініціалізація товарів, користувачів та замовлень
    // products.push_back(Product(...));
    // users.push_back(User(...));
    // orders.push_back(Order(...));
}

std::vector<Product> searchByPrice(double minPrice, double maxPrice) override
{
    std::vector<Product> result;
    for (const Product&product : products) {
        if (product.price >= minPrice && product.price <= maxPrice)
        {
            result.push_back(product);
        }
    }
    return result;
}

std::vector<Product> searchByCategory(const std::string& category) override
{
    std::vector<Product> result;
    for (const Product&product : products) {
        if (product.category == category)
        {
            result.push_back(product);
        }
    }
    return result;
}

std::vector<Product> searchByRating(int minRating) override
{
    std::vector<Product> result;
    // Додайте пошук за рейтингом
    return result;
}

    // Додайте методи для управління користувачами та замовленнями
};

int main()
{
    Store store; // Створення магазину

    // Робота з магазином
    // Наприклад, пошук товарів
    std::vector<Product> foundProducts = store.searchByPrice(10.0, 50.0);

    // Додавання користувача
    User newUser("username", "password");
store.users.push_back(newUser);

// Оформлення замовлення
std::vector<Product> selectedProducts = { store.products[0], store.products[1] };
Order newOrder(selectedProducts, 2);
store.orders.push_back(newOrder);

return 0;
}
