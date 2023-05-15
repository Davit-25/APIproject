using FsCheck;

namespace APIproject.Entity
{
    public class Product
    {
        public int ID { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal price { get; set; }
        public Category category { get; set; }


    }
}
