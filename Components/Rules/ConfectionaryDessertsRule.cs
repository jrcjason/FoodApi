using Components.Interface;
using DataContracts;
using DataContracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components.Rule
{
    public class ConfectionaryDessertsRule : ProductRule, IComputePricePerCategoryRule
    {
        #region Properties
        #endregion

        #region Fields
        #endregion

        #region Constructors
        #endregion

        #region Methods
        public void ComputePricePerCategory(Cart cart)
        {
            var products = cart.Products.Products;
            if (products == null && !products.Any())
                return;

            foreach (var product in products)
            {
                if (product.Category == Category.ConfectionaryAndDesserts)
                {
                    ComputeProductPrice(product);
                    cart.SubTotalPrice += _subTotalPrice;
                    cart.TotalPrice += _totalPrice;
                }
            }
        }
        #endregion
    }
}
