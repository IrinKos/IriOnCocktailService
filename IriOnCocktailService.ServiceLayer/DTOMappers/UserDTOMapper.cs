using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOMappers
{
    public class UserDTOMapper : IDTOServiceMapper<User, UserDTO>
    {
        public UserDTO MapFrom(User entity)
        {
            return new UserDTO()
            {

            };
        }
    }
}
