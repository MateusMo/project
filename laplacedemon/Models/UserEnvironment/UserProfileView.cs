namespace laplacedemon.Models.UserEnvironment
{
    public class UserProfileView
    {
        public int Id { get; set; }
        public int UserVisitorId { get; set; }
        public User User { get; set; }
        public DateTimeOffset ViewDate { get; set; }
    }
}
