using Components.Interface;
using Components.Rule;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components.Evaluator
{
    public class CartComputationsRuleEvaluator : VoucherRule
    {
        #region Properties
        #endregion

        #region Fields
        IComputePricePerCategoryRule[] _pricePerCategoryRuleList;
        #endregion

        #region Constructors
        public CartComputationsRuleEvaluator(IComputePricePerCategoryRule[] pricePerCategoryList)
        {
            _pricePerCategoryRuleList = pricePerCategoryList ?? throw new ArgumentNullException("CartTotalPriceRuleEvaluator/pricePerCategoryList");
        }
        #endregion

        #region Methods
        public void UpdateCartComputations(Cart cart)
        {
            var products = cart.Products.Products;
            cart.SubTotalPrice = 0;
            cart.TotalPrice = 0;

            if (products != null && products.Any())
            {
                foreach (var rule in _pricePerCategoryRuleList)
                {
                    //compute prices per category
                    rule.ComputePricePerCategory(cart);
                }
            }

            //Apply voucher discounts
            if (!string.IsNullOrEmpty(cart.Voucher))
                ApplyVoucherDiscount(cart);
        }
        #endregion
    }
}
