using laplacedemon.Models.UserEnvironment;

namespace laplacedemon.Models.PostEnvironment
{
    public class PostComment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTimeOffset Date { get; set; }
        public Post? Post { get; set; }
        public User? User { get; set; }
    }
}
