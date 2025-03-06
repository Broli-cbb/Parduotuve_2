using System;

namespace StoreApp.Models
{
    public class FoodProduct : Product
    {
        public DateTime ExpirationDate { get; set; }

        public FoodProduct(string name, decimal price, DateTime expirationDate)
            : base(name, price)
        {
            ExpirationDate = expirationDate;
        }

        public override string ToString()
        {
            return base.ToString() + $", Expiration Date: {ExpirationDate:yyyy-MM-dd}";
        }
    }
}