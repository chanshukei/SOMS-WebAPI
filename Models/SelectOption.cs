using System.ComponentModel.DataAnnotations;

namespace SOMS_WebAPI.Models
{
    public class SelectOption
    {
            
        [Key]
        public string Value { get; set; }
        public string Name { get; set; }
    }

}
