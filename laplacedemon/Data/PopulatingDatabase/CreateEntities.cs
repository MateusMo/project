using laplacedemon.Models.CoinEnvironment;
using laplacedemon.Models.PostEnvironment;
using laplacedemon.Models.UserEnvironment;
using Microsoft.EntityFrameworkCore;

namespace laplacedemon.Data.PopulatinDatabase
{
    public class CreateEntities
    {
        private readonly LaPlaceDemonDataContext _dataContext;

        public CreateEntities(LaPlaceDemonDataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public void CreateFirstUser()
        {
            var isCreated = _dataContext.Users.FirstOrDefault(x => x.Nickname == "Mat");
            if (isCreated == null)
            {
                for(var i = 0; i <= 1000; i++)
                {
                    var userInfo = new UserInfo()
                    {
                        Photo = "",
                        TrustedAsAnalist = 0,
                        TrustedAsExpertAnalist = false,
                    };

                    var userProfile = new UserProfile()
                    {
                        Title = GenerateName(20),
                        Description = GenerateName(200)
                    };

                    var user = new User()
                    {
                        Nickname = GenerateName(10),
                        isBloqued = false,
                        UserInfo = userInfo,
                        UserProfile = userProfile
                    };
                    _dataContext.Users.Add(user);
                }
                
                _dataContext.SaveChanges();
            }
        }

        public void CreateFirstCoin()
        {
            var isCreated = _dataContext.Coins;
            if (isCreated.Count() == 0)
            {
                int i = 0;
                while (i < 20)
                {
                    var coin = new Coin();
                    coin.LastUpdate = DateTime.Now;
                    coin.Price = NextFloat(new Random());
                    coin.Name = GenerateName(10);

                    _dataContext.Coins.Add(coin);
                    _dataContext.SaveChanges();
                    i++;
                }
            }
        }

        static float NextFloat(Random random)
        {
            double mantissa = (random.NextDouble() * 2.0) - 1.0;
            // choose -149 instead of -126 to also generate subnormal floats (*)
            double exponent = Math.Pow(2.0, random.Next(0, 128));
            return (float)(mantissa * exponent);
        }

        public static string GenerateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;
        }

        public void CreatePosts()
        {
            var posts = _dataContext.Posts;
            if (posts.Count() == 0)
            {
                Random rnd = new Random();
                for (var i = 0; i <= 1000; i++)
                {
                    var random = rnd.Next(1, 25);
                    var user = _dataContext.Users.FirstOrDefault(x => x.Id == random + 1000);
                    var coin = _dataContext.Coins.FirstOrDefault(x => x.Id == random);
                    var post = new Post()
                    {
                        Title = GenerateName(10),
                        Comment = GenerateName(1000),
                        SuggestedPrice = NextFloat(new Random()),
                        Date = DateTime.Now,
                        isActive = i % 2 == 0 ? true : false,
                        Bulls = i + 10,
                        Bears = i < 2 ? i - 1 : 1,
                        User = user,
                        Coin = coin
                    };

                    _dataContext.Posts.Add(post);
                    _dataContext.SaveChanges();
                }
            }
        }
    }
}
