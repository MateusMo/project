using laplacedemon.Models.PostEnvironment;

namespace laplacedemon.Models.CoinEnvironment
{
    public class Coin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public DateTimeOffset LastUpdate { get; set; }
        public ICollection<Post> Post { get; set; }
    }
}
