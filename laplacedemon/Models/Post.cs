using System.Reflection.Metadata.Ecma335;

namespace laplacedemon.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string Coin { get; set; }
        public DateTimeOffset Date { get; set; }
        public bool isActive { get; set; }
        public int likes { get; set; }
        public string Author { get; set; }
        public User User { get; set; }
    }
}
