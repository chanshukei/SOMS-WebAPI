using System.ComponentModel.DataAnnotations;

namespace SOMS_WebAPI.Models
{
    public class AccessRight
    {
            
        [Key]
        public string ComponentId { get; set; }
        public string State { get; set; }
        public int IsVisible { set; get; }
        public int IsEnable { set; get; }

    }

}
