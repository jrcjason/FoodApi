using System;
using System.Collections.Generic;
using System.Text;

namespace DataContracts
{
    public class CartTransactionResponse
    {
        public List<Product> AvailableProducts { get; set; }
        public Cart UserCart { get; set; }
    }
}
