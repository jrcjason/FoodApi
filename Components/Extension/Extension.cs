using Components.Calculator;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Components.Extension
{
    public static class Extension
    {
        #region Methods
        public static void UpdateCartComputations(this Cart cart)
        {
            ShoppingCartCalculator.CalculateCartComputations(cart);
        }
        #endregion
    }
}
