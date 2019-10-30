using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IriOnCocktailService.Data.Entities
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        public IdentityRole Role { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
