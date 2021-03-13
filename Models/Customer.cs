using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SOMS_WebAPI.Models
{
    public class Customer
    {
        [Key]
        public string CustomerNo { get; set; }
        public string EnglishName { get;set; }
      
    }
}
