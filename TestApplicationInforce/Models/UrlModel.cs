using TestApplicationInforce.Areas.Identity.Data;

namespace TestApplicationInforce.Models
{
    public class UrlModel
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Token { get; set; }
        public int Clicked { get; set; }
        public DateTime Created { get; set; }

        public IList<UserUrlModel> UserUrl { get; set; }

    }
}
