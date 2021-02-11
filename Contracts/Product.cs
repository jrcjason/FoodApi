using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using DataContracts.Enums;

namespace DataContracts
{
    [XmlRoot("ArrayOfProduct")]
    public class ProductsCollection
    {
        public ProductsCollection() { Products = new List<Product>(); }
        [XmlElement("Product")]
        public List<Product> Products { get; set; }
    }

    public class Product
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Name")]
        public string ProductName { get; set; }

        [XmlElement("Category")]
        public Category Category { get; set; }

        [XmlElement("Price")]
        public decimal Price { get; set; }

        [XmlElement("CurrencyCode")]
        public string CurrencyCode { get; set; }

        [XmlElement("Count")]
        public int Count { get; set; }
    }
}
