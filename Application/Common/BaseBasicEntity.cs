﻿using System.ComponentModel.DataAnnotations;

namespace StockAppG7C324.Core.Application.Common
{
    public class BaseBasicEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Se debe colocar el nombre")]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
