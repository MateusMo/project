using laplacedemon.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using laplacedemon.Models;
using laplacedemon.ViewModel;

namespace laplacedemon.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LaPlaceDemonDataContext _context;
        public LoginController(LaPlaceDemonDataContext context)
        {
            this._context = context;
        }
        [HttpPost("v1/login")]
        public async Task<IActionResult> Post([FromBody] LoginViewModel LoginModel)
        {
            try
            {
                var Model = await _context.Users.FirstOrDefaultAsync(x => x.Nickname == LoginModel.NickName);
                if(Model != null)
                {
                    var User = new User();
                    User = (User)Model;
                    
                    return Ok(User);
                } else
                {
                    return BadRequest(new ResultViewModel<User>("Nenhum usuário foi encontrado"));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
