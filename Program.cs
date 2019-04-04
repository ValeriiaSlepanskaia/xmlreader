using System;

namespace XMLRead
{
    class Program
    {
        static void Main(string[] args)
        {
            BrowseEShopXml eShopXml = new BrowseEShopXml("eshop.xml");
            EShop eShop = eShopXml.GetEShop();

            Console.WriteLine("Результаты считывания документа:");
            Console.WriteLine();

            Console.WriteLine(eShop.ToString());
            Console.ReadLine();
        }
    }
}
