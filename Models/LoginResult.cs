using System.ComponentModel.DataAnnotations;

namespace SOMS_WebAPI.Models
{
    public class LoginResult
    {
        [Key]
        public string UserId { get; set; }
        public int Result { get; set; }
    }
}
