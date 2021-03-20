using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SOMS_WebAPI.Models
{
    public class HashTag
    {
        [Key]
        public string Text { get; set; }
      
    }
}
