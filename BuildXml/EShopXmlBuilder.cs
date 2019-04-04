using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BuildXml
{
    class EShopXmlBuilder
    {
        private readonly string xmlFile;

        public EShopXmlBuilder(string xmlFile)
        {
            this.xmlFile = xmlFile;
        }

        public void SaveEShop(EShop eShop)
        {
            XmlDocument document = new XmlDocument();

            XmlElement root = CreateElement(document, document, "eShop");
            CreateAttribute(document, root, "shopName", eShop.ShopName);

            foreach (Order order in eShop.Orders.Values )
            {
                XmlElement xOrder = CreateElement(document, root, "order");
                CreateAttribute(document, xOrder, "IdOrder", order.IdOrder.ToString());

                CreateAttribute(document, CreateElement(document, xOrder, "Client"), "IdClient", order.IdClient.ToString());
                CreateAttribute(document, CreateElement(document, xOrder, "Product"), "IdProduct", order.IdProduct.ToString());

                CreateTextNode(document, CreateElement(document, xOrder, "DeliveryAddress"), order.DeliveryAddress);
                CreateTextNode(document, CreateElement(document, xOrder, "Registration"), order.Registration.ToString("yyyy-MM-dd"));
                CreateTextNode(document, CreateElement(document, xOrder, "DateOfDelivery"), order.DateOfDelivery.ToString("yyyy-MM-dd"));
                CreateTextNode(document, CreateElement(document, xOrder, "Price"), order.Price.ToString(CultureInfo.InvariantCulture));
            }


            document.Save(xmlFile);
        }

        private XmlText CreateTextNode(XmlDocument document, XmlElement element, string text)
        {
            XmlText xText = document.CreateTextNode(text);
            element.AppendChild(xText);
            return xText;
        }

        private XmlAttribute CreateAttribute(XmlDocument document, XmlElement element, string name, string value)
        {
            XmlAttribute attribute = document.CreateAttribute(name);
            attribute.Value = value;
            element.Attributes.Append(attribute);
            return attribute;
        }

        private XmlElement CreateElement(XmlDocument document, XmlNode parent, string name)
        {
            XmlElement element = document.CreateElement(name);
            parent.AppendChild(element);
            return element;
        }
    }
}
