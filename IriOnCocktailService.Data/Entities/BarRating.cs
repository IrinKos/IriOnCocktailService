using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.Data.Entities
{
    public class BarRating
    {
        public string Id { get; set; }
        public decimal Rate { get; set; }
        public bool IsDeleted { get; set; }

        public string BarId { get; set; }
        public Bar Bar { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
