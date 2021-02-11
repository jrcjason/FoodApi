using DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Components.Rule
{
    public class VoucherRule
    {
        #region Properties
        #endregion

        #region Fields
        #endregion

        #region Constructors
        #endregion

        #region Methods
        public void Apply20OffPromo(Cart cart)
        {
            cart.TotalPrice -= 20;
        }

        public bool Is20OffPromoAllowed(Cart cart)
        {
            return cart.TotalPrice >= 100;
        }

        public void ApplyVoucherDiscount(Cart cart)
        {
            if (string.IsNullOrEmpty(cart.Voucher))
                return ;

            if (cart.Voucher.Equals("20OFFPROMO", StringComparison.OrdinalIgnoreCase) && Is20OffPromoAllowed(cart))
            {
                Apply20OffPromo(cart);
            }
            else
            {
                throw new Exception($"Either { cart.Voucher } is an invalid voucher or its not applicable.");
            }
        }
        #endregion
    }
}
