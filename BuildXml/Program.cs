using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildXml
{
    class Program
    {
        static void Main(string[] args)
        {
            EShop shop = new EShop();
            shop.ShopName = "eShop";

            Order order1 = new Order()
            {
                IdOrder = 1,
                IdClient = 5,
                IdProduct = 9,
                DeliveryAddress = "Ukraine,Kharkiv,Metrostroiteley 5, 58",
                Registration = DateTime.Parse("2015-10-18", CultureInfo.InvariantCulture),
                DateOfDelivery = DateTime.Parse("2015-12-05", CultureInfo.InvariantCulture),
                Price = 1000.0m
            };

            Order order2 = new Order()
            {
                IdOrder = 2,
                IdClient = 3,
                IdProduct = 4,
                DeliveryAddress = "Ukraine,Kharkiv,Les Serduik 14, 96",
                Registration = DateTime.Parse("2015-10-18", CultureInfo.InvariantCulture),
                DateOfDelivery = DateTime.Parse("2015-12-05", CultureInfo.InvariantCulture),
                Price = 3000.0m
            };

            shop.Orders.Add(order1.IdOrder, order1);
            shop.Orders.Add(order2.IdOrder, order2);

            EShopXmlBuilder builder = new EShopXmlBuilder("built-eshop.xml");
            builder.SaveEShop(shop);

            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}
