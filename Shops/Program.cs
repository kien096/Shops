using System;

namespace Shops
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            // creat new products
            var camera = new Product(00, "camera");
            var headphones = new Product(01, "headphones");
            var tv = new Product(02, "tv");
            var computer = new Product(03, "computer");
            var keyboard = new Product(04, "keyboard");
            var samSung = new Product(05, "Samsung");
            var iphone = new Product(06, "Iphone");
            var watch = new Product(07, "watch");
            var webcam = new Product(08, "webcam");
            var usb = new Product(09, "Usb");
            var monitor = new Product(10, "monitor");
            var clock = new Product(11, "clock");

            // creat new shops
            var mvideo = new Shop(1, "Mvideo", "spb");
            var dns = new Shop(2, "Dns", "spb");
            var bestwatch = new Shop(3, "Bestwatch", "spb");
            var citilink = new Shop(4, "Citilink", "spb");

            var sant = new ShoppingCenter();

            // add product to shop
            dns.AddProduct(tv, 50000, 10);
            mvideo.AddProduct(tv, 40000, 10);
            mvideo.DeliverProducts(tv, 40000, 9);
            citilink.AddProduct(tv, 30000, 10);
            citilink.DeliverProducts(tv, 30000, 10);

            dns.AddProduct(computer, 100000, 10);
            dns.AddProduct(monitor, 4000, 20);

            citilink.AddProduct(keyboard, 2000, 10);
            citilink.DeliverProducts(keyboard, 2000, 9);
            dns.AddProduct(keyboard, 3400, 10);

            dns.AddProduct(usb, 600, 4);
            dns.DeliverProducts(usb, 600, 5);
            mvideo.AddProduct(usb, 800, 10);

            bestwatch.AddProduct(watch, 7000, 10);
            bestwatch.AddProduct(clock, 500, 20);

            dns.AddProduct(camera, 5000, 40);
            citilink.AddProduct(camera, 7500, 10);

            mvideo.AddProduct(iphone, 54000, 15);
            dns.AddProduct(iphone, 56000, 20);

            citilink.AddProduct(webcam, 1200, 10);
            mvideo.AddProduct(webcam, 1600, 4);
            dns.AddProduct(webcam, 1400, 10);

            citilink.AddProduct(headphones, 2000, 10);
            mvideo.AddProduct(headphones, 1900, 15);

            dns.AddProduct(samSung, 31000, 20);
            mvideo.AddProduct(samSung, 29000, 20);
            citilink.AddProduct(samSung, 32000, 20);

            sant.AddShop(mvideo);
            sant.AddShop(dns);
            sant.AddShop(bestwatch);
            sant.AddShop(citilink);

            try
            {
                Console.WriteLine("Print shop have your product min price");
                Shop shop = sant.FindShopWithProductMinPrice(iphone);
                if (shop.ShopID == 1)
                {
                    Console.WriteLine("mvideo");
                }
                else if (shop.ShopID == 2)
                {
                    Console.WriteLine("dns");
                }
                else if (shop.ShopID == 3)
                {
                    Console.WriteLine("bestwatch");
                }
                else
                {
                    Console.WriteLine("Citilink");
                }
            }
            catch
            {
            }

            Console.WriteLine();
            Console.WriteLine("How much money you need to buy 2 USB in Mvideo shop");
            Console.WriteLine(mvideo.BuyProduct(usb, 2));
            Console.ReadLine();
        }
    }
}
