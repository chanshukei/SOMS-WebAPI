namespace SOMS_WebAPI.Models
{
    public class AccessRight
    {
            
        public string AccessRightId { get; set; }
        public string Mode { get; set; }
        public string ComponentId { get; set; }
        public string State { get; set; }
        public int IsVisible { set; get; }
        public int IsEnable { set; get; }
    }
}
