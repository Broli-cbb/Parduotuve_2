using System;
using System.Collections.Generic;
using System.Linq;
using StoreApp.Models;

namespace StoreApp.Services
{
    public class ProductService
    {
        public void AddProduct(List<Product> products)
        {
            Console.WriteLine("\nChoose Product Type to Add:");
            Console.WriteLine("1. Food Product");
            Console.WriteLine("2. Electronic Product");
            Console.WriteLine("3. Clothing Product");
            Console.Write("Your choice: ");
            string choice = Console.ReadLine();

            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Invalid price. Product not added.");
                return;
            }

            switch (choice)
            {
                case "1":
                    Console.Write("Enter expiration date (yyyy-MM-dd): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime expirationDate))
                    {
                        products.Add(new FoodProduct(name, price, expirationDate));
                        Console.WriteLine("Food Product added successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid expiration date. Product not added.");
                    }
                    break;
                case "2":
                    Console.Write("Enter warranty duration in months: ");
                    if (int.TryParse(Console.ReadLine(), out int warrantyMonths))
                    {
                        products.Add(new ElectronicProduct(name, price, warrantyMonths));
                        Console.WriteLine("Electronic Product added successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid warranty duration. Product not added.");
                    }
                    break;
                case "3":
                    Console.Write("Enter size (e.g., Small, Medium, Large): ");
                    string size = Console.ReadLine();
                    products.Add(new ClothingProduct(name, price, size));
                    Console.WriteLine("Clothing Product added successfully!");
                    break;
                default:
                    Console.WriteLine("Invalid product type.");
                    break;
            }
        }

        public void BrowseProducts(List<Product> products)
        {
            Console.WriteLine("\n--- Product List ---");
            if (products.Count == 0)
            {
                Console.WriteLine("No products available.");
                return;
            }

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }

        public void SearchProductByName(List<Product> products)
        {
            Console.Write("\nEnter product name to search: ");
            string query = Console.ReadLine();

            var matches = products.Where(p => p.Name.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();

            if (matches.Count == 0)
            {
                Console.WriteLine("No matching products found.");
                return;
            }

            Console.WriteLine("\n--- Search Results ---");
            foreach (var product in matches)
            {
                Console.WriteLine(product);
            }
        }
    }
}