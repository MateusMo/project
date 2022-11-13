using System.ComponentModel.DataAnnotations;

namespace laplacedemon.ViewModel.Login
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o NickName")]
        public string NickName { get; set; }
    }
}
