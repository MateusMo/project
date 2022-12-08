using laplacedemon.Data;
using laplacedemon.Models.DataModel;
using laplacedemon.Models.PostEnvironment;
using laplacedemon.ViewModel.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
               .Skip((pageDataModel.PageNumber - 1) * 10)
               .Take(pageDataModel.PageSize)
               .ToListAsync();

                if (posts == null)
                    return StatusCode(500, new ResultViewModel<string>("Não há posts"));

                return Ok(new ResultViewModel<List<Post>>(posts));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
