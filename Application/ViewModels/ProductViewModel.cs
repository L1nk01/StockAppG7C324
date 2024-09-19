using Application.Common;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class ProductViewModel : BaseBasicEntity
    {
        [Required(ErrorMessage = "Se debe colocar el precio")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Se debe colocar la URL de la imagen")]
        public string ImagePath { get; set; }
    }
}