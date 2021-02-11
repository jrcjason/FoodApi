using DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Components.Rule
{
    public abstract class ProductRule
    {
        #region Properties
        #endregion

        #region Fields
        internal decimal _subTotalPrice = 0;
        internal decimal _totalPrice = 0;
        #endregion

        #region Constructors
        #endregion

        #region Methods
        public virtual void ComputeProductPrice(Product product)
        {
            _subTotalPrice = 0; _totalPrice = 0;

            _subTotalPrice = product.Price * product.Count;
            _totalPrice = _subTotalPrice;
        }
        #endregion
    }
}
