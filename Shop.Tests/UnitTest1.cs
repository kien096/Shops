using NUnit.Framework;
using Shops;
using System.Collections.Generic;


namespace ShopTest
{
    public class Tests
    {

        Product camera = new Product(00, "camera");
        Product headphones = new Product(01, "headphones");
        Product tv = new Product(02, "tv");
        Product computer = new Product(03, "computer");
        Product keyboard = new Product(04, "keyboard");
        Product SamSung = new Product(05, "Samsung");
        Product Iphone = new Product(06, "Iphone");
        Product watch = new Product(07, "watch");
        Product webcam = new Product(08, "webcam");
        Product Usb = new Product(09, "Usb");
        Product monitor = new Product(10, "monitor");
        Product clock = new Product(11, "clock");

        Shop Mvideo = new Shop(1, "Mvideo", "spb");
        Shop Dns = new Shop(2, "Dns", "spb");
        Shop Bestwatch = new Shop(3, "Bestwatch", "spb");
        Shop Citilink = new Shop(4, "Citilink", "spb");

        ShoppingCenter sc = new ShoppingCenter();

        public Tests()
        {
            Dns.AddProduct(tv, 50000, 10);
            Mvideo.AddProduct(tv, 40000, 10);
            Mvideo.DeliverProducts(tv, 40000, 9);
            Citilink.AddProduct(tv, 30000, 10);
            Citilink.DeliverProducts(tv, 30000, 10);

            Dns.AddProduct(computer, 100000, 10);
            Dns.AddProduct(monitor, 4000, 20);


            Citilink.AddProduct(keyboard, 2000, 10);
            Citilink.DeliverProducts(keyboard, 2000, 9);
            Dns.AddProduct(keyboard, 3400, 10);

            Dns.AddProduct(Usb, 600, 4);
            Dns.DeliverProducts(Usb, 600, 5);
            Mvideo.AddProduct(Usb, 800, 10);


            Bestwatch.AddProduct(watch, 7000, 10);
            Bestwatch.AddProduct(clock, 500, 20);

            Dns.AddProduct(camera, 5000, 40);
            Citilink.AddProduct(camera, 7500, 10);

            Mvideo.AddProduct(Iphone, 54000, 15);
            Dns.AddProduct(Iphone, 56000, 20);

            Citilink.AddProduct(webcam, 1200, 10);
            Mvideo.AddProduct(webcam, 1600, 4);
            Dns.AddProduct(webcam, 1400, 10);

            Citilink.AddProduct(headphones, 2000, 10);
            Mvideo.AddProduct(headphones, 1900, 15);

            Dns.AddProduct(SamSung, 31000, 20);
            Mvideo.AddProduct(SamSung, 29000, 20);
            Citilink.AddProduct(SamSung, 32000, 20);

            sc.AddShop(Mvideo);
            sc.AddShop(Dns);
            sc.AddShop(Bestwatch);
            sc.AddShop(Citilink);
        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestFindShopWithProductMinPrice()
        {
            Assert.AreEqual(4, sc.FindShopWithProductMinPrice(tv).ShopID);
            Assert.AreEqual(2, sc.FindShopWithProductMinPrice(Usb).ShopID);
            Assert.AreEqual(4, sc.FindShopWithProductMinPrice(keyboard).ShopID);
        }

        [Test]
        public void TestBuyProduct()
        {
            Assert.AreEqual(300000, Dns.BuyProduct(computer, 3));
            Assert.AreEqual(15000, Dns.BuyProduct(camera, 3));
        }

        [Test]
        public void TestFindShopWithMinTotalCostOfProducts()
        {
            var shoppingList1 = new Dictionary<Product, int>()
            {
                [computer] = 2,
                [monitor] = 2
            };
            var shoppingList2 = new Dictionary<Product, int>()
            {
                [headphones] = 1,
                [Iphone] = 1
            };
            var shoppingList3 = new Dictionary<Product, int>()
            {
                [watch] = 3,
                [clock] = 3
            };
            Assert.AreEqual(2, sc.FindShopWithMinTotalCostOfProducts(shoppingList1).ShopID);
            Assert.AreEqual(1, sc.FindShopWithMinTotalCostOfProducts(shoppingList2).ShopID);
            Assert.AreEqual(3, sc.FindShopWithMinTotalCostOfProducts(shoppingList3).ShopID);
        }

        private bool CompareLists(List<ProductItem> list1, List<ProductItem> list2)
        {
            foreach (var productItem in list1)
            {
                int pos = list1.FindIndex(product =>
                    productItem.ProductID == product.ProductID && productItem.Amount == product.Amount);
                if (pos == -1)
                {
                    return false;
                }
            }

            return true;
        }


        [Test]
        public void TestWhatProductCanBought()
        {
            var list1 = new List<ProductItem>
                     {
                         new ProductItem(Usb, 4000, 2),
                         new ProductItem(camera, 5000, 2),
                         new ProductItem(monitor, 8000, 1),
                         new ProductItem(SamSung, 29000, 1)
                     };
            var list2 = Citilink.WhatProductCanBought(35000);
            Assert.AreEqual(true, CompareLists(list1, list2));
        }
    }
}