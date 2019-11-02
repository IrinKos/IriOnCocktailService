﻿using System.Collections.Generic;

namespace IriOnCocktailService.Data.Entities
{
    public class Bar
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string PicUrl { get; set; }
        public bool NotAvailable { get; set; } 

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<CocktailBar> CocktailBars { get; set; }
    }
}