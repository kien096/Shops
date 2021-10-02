namespace Shops
{
    public class ProductItem : Product
    {
        public ProductItem(int productID, string name, int price, int amount)
            : base(productID, name)
        {
            Price = price;
            Amount = amount;
        }

        public ProductItem(Product product, int price, int amount)
            : base(product)
        {
            Price = price;
            Amount = amount;
        }

        public int Price { get; set; }

        public int Amount { get; set; }
    }
}
