﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Areas.Magician.Models
{
    public class AddIngredientToCocktailViewModel
    {
        public string Ingredient { get; set; }
        public string Quantity { get; set; }
        public string Unit { get; set; }
    }
}