using laplacedemon.Data;
using laplacedemon.ViewModel;
using laplacedemon.ViewModel.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace laplacedemon.Controllers.AccessControllers
{
    public class LoginController : ControllerBase
    {
        public async Task<IActionResult> Login([FromBody]LaPlaceDemonDataContext _context,LoginViewModel login)
        {
            try
            {
                var exists = await _context.Users
                .FirstOrDefaultAsync(x => x.Nickname == login.NickName && x.Password == x.Password);

                if (exists == null)
                    return StatusCode(500, new ResultViewModel<string>("Nenhum usuário foi encontrado"));

                    return Ok(new ResultViewModel<LoginViewModel>(login));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<string>("Nenhum usuário foi encontrado"));
                throw;
            }
            
        }
    }
}
