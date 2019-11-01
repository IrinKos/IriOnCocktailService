using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Areas.Magician.Models
{
    public class ChangeRoleViewModel
    {
        public string Id { get; set; }
        public string currentRole { get; set; }
        public string newRole { get; set; }
        public List<SelectListItem> allRoles { get; set; }
    }
}
