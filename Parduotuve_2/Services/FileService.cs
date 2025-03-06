using System;
using System.Collections.Generic;
using System.IO;
using StoreApp.Models;

namespace StoreApp.Services
{
    public class FileService
    {
        private const string FilePath = "products.txt";

        public void SaveProducts(List<Product> products)
        {
            using (var writer = new StreamWriter(FilePath))
            {
                foreach (var product in products)
                {
                    writer.WriteLine(product.ToString());
                }
            }

            Console.WriteLine("Products saved successfully!");
        }

        public List<Product> LoadProducts()
        {
            var products = new List<Product>();

            if (!File.Exists(FilePath))
                return products;

            var lines = File.ReadAllLines(FilePath);
            foreach (var line in lines)
            {
                // Deserialization logic can go here, depending on needs
            }

            Console.WriteLine("Products loaded successfully!");
            return products;
        }
    }
}