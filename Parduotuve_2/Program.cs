using System;
using System.Collections.Generic;
using StoreApp.Models;
using StoreApp.Services;

namespace StoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new List<Product>();
            var productService = new ProductService();
            var fileService = new FileService();

            products = fileService.LoadProducts();

            while (true)
            {
                Console.WriteLine("\n--- Store Menu ---");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Browse Products");
                Console.WriteLine("3. Search Product by Name");
                Console.WriteLine("4. Save Products");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        productService.AddProduct(products);
                        break;
                    case "2":
                        productService.BrowseProducts(products);
                        break;
                    case "3":
                        productService.SearchProductByName(products);
                        break;
                    case "4":
                        fileService.SaveProducts(products);
                        break;
                    case "5":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}