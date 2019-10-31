using System.Collections.Generic;

namespace IriOnCocktailService.ServiceLayer.DTOS
{
    public class BarDTO
    {
        public string BarId { get; set; }
        public string BarName { get; set; }
        public string BarAddress { get; set; }
        public string BarPhoneNumber { get; set; }
        public string BarPicUrl { get; set; }
        public bool BarNotAvailable { get; set; }

        //public List<string> BarComments { get; set; }
        //public ICollection<Rating> BarRatings { get; set; }
        //public ICollection<CocktailBar> BarCocktails { get; set; }
    }
}