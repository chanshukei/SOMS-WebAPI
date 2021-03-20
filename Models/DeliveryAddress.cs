using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOMS_WebAPI.Models
{
    public class DeliveryAddress
    {
        [Key]
        public string AddressId { get; set; }
        public string Address { get; set; }
      
    }
}
