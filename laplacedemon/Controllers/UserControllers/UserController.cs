using laplacedemon.Data;
using laplacedemon.Models.UserEnvironment;
using laplacedemon.ViewModel;
using laplacedemon.ViewModel.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace laplacedemon.Controllers.UserControllers
{
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet("v1/user")]
        public async Task<IActionResult> GetAll([FromServices]LaPlaceDemonDataContext _context)
        {
            try
            {
                var users = _context.Users.OrderBy(x => x.Nickname).ToList();
               
                return Ok(new ResultViewModel<List<User>>(users));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<string>("Ocorreu um erro interno no servidor"));
                throw;
            }
        }

        [HttpGet("v1/user/{id}")]
        public async Task<IActionResult> GetById([FromServices]LaPlaceDemonDataContext _context, int id)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
                if (user == null)
                    return StatusCode(500, new ResultViewModel<string>("Nenhum usuário foi encontrado"));

                return Ok(new ResultViewModel<User>(user));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<string>("Ocorreu um erro interno no servidor"));
                throw;
            }
        }

        [HttpPost("v1/user")]
        public async Task<IActionResult> Create([FromServices]LaPlaceDemonDataContext _context, [FromBody]UserViewModel userViewModel)
        {
            try
            {
                var userInfo = new UserInfo()
                {
                    Photo = userViewModel.Photo,
                };

                _context.UserInfos.Add(userInfo);

                var userProfile = new UserProfile()
                {
                    Title = userViewModel.Title,
                    Description = userViewModel.Description
                };

                _context.UserProfiles.Add(userProfile);

                var user = new User()
                {
                    Nickname = userViewModel.NickName,
                    isBloqued = false,
                    UserInfo = userInfo,
                    UserProfile = userProfile
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                return Ok(new ResultViewModel<UserViewModel>(userViewModel));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<string>("Ocorreu um erro interno no servidor"));
                throw;
            }
        }

        [HttpPut("v1/user")]
        public async Task<IActionResult> Update([FromServices]LaPlaceDemonDataContext _context, [FromBody] UserViewModel userViewModel)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userViewModel.Id);
                if (user == null)
                    return StatusCode(500, new ResultViewModel<string>("Nenhum usuário foi encontrado"));

                var userInfo = await _context.UserInfos.FirstOrDefaultAsync(x => x.Id == user.UserInfoId);
                var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(x => x.Id == user.UserProfileId);

                user.Nickname = userViewModel.NickName;
                userInfo.Photo = userViewModel.Photo;
                userProfile.Title = userViewModel.Title;
                userProfile.Description = userViewModel.Description;
                
                _context.Users.Update(user);
                _context.UserInfos.Update(userInfo);
                _context.UserProfiles.Update(userProfile);

                _context.SaveChanges();

                return Ok(new ResultViewModel<UserViewModel>(userViewModel));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<string>("Ocorreu um problema ao atualizar o usuário"));
                throw;
            }
        }

        [HttpDelete("v1/user/{id}")]
        public async Task<IActionResult> Delete([FromServices] LaPlaceDemonDataContext _context, int id)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
                if (user == null)
                    return StatusCode(500, new ResultViewModel<string>("Nenhum usuário foi encontrado"));

                _context.Remove(user);
                _context.SaveChanges();
                
                return Ok(new ResultViewModel<User>(user));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
