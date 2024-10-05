using StockAppG7C324.Core.Application.Common;
using System.ComponentModel.DataAnnotations;

namespace StockAppG7C324.Core.Application.ViewModels.Product
{
    public class ProductViewModel : BaseBasicEntity
    {
        [Required(ErrorMessage = "Se debe colocar el precio")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Se debe colocar la URL de la imagen")]
        public string ImagePath { get; set; }
    }
}