using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace DataContracts
{
    [DataContract]
    public class AddVoucherRequest
    {
        [DataMember]
        [Required(ErrorMessage = "UserId is required.")]
        public int UserId { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Voucher is required.")]
        public string Voucher { get; set; }
    }
}
