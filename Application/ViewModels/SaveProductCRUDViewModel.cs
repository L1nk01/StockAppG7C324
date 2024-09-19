using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class SaveProductCRUDViewModel : ProductViewModel
    {
        [Required(ErrorMessage = "Se debe seleccionar una categoría")]
        public int CategoryId { get; set; } // FK
    }
}