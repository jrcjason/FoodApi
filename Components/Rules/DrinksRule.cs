using Components.Interface;
using DataContracts;
using DataContracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components.Rule
{
    public class DrinksRule : ProductRule, IComputePricePerCategoryRule
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
            if (product.Count >= 10)
                _totalPrice = _subTotalPrice - (_subTotalPrice * (decimal)0.1);
        }

        public void ComputePricePerCategory(Cart cart)
        {
            var products = cart.Products.Products;
            if (products == null && !products.Any())
                return;

            foreach (var product in products)
            {
                if (product.Category == Category.Drinks)
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
