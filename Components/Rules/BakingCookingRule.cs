using Components.Interface;
using DataContracts;
using DataContracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components.Rule
{
    public class BakingCookingRule : ProductRule, IComputePricePerCategoryRule
    {
        #region Properties
        #endregion

        #region Fields
        #endregion

        #region Constructors
        #endregion

        #region Methods
        public override void ComputeProductPrice(Product product)
        {
            _subTotalPrice = 0; _totalPrice = 0;

            _subTotalPrice = product.Price * product.Count;
            if (_subTotalPrice >= 50)
                _totalPrice -= 5;
        }

        public void ComputePricePerCategory(Cart cart)
        {
            var products = cart.Products.Products;
            if (products == null && !products.Any())
                return;

            foreach (var product in products)
            {
                if (product.Category == Category.BakingCookingIngredients)
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
