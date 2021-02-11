using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataContracts
{
    public class GetCartRequest
    {
        [Required(ErrorMessage = "UserId is required.")]
        public int UserId { get; set; }
    }
}
