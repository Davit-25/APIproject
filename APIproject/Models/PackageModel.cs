using APIproject.Entity;

namespace APIproject.Models
{
    public class PackageModel
    {
        public PackageModel()
        {
            PackageProduct = new List<PackageProduct>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal price { get; set; }
        public List<PackageProduct> PackageProduct { get; set; }
    }
}
