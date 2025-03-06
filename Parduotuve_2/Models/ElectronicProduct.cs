namespace StoreApp.Models
{
    public class ElectronicProduct : Product
    {
        public int WarrantyMonths { get; set; }

        public ElectronicProduct(string name, decimal price, int warrantyMonths)
            : base(name, price)
        {
            WarrantyMonths = warrantyMonths;
        }

        public override string ToString()
        {
            return base.ToString() + $", Warranty: {WarrantyMonths} months";
        }
    }
}