using System;
using System.Collections.Generic;
using System.IO;
using StoreApp.Models;

namespace StoreApp.Services

{
    public class FileService
    {
                                                                                                                                                            // File paths for different product types
        private const string FoodProductFile = "food_products.txt";
        private const string ElectronicProductFile = "electronic_products.txt";
        private const string ClothingProductFile = "clothing_products.txt";

                                                                                                                                                                         // Save products into separate files based on their type
        public void SaveProducts(List<Product> products)
        {
                                                                                                                                                                                          // Create writers for each type of product
            using (StreamWriter foodWriter = new StreamWriter(FoodProductFile))
            using (StreamWriter electronicWriter = new StreamWriter(ElectronicProductFile))
            using (StreamWriter clothingWriter = new StreamWriter(ClothingProductFile))
            {
                foreach (Product product in products)
                {
                                                                                                                                                                                      // Save each product to the corresponding file
                    if (product is FoodProduct)
                    {
                        foodWriter.WriteLine(product.ToString());
                    }
                    else if (product is ElectronicProduct)
                    {
                        electronicWriter.WriteLine(product.ToString());
                    }
                    else if (product is ClothingProduct)
                    {
                        clothingWriter.WriteLine(product.ToString());
                    }
                }
            }

            Console.WriteLine("Products saved to separate files successfully!");
        }

        // Load products from all files into a single list
        public List<Product> LoadProducts()
        {
            List<Product> products = new List<Product>();

            // Load FoodProducts
            if (File.Exists(FoodProductFile))
            {
                string[] foodLines = File.ReadAllLines(FoodProductFile);
                foreach (string line in foodLines)
                {
                    string[] parts = line.Split('|');
                    string name = parts[0];
                    decimal price = decimal.Parse(parts[1]);
                    DateTime expirationDate = DateTime.Parse(parts[2]);
                    products.Add(new FoodProduct(name, price, expirationDate));
                }
            }

            // Load ElectronicProducts
            if (File.Exists(ElectronicProductFile))
            {
                string[] electronicLines = File.ReadAllLines(ElectronicProductFile);
                foreach (string line in electronicLines)
                {
                    string[] parts = line.Split('|');
                    string name = parts[0];
                    decimal price = decimal.Parse(parts[1]);
                    int warrantyInMonths = int.Parse(parts[2]);
                    products.Add(new ElectronicProduct(name, price, warrantyInMonths));
                }
            }

            // Load ClothingProducts
            if (File.Exists(ClothingProductFile))
            {
                string[] clothingLines = File.ReadAllLines(ClothingProductFile);
                foreach (string line in clothingLines)
                {
                    string[] parts = line.Split('|');
                    string name = parts[0];
                    decimal price = decimal.Parse(parts[1]);
                    string size = parts[2];
                    products.Add(new ClothingProduct(name, price, size));
                }
            }

            Console.WriteLine("Products loaded successfully!");
            return products;
        }
    }
}