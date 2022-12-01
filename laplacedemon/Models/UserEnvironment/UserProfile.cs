using laplacedemon.Models.CoinEnvironment;
using laplacedemon.Models.PostEnvironment;

namespace laplacedemon.Models.UserEnvironment
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public ICollection<Coin> PreferedCoins { get; set; }
        //public ICollection<Post> LastPost { get; set; }
        //public ICollection<UserProfileView> LastUserView { get; set; }


    }
}
