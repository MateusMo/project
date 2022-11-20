using laplacedemon.Models.UserEnvironment;
using laplacedemon.Models.CoinEnvironment;
namespace laplacedemon.Models.PostEnvironment
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public float SuggestedPrice { get; set; }
        public DateTimeOffset Date { get; set; }
        public bool isActive { get; set; }
        public int Bulls { get; set; }
        public int Bears { get; set; }
        public Coin Coin { get; set; }
        public User User { get; set; }
    }
}
