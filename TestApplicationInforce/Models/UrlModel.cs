using System.ComponentModel.DataAnnotations;

namespace TestApplicationInforce.Models
{
    public class UrlModel
    {
        public int Id { get; set; }

        [Required]
        public string Link { get; set; }
        public string ShortedUrl { get; set; }
        public string Token { get; set; }
        public string Description { get; set; } = "DefaultValue";
        public DateTime Created { get; set; }

        public IList<UserUrlModel> UserUrl { get; set; }

    }
}
