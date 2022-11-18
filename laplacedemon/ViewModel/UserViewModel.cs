using System.ComponentModel.DataAnnotations;

namespace laplacedemon.ViewModel
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "O NickName é obrigatório")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Este campo deve conter entre 3 e 200 caracteres")]
        public string NickName { get; set; }
    }
}
