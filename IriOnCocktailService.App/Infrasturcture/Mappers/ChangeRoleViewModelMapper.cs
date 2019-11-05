using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class ChangeRoleViewModelMapper : IViewModelMapper<UserDTO, ChangeRoleViewModel>,
                                             IDTOMapper<ChangeRoleViewModel,UserDTO>
    {
        public ChangeRoleViewModel MapFromDTO(UserDTO dto)
        {
            throw new NotImplementedException();
        }

        public UserDTO MapFromViewModel(ChangeRoleViewModel viewModel)
        {
            return new UserDTO()
            {
                Id=viewModel.Id,
                CurrentRole=viewModel.currentRole,
                NewRole=viewModel.newRole
            };
        }
    }
}
