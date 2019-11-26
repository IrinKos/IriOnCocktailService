using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOS
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string CurrentRole { get; set; }
        public string NewRole { get; set; }
    }
}
