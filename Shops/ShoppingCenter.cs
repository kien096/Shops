using System.Collections.Generic;
using Shops.Tools;

namespace Shops
{
    public class ShoppingCenter
    {
        private List<Shop> _shop;

        public ShoppingCenter()
        {
            _shop = new List<Shop>();
        }

        public bool CheckShopExistence(int shopID)
        {
            return _shop.Exists(shop => shop.ShopID == shopID);
        }

        public void AddShop(int shopID, string name, string adress)
        {
            if (!CheckShopExistence(shopID))
            {
                _shop.Add(new Shop(shopID, name, adress));
            }
            else
            {
                throw new ExistingShopIdException("Shop ID " + shopID + " already exists");
            }
        }

        public void AddShop(Shop shop)
        {
            if (!CheckShopExistence(shop.ShopID))
            {
                _shop.Add(shop);
            }
            else
            {
                throw new ExistingShopIdException("Shop ID " + shop.ShopID + " already exists");
            }
        }

        public Shop FindShopWithProductMinPrice(Product product)
        {
            int minPrice = int.MaxValue;
            var resShop = new Shop();
            foreach (Shop shop in _shop)
            {
                if (shop.TryGetProduct(product.ProductID, out ProductItem productItem) && productItem.Price < minPrice)
                {
                    minPrice = productItem.Price;
                    resShop = shop;
                }
            }

            return resShop;
        }

        public Shop FindShopWithMinTotalCostOfProducts(Dictionary<Product, int> shoppingList)
        {
            int bestTotalCost = int.MaxValue;
            Shop resShop = null;
            foreach (Shop shop in _shop)
            {
                if (shop.BuyProductsList(shoppingList, out int totalCost))
                {
                    if (totalCost < bestTotalCost)
                    {
                        bestTotalCost = totalCost;
                        resShop = shop;
                    }
                }
            }

            return resShop;
        }
    }
}
