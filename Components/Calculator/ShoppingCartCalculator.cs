using Components.Evaluator;
using Components.Interface;
using Components.Rule;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Components.Calculator
{
    public static class ShoppingCartCalculator
    {
        #region Properties
        #endregion

        #region Fields
        #endregion

        #region Methods
        public static void CalculateCartComputations(Cart cart)
        {
            var cartComputationsEvaluator = new CartComputationsRuleEvaluator(
                new IComputePricePerCategoryRule[]
                {
                   new BakingCookingRule(),
                   new ConfectionaryDessertsRule(),
                   new DrinksRule(),
                   new FruitsVegetablesRule(),
                   new MeatPoultryRule(),
                   new MiscellaneousItemsRule()
                });
            cartComputationsEvaluator.UpdateCartComputations(cart);
        }
        #endregion
    }
}
