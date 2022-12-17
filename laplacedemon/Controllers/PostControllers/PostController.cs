using laplacedemon.Data;
using laplacedemon.Dto.PostDtos;
using laplacedemon.Models.DataModel;
using laplacedemon.Models.PostEnvironment;
using laplacedemon.Models.UserEnvironment;
using laplacedemon.ViewModel;
using laplacedemon.ViewModel.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace laplacedemon.Controllers.UserControllers
{
    [ApiController]
    public class PostController : ControllerBase
    {
        [HttpGet("v1/post/{page}")]
        public async Task<IActionResult> GetPosts([FromServices]LaPlaceDemonDataContext _context, int page)
        {
            try
            {
                var pageDataModel = new Page(page);
                
                var posts = await _context.Posts
               .Skip((pageDataModel.PageNumber - 1) * pageDataModel.PageSize)
               .Take(pageDataModel.PageSize)
               .ToListAsync();

                if (posts == null)
                    return StatusCode(500, new ResultViewModel<string>("Não há posts"));
                
                var postsDtoList = new List<PostDto>();
                
                foreach(var post in posts)
                {
                    var postDto = new PostDto();
                    postDto.Post = post;
                    postDto.User = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == post.UserId);
                    postDto.Coin = await _context.Coins.AsNoTracking().FirstOrDefaultAsync(x => x.Id == post.CoinId);

                    if(postDto.Post != null && postDto.User != null && postDto.Coin != null )
                    {
                        postsDtoList.Add(postDto);
                    }
                }

                return Ok(new ResultViewModel<List<PostDto>>(postsDtoList));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<string>("Ocorreu um erro interno no servidor"));
                throw;
            }
        }

        [HttpGet("v1/postById/{id}")]
        public async Task<IActionResult> GetPostById([FromServices]LaPlaceDemonDataContext _context, int id)
        {
            try
            {
                var post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);

                if (post == null)
                    return StatusCode(500, "Nenhum post foi encontrado");

                var postDto = new PostDto();
                postDto.Post = post;
                postDto.User = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == post.UserId);
                postDto.Coin = await _context.Coins.AsNoTracking().FirstOrDefaultAsync(x => x.Id == post.CoinId);

                return Ok(new ResultViewModel<PostDto>(postDto));
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro no servidor");
                throw;
            }
        }

        [HttpPut("v1/post")]
        public async Task<IActionResult> Update([FromServices]LaPlaceDemonDataContext _context,PostViewModel post)
        {
            try
            {
                var dbPost = await _context.Posts.FirstOrDefaultAsync(x => x.Id == post.Id);
                if (dbPost == null)
                    return StatusCode(500, new ResultViewModel<string>("Nenhum post foi encontrado"));

                dbPost.Title = post.Title;
                dbPost.Comment = post.Comment;
                dbPost.SuggestedPrice = post.SuggestedPrice;
                dbPost.CoinId = post.CoinId;

                _context.Posts.Update(dbPost);
                _context.SaveChanges();

                return Ok(new ResultViewModel<Post>(dbPost));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<string>("Ocorreu um erro interno no servidor"));
                throw;
            }
        }

        [HttpDelete("v1/post/{id}")]
        public async Task<IActionResult> Delete([FromServices]LaPlaceDemonDataContext _context,int id)
        {
            try
            {
                var post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);
                if (post == null)
                    return StatusCode(500, new ResultViewModel<string>("Nenhum post foi encontrado"));
                _context.Remove(post);
                _context.SaveChanges();

                return Ok(new ResultViewModel<Post>(post));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<string>("Ocorreu um erro interno no servidor"));
                throw;
            }
        }
    }
}
