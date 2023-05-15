namespace APIproject.Entity
{
    public class Package
    {
        public Package()
        {
            PackageProduct= new List<PackageProduct>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal price { get; set; }
        public List<PackageProduct> PackageProduct { get; set; }
    }
}
