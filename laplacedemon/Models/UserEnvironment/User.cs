using laplacedemon.Models.PostEnvironment;

namespace laplacedemon.Models.UserEnvironment
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public bool isBloqued { get; set; }
        public ICollection<Post> Post { get; set; }
    }
}
