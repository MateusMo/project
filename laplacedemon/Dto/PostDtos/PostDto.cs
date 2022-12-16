using laplacedemon.Models.CoinEnvironment;
using laplacedemon.Models.PostEnvironment;
using laplacedemon.Models.UserEnvironment;

namespace laplacedemon.Dto.PostDtos
{
    public class PostDto
    {
        public Post Post { get; set; }
        public User User { get; set; }
        public Coin Coin { get; set; }
    }
}
