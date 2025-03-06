namespace StoreApp.Models
{
    public class ClothingProduct : Product
    {
        public string Size { get; set; }

        public ClothingProduct(string name, decimal price, string size)
            : base(name, price)
        {
            Size = size;
        }

        public override string ToString()
        {
            return base.ToString() + $", Size: {Size}";
        }
    }
}