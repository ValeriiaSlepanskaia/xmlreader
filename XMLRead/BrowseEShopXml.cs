using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLRead
{
    class BrowseEShopXml
    {
        private XmlDocument xDoc;

        public BrowseEShopXml(string xmlFile)
        {
            xDoc = new XmlDocument();
            xDoc.Load("eshop.xml");
        }

        public EShop GetEShop()
        {
            EShop eShop = new EShop();
            XmlElement root = xDoc.DocumentElement;

            eShop.ShopName = root.Attributes.GetNamedItem("shopName").Value;

            foreach (XmlNode childnode in root.ChildNodes)
            {
                if (childnode.NodeType != XmlNodeType.Element) continue;

                Order order = new Order();
                order.IdOrder = Convert.ToInt64(childnode.Attributes["IdOrder"].Value);

                order.IdClient = Convert.ToInt64(childnode.SelectSingleNode("Client").Attributes["IdClient"].Value);
                order.IdProduct = Convert.ToInt64(childnode.SelectSingleNode("Product").Attributes["IdProduct"].Value);
                order.DeliveryAddress = childnode.SelectSingleNode("DeliveryAddress").InnerText;
                order.Registration = DateTime.Parse(childnode.SelectSingleNode("Registration").InnerText, CultureInfo.InvariantCulture);
                order.DateOfDelivery = DateTime.Parse(childnode.SelectSingleNode("DateOfDelivery").InnerText, CultureInfo.InvariantCulture);
                order.Price = Convert.ToDecimal(childnode.SelectSingleNode("Price").InnerText, CultureInfo.InvariantCulture);

                eShop.Orders.Add(order.IdOrder, order);
            }

            return eShop;
        }
    }
}
