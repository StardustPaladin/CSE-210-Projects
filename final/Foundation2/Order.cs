using System;
using System.Collections.Generic;

class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var p in _products)
        {
            label += $"{p.GetName()} (x{p.GetQuantity()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Ship to:\n{_customer.GetName()}\n{_customer.GetAddressString()}";
    }

    public double GetTotalPrice()
    {
        double total = 0;
        foreach (var p in _products) total += p.GetTotalCost();
        if (!_customer.IsInUSA()) total += 35; // flat international fee
        return total;
    }
}
