using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Models
{
    public class CocktailViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PictureURL { get; set; }
        public decimal Rating { get; set; }
        public string Motto { get; set; }
        public List<CocktailIngredientDTO> Ingredients { get; set; }
        public bool NotAvailable { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
