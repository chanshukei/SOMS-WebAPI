using System;
using System.ComponentModel.DataAnnotations;

namespace SOMS_WebAPI.Models
{
    public class Quotation
    {
        [Key]
        public string QuotationId { get; set; }
        public int Validity { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Description { get; set; }

      
    }
}
