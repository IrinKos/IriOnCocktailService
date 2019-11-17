using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Models
{
    public class BarViewModel
    {
        public string Id    { get; set; }
        public string Name { get; set; }
        public string PictureURL { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Rating { get; set; }
        public bool NotAvailable { get; set; }
    }
}
