namespace laplacedemon.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public bool isBloqued { get; set; }
        public string base64Photo { get; set; }
        public int analist { get; set; }
        public bool isExpert { get; set; }
        public ICollection<Post> Post { get; set; }
    }
}
