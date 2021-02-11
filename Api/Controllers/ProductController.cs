using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        #region Properties
        #endregion

        #region Fields
        IProductModel _productModel;
        #endregion

        #region Constructors
        public ProductController(IProductModel productModel)
        {
            _productModel = productModel;
        }
        #endregion

        #region Methods
        [Route("GetProducts")]
        public IHttpActionResult GetProducts()
        {
            try
            {
                //Connect to the source of data to get all the data.
                var products = _productModel.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
        #endregion
    }
}
