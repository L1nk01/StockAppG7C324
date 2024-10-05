using System.ComponentModel.DataAnnotations;

namespace StockAppG7C324.Core.Application.ViewModels.Product
{
    public class SaveProductCRUDViewModel : ProductViewModel
    {
        [Required(ErrorMessage = "Se debe seleccionar una categoría")]
        public int CategoryId { get; set; } // FK
    }
}