using Components.Calculator;
using Components.Extension;
using Microsoft.ApplicationInsights.DataContracts;
using Utilities;
using Utilities.Resources;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using DataContracts;

namespace Api.Models
{
    public interface IShoppingCartModel
    {
        Cart GetUserCart(int userId);
        void UpdateUserCart(Cart updatedUserCart);
        Cart AddProductInCart(AddProductToCartRequest cartTransactionRequest);
        Cart RemoveProductInCart(RemoveProductInCartRequest cartTransactionRequest);
        Cart AddVoucher(AddVoucherRequest request);
    }

    public partial class BusinessModel : IShoppingCartModel
    {
        #region Properties
        #endregion

        #region Fields
        readonly string _cartsXmlPath = $"{AppDomain.CurrentDomain.BaseDirectory}{ConfigurationManager.AppSettings["CartsOfDifferentUsersPath"]}";
        #endregion

        #region Methods
        public void UpdateUserCart(Cart updatedUserCart)
        {
            Directory.CreateDirectory(_cartsXmlPath);
            var userCartPath = $"{_cartsXmlPath + updatedUserCart.UserId}.xml";
            XmlSerializerTool.InsertSerializedObject(userCartPath, updatedUserCart);
        }

        public Cart GetUserCart(int userId)
        {
            Directory.CreateDirectory(_cartsXmlPath);
            var userCartPath = $"{_cartsXmlPath + userId}.xml";
            if (!File.Exists(userCartPath))
            {
                throw new Exception(MessageResource.UnavailableUserCart);
            }
            return XmlSerializerTool.DeserializeObjectList<Cart>(userCartPath);
        }

        public Cart AddProductInCart(AddProductToCartRequest request)
        {
            //Decrease the products inventory
            DecreaseProductQuantity(request.ProductId, request.ProductCount);

            var product = GetProduct(request.ProductId);
            product.Count = request.ProductCount;

            Directory.CreateDirectory(_cartsXmlPath);
            var userCartPath = $"{_cartsXmlPath + request.UserId}.xml";
            Cart userCart;
            if(!File.Exists(userCartPath))
            {
                //ShoppingCart for the userNameId is not yet existing, so create a new cart and add userNameId.xml in the CartsOfDifferentUsersPath
                userCart = new Cart { UserId = request.UserId, Products = new ProductsCollection()
                                                    { Products = new List<Product>() { product } } };
            }
            else
            {
                //ShoppingCart for the userNameId is already existing.
                userCart = GetUserCart(request.UserId);
                var productInCart = userCart.Products.Products.SingleOrDefault(x => x.Id == product.Id);

                //add the product to the ProductsList if the product is not yet existing in the cart.
                //If product already exists in the cart, sum their total count.
                if (productInCart == null)
                    userCart.Products.Products.Add(product);
                else
                    productInCart.Count += product.Count;
                
            }
            userCart.UpdateCartComputations();
            UpdateUserCart(userCart);
            return GetUserCart(request.UserId);
        }

        public Cart RemoveProductInCart(RemoveProductInCartRequest request)
        {
            var userCart = GetUserCart(request.UserId);
            var productToRemove = userCart.Products.Products.SingleOrDefault(x => x.Id == request.ProductId);
            if (productToRemove == null)
                throw new Exception(MessageResource.ProductDoesNotExistInCart);

            userCart.Products.Products.Remove(productToRemove); //Remove product in the usercart.
            userCart.UpdateCartComputations();
            UpdateUserCart(userCart);
            IncreaseProductQuantity(request.ProductId, productToRemove.Count); //Increase the products available quantity in the inventory.
            return GetUserCart(request.UserId);
        }

        public Cart AddVoucher(AddVoucherRequest request)
        {
            var userCart = GetUserCart(request.UserId);
            userCart.Voucher = request.Voucher;
            userCart.UpdateCartComputations();
            UpdateUserCart(userCart);
            return userCart;
        }
        #endregion
    }
}