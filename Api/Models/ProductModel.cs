using DataContracts;
using Utilities;
using Utilities.Resources;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public interface IProductModel
    {
        IList<Product> GetAllProducts();
        Product GetProduct(int id);
        void DecreaseProductQuantity(int productId, int countToDecrease);
        void IncreaseProductQuantity(int productId, int countToIncrease);
    }

    public partial class BusinessModel : IProductModel
    {
        #region Properties
        #endregion

        #region Fields
        string _productsXmlPath = $"{AppDomain.CurrentDomain.BaseDirectory}{ConfigurationManager.AppSettings["ProductsXmlPath"]}";
        #endregion

        #region Methods
        public IList<Product> GetAllProducts()
        {
            var products = XmlSerializerTool.DeserializeObjectList<ProductsCollection>(_productsXmlPath).Products;
            return products.Where(x=>x.Count > 0).ToList(); //return only available products that has stocks
        }

        public Product GetProduct(int id)
        {
            var getAllProducts = GetAllProducts();
            return getAllProducts.SingleOrDefault(product => product.Id == id);
        }

        public void DecreaseProductQuantity(int productId, int countToDecrease)
        {
            var products = GetAllProducts().ToList();
            var product = products.SingleOrDefault(x => x.Id == productId);

            if(product == null)
                throw new Exception(MessageResource.UnavailableProduct);

            if (product.Count < countToDecrease)
                throw new Exception(MessageResource.AddToCartWithAnOutOfStockItemError);

            product.Count -= countToDecrease;
            XmlSerializerTool.InsertSerializedObject(_productsXmlPath, products);
        }

        public void IncreaseProductQuantity(int productId, int countToIncrease)
        {
            var products = GetAllProducts().ToList();
            var product = products.SingleOrDefault(x => x.Id == productId);

            if (product == null)
                throw new Exception(MessageResource.UnavailableProduct);

            product.Count += countToIncrease;
            XmlSerializerTool.InsertSerializedObject(_productsXmlPath, products);
        }
        #endregion
    }
}