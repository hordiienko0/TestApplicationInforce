using TestApplicationInforce.Areas.Identity.Data;

namespace TestApplicationInforce.Models
{
    public class UserUrlModel 
    {
        public string UserId { get; set; }
        public TestApplicationInforceUser User { get; set; }

        public int UrlId { get; set; }
        public UrlModel Url { get; set; }
    }
}
