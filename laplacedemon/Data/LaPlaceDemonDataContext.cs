using laplacedemon.Data.Mappings.CoinMappings;
using laplacedemon.Data.Mappings.UserMappings;
using laplacedemon.Data.Mappings.PostMappings;
using laplacedemon.Models.UserEnvironment;
using laplacedemon.Models.PostEnvironment;
using laplacedemon.Models.CoinEnvironment;
using Microsoft.EntityFrameworkCore;

namespace laplacedemon.Data
{
    public class LaPlaceDemonDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserProfileView> UserProfileViews { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<Coin> Coins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=localhost,1433;Database=project;User ID=sa;Password=1q2w3e4r@#$");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //user
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new UserInfoMap());
            modelBuilder.ApplyConfiguration(new UserProfileMap());
            modelBuilder.ApplyConfiguration(new UserProfileViewMap());
            
            //post
            modelBuilder.ApplyConfiguration(new PostMap());
            modelBuilder.ApplyConfiguration(new PostCommentMap());

            //coin
            modelBuilder.ApplyConfiguration(new CoinMap());
        }
    }
}
