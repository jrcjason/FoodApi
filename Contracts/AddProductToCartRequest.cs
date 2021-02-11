using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataContracts
{
    public class AddProductToCartRequest
    {
        [Required(ErrorMessage = "UserId is required.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "ProductId is required.")]
        public int ProductId{ get; set; }

        [Required(ErrorMessage = "ProductCount is required.")]
        public int ProductCount { get; set; }
    }
}
