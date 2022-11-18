using laplacedemon.Data;
using laplacedemon.Models;
using laplacedemon.ViewModel;
using laplacedemon.ViewModel.Result;
using Microsoft.AspNetCore.Mvc;

namespace laplacedemon.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly LaPlaceDemonDataContext _context;
        public UserController(LaPlaceDemonDataContext context)
        {
            this._context = context;
        }

        [HttpPost("v1/post")]
        public async Task<IActionResult> Create([FromBody] UserViewModel newUser)
        {
            try
            {
                var checkDoubleNickName = _context.Users.FirstOrDefault(x => x.Nickname == newUser.NickName);
                if(checkDoubleNickName == null)
                {
                    var user = new User();
                    user.Nickname = newUser.NickName;
                    user.base64Photo = "";
                    user.analist = 0;
                    user.isExpert = false;
                    user.isBloqued = false;

                    _context.Users.Add(user);
                    _context.SaveChanges();

                    return Ok(user);
                } else
                {
                    return StatusCode(500, new ResultViewModel<string>("Esse nickname já existe"));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
