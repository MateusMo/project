using System.ComponentModel.DataAnnotations;

namespace laplacedemon.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Este campo deve conter entre 3 e 200 caracteres")]
        public string NickName { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Este campo deve conter entre 3 e 2000 caracteres")]
        public string Password { get; set; }
    }
}
