﻿using IriOnCocktailService.App.Areas.Crawler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Areas.Magician.Models
{
    public class BarDetailsViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PictureURL { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Rating { get; set; }
        public bool NotAvailable { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
        public IEnumerable<DisplayCocktailViewModel> Cocktails { get; set; }
    }
}