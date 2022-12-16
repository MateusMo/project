using laplacedemon.Models;
using System.ComponentModel.DataAnnotations;

namespace laplacedemon.ViewModel
{
    public class PostViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O titulo é obrigatório")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Este campo deve conter entre 3 e 200 caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O comentário é obrigatório")]
        [StringLength(2000, MinimumLength = 3, ErrorMessage = "Este campo deve conter entre 3 e 2000 caracteres")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "O preço sugerido é obrigatório")]
        public float SuggestedPrice { get; set; }
        public DateTimeOffset Date { get; set; }
        public bool isActive { get; set; }
        public int CoinId { get; set; }
    }
}
