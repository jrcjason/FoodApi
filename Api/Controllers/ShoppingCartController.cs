using DataContracts;
using Api.Models;
using Utilities;
using Utilities.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api/ShoppingCart")]
    public class ShoppingCartController : ApiController
    {
        #region Properties
        #endregion

        #region Fields
        IShoppingCartModel _shoppingCartModel;
        IProductModel _productModel;
        #endregion

        #region Methods
        public ShoppingCartController(IShoppingCartModel shoppingCartModel, IProductModel productModel)
        {
            _shoppingCartModel = shoppingCartModel;
            _productModel = productModel;
        }

        [Route("GetCart")]
        [HttpPost]
        public IHttpActionResult GetCart(GetCartRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    string errorMsg = string.Empty;
                    errorMsg += string.Join(" ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                    return BadRequest(errorMsg);
                }
                return Ok(_shoppingCartModel.GetUserCart(request.UserId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("AddProductToCart")]
        [HttpPost]
        public IHttpActionResult AddProductToCart(AddProductToCartRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    string errorMsg = string.Empty;
                    errorMsg += string.Join(" ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                    return BadRequest(errorMsg);
                }

                var product = _productModel.GetProduct(request.ProductId);
                if (product == null)
                    return BadRequest(MessageResource.UnavailableProduct);

                var response = new CartTransactionResponse()
                {
                    UserCart = _shoppingCartModel.AddProductInCart(request),
                    AvailableProducts = _productModel.GetAllProducts().ToList()
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("RemoveProductInCart")]
        [HttpPost]
        public IHttpActionResult RemoveProductInCart(RemoveProductInCartRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    string errorMsg = string.Empty;
                    errorMsg += string.Join(" ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                    return BadRequest(errorMsg);
                }

                var product = _productModel.GetProduct(request.ProductId);
                if (product == null)
                    return BadRequest(MessageResource.UnavailableProduct);

                var response = new CartTransactionResponse()
                {
                    UserCart = _shoppingCartModel.RemoveProductInCart(request),
                    AvailableProducts = _productModel.GetAllProducts().ToList()
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("AddVoucher")]
        [HttpPost]
        public IHttpActionResult AddVoucher(AddVoucherRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    string errorMsg = string.Empty;
                    errorMsg += string.Join(" ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                    return BadRequest(errorMsg);
                }
                return Ok(_shoppingCartModel.AddVoucher(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
