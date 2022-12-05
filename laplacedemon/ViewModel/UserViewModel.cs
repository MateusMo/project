using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace laplacedemon.ViewModel
{
    public class UserViewModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "O NickName é obrigatório")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Este campo deve conter entre 3 e 200 caracteres")]
        public string NickName { get; set; }

        public string Photo { get; set; }

        public bool TrustedAsAnalyst { get; set; } = false;

        public bool TrustedAsExpertAnalist { get; set; } = false;

        [Required(ErrorMessage = "O Titulo é obrigatório")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Este campo deve conter entre 3 e 200 caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "A Descrição é obrigatória")]
        [StringLength(2000, MinimumLength = 100, ErrorMessage = "Este campo deve conter entre 100 e 2000 caracteres")]
        public string Description { get; set; }

    }
}
