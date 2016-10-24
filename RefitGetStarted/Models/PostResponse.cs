using Swashbuckle.Swagger;

namespace RefitGetStarted.Models
{
    public class PostResponse : Response
    {
        public uint Id { get; set; }

        public uint UserId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }
    }
}