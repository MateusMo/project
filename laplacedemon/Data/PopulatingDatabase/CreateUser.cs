using laplacedemon.Models;
namespace laplacedemon.Data.PopulatinDatabase
{
    public class CreateUser
    {
        private readonly LaPlaceDemonDataContext _dataContext;

        public CreateUser(LaPlaceDemonDataContext dataContext)
        {
            this._dataContext = dataContext; 
        }

        public void CreateFirstUser()
        {
            var isCreated = _dataContext.Users.FirstOrDefault(x => x.Nickname == "Mat");
            if(isCreated == null)
            {
                var user = new User();
                user.Nickname = "Mat";
                user.isBloqued = false;
                user.base64Photo = "";
                user.Post = null;
                _dataContext.Users.Add(user);
                _dataContext.SaveChanges();
            }
        }
    }
}
