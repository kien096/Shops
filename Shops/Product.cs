namespace Shops
{
    public class Product
    {
        public Product(int productId, string name)
        {
            ProductID = productId;
            Name = name;
        }

        protected Product(Product product)
        {
            ProductID = product.ProductID;
            Name = product.Name;
        }

        public int ProductID { get; set; }

        public string Name { get; set; }
    }
}
