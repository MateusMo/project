using laplacedemon.Models.PostEnvironment;

namespace laplacedemon.Models.UserEnvironment
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public bool isBloqued { get; set; }
        public ICollection<Post>? Post { get; set; }

        public UserInfo? UserInfo { get; set; }
        public UserProfile? UserProfile { get; set; }
        public UserProfileView? UserProfileView { get; set; }
    }
}
