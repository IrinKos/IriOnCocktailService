using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Areas.Magician.Models
{
    public class CreateBarViewModel
    {
        public string BarId { get; set; }
        public string BarName { get; set; }
        public string BarAddress { get; set; }
        public string BarPhoneNumber { get; set; }
        public string BarPicUrl { get; set; }
        public bool BarNotAvailable { get; set; }
    }
}
