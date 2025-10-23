using System;

class Program
{
    static void Main(string[] args)
    {
        // Customer 1 (USA)
        var addr1 = new Address("123 Main St", "Rexburg", "ID", "USA");
        var cust1 = new Customer("John Doe", addr1);
        var order1 = new Order(cust1);
        order1.AddProduct(new Product("Socks", "P001", 5.0, 3));
        order1.AddProduct(new Product("T-shirt", "P002", 12.0, 1));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total: ${order1.GetTotalPrice():0.00}\n");

        // Customer 2 (International)
        var addr2 = new Address("456 High St", "London", "Greater London", "United Kingdom");
        var cust2 = new Customer("Jane Smith", addr2);
        var order2 = new Order(cust2);
        order2.AddProduct(new Product("Notebook", "P003", 3.5, 4));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total: ${order2.GetTotalPrice():0.00}\n");
    }
}