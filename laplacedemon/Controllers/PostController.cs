using laplacedemon.Data;
using laplacedemon.Models;
using laplacedemon.ViewModel;
using laplacedemon.ViewModel.Login;
using Microsoft.AspNetCore.Mvc;

namespace laplacedemon.Controllers
{
    public class PostController : ControllerBase
    {
        private readonly LaPlaceDemonDataContext _context;
        public PostController(LaPlaceDemonDataContext context)
        {
            this._context = context;
        }

        [HttpPost("v1/post")]
        public async Task<IActionResult> Create([FromBody] PostViewModel newPost)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == newPost.UserId);
                if (user == null)
                    return BadRequest(new ResultViewModel<User>("Nenhum usuário foi encontrado"));

                var post = new Post {
                    Title = newPost.Title,
                    Comment = newPost.Comment,
                    Coin = newPost.Coin,
                    Date = DateTime.Now,
                    isActive = true,
                    likes = newPost.likes,
                    Author = user.Nickname,
                    User = user
                };
                _context.Posts.Add(post);
                _context.SaveChanges();
                return Ok(new ResultViewModel<Post>(post));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
