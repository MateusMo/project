using laplacedemon.Data;
using laplacedemon.Models;
using laplacedemon.ViewModel;
using laplacedemon.ViewModel.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

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
                return StatusCode(500, new ResultViewModel<string>("Erro interno no servidor"));
            }
        }
        [HttpGet("v1/post")]
        public async Task<IActionResult> GetAllPosts()
        {
            try
            {
                var posts = _context.Posts;
                return Ok(new ResultViewModel<List<Post>>(posts.ToList()));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<string>("Erro interno no servidor"));
            }
        }

        [HttpGet("v1/post/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var post = _context.Posts.FirstOrDefault(x => x.Id == id);
                if (post == null) return NotFound();
                return Ok(new ResultViewModel<Post>(post));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<string>("Erro interno no servidor"));
            }
        }
        [HttpPut("v1/post")]
        public async Task<IActionResult> Update([FromBody] Post post)
        {
            try
            {
                var dbPost = _context.Posts.FirstOrDefault(x => x.Id == post.Id);
                if(dbPost == null) return NotFound();

                dbPost.Title = post.Title;
                dbPost.Comment = post.Comment;
                dbPost.Date = DateTime.Now;
                dbPost.Coin = post.Coin;
                dbPost.isActive = post.isActive;

                _context.Posts.Update(dbPost);
                _context.SaveChanges();

                return Ok(new ResultViewModel<Post>(dbPost));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("v1/post/delete")]
        public async Task<IActionResult> Delete([FromQuery]int id)
        {
            try
            {
                var dbPost = _context.Posts.FirstOrDefault(x => x.Id == id);
                if( dbPost == null) return NotFound();
                _context.Posts.Remove(dbPost);
                _context.SaveChanges();
                return Ok(new ResultViewModel<Post>(dbPost));
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
    
}
