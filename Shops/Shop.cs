using System.Collections.Generic;
using Shops.Tools;

namespace Shops
{
    public class Shop
    {
        private List<ProductItem> productItems;

        public Shop(int shopID, string name, string adress)
        {
            ShopID = shopID;
            Name = name;
            Ad = adress;
            productItems = new List<ProductItem>();
        }

        public Shop()
        {
            ShopID = default;
            Name = default;
            Ad = default;
            productItems = new List<ProductItem>();
        }

        public List<ProductItem> ProductItems => productItems;

        public int ShopID { get; set; } // ID shop

        public string Name { get; set; } // Name shop

        public string Ad { get; set; } // Adress

        // check product if exis
        public bool CheckProductExistence(int productID)
        {
            return productItems.Exists(product => product.ProductID == productID);
        }

        // add product
        public void AddProduct(Product product, int price, int amount = 0)
        {
            if (!CheckProductExistence(product.ProductID))
            {
                productItems.Add(new ProductItem(product, price, amount));
            }
            else
            {
                throw new ExistingProductIdException("Product ID " + product.ProductID + " already exists");
            }
        }

        public void DeliverProducts(Product product, int price, int amount)
        {
            if (!CheckProductExistence(product.ProductID))
            {
                throw new NotExistingProductIdException("Product ID " + product.ProductID + " do not exists");
            }

            int pos = productItems.FindIndex(productItem => productItem.ProductID == product.ProductID);
            productItems[pos].Price = price;
            productItems[pos].Amount += amount;
        }

        public bool TryGetProduct(int productID, out ProductItem product)
        {
            if (CheckProductExistence(productID))
            {
                product = productItems.Find(p => p.ProductID == productID);
                return true;
            }

            product = default;
            return false;
        }

        // with your money what can be bought
        public List<ProductItem> WhatProductCanBought(int moneyAmount)
        {
            var productItems = new List<ProductItem>();
            int pos = 0;
            foreach (ProductItem productItem in productItems)
            {
                int amount = 0;
                int money = moneyAmount;
                int productAmount = productItem.Amount;
                while (money >= productItem.Price && productAmount > 0)
                {
                    amount++;
                    money -= productItem.Price;
                    productAmount--;
                }

                if (amount > 0)
                {
                    productItems.Add(productItem);
                    productItems[pos].Amount = amount;
                    pos++;
                }
            }

            return productItems;
        }

        public bool BuyProduct(Product product, int amount, out int totalCost)
        {
            int pos = productItems.FindIndex(productItem => productItem.ProductID == product.ProductID);
            if (pos != -1)
            {
                if (productItems[pos].Amount < amount)
                {
                    totalCost = default;
                    return false;
                }
                else
                {
                    totalCost = amount * productItems[pos].Price;
                    return true;
                }
            }

            totalCost = default;
            return false;
        }

        public int BuyProduct(Product product, int amount)
        {
            if (!BuyProduct(product, amount, out int totalCost))
            {
                throw new UnavaliableProduct("Can not buy product " + product.ProductID + " in amount" + amount);
            }

            return totalCost;
        }

        public bool BuyProductsList(Dictionary<Product, int> shoppingList, out int total)
        {
            int resTotalCost = 0;
            foreach (KeyValuePair<Product, int> item in shoppingList)
            {
                if (!BuyProduct(item.Key, item.Value, out int totalCost))
                {
                    total = default;
                    return false;
                }

                resTotalCost += totalCost;
            }

            total = resTotalCost;
            return true;
        }
    }
}
