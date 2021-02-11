using DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Components.Interface
{
    public interface IComputePricePerCategoryRule
    {
        void ComputePricePerCategory(Cart cart);
    }
}
