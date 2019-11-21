using IriOnCocktailService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOS
{
    public class Cocktail
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PicUrl { get; set; }
        public decimal Rating { get; set; }
        public List<CocktailIngredientDTO> Ingredients { get; set; }
        public bool NotAvailable { get; set; }
        public ICollection<CocktailComment> Comments { get; set; }
    }
}
