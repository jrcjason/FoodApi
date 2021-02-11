using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace DataContracts
{
    [XmlRoot("Carts")]
    public class CartsCollection
    {
        public CartsCollection() { Carts = new List<Cart>(); }
        [XmlElement("Cart")]
        public List<Cart> Carts { get; set; }
    }

    public class Cart
    {
        [XmlAttribute("UserName")]
        public int UserId { get; set; }

        [XmlElement("Products")]
        public ProductsCollection Products { get; set; }

        [XmlElement("Voucher", IsNullable = true)]
        public string Voucher { get; set; }

        [XmlElement("SubTotalPrice")]
        public decimal SubTotalPrice { get; set; }

        [XmlElement("TotalPrice")]
        public decimal TotalPrice { get; set; }
    }
}