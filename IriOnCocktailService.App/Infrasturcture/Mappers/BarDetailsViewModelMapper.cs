using IriOnCocktailService.App.Areas.Crawler.Models;
using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class BarDetailsViewModelMapper : IViewModelMapper<BarDTO, BarDetailsViewModel>
    {
        private readonly IDTOMapper<CommentViewModel, CommentDTO> commentMapper;

        public BarDetailsViewModelMapper(IDTOMapper<CommentViewModel, CommentDTO> commentMapper)
        {
            this.commentMapper = commentMapper;
        }
        public BarDetailsViewModel MapFromDTO(BarDTO dto)
        {
            return new BarDetailsViewModel()
            {
                Id = dto.BarId,
                Address = dto.BarAddress,
                Name = dto.BarName,
                PhoneNumber=dto.BarPhoneNumber,
                PictureURL=dto.BarPicUrl,
                Rating = dto.BarRatings.Any(br => br.BarId == dto.BarId) ? dto.BarRatings.Where(br => br.BarId == dto.BarId).Average(g => g.Rate) : 0,
            };
        }

        //public BarDTO MapFromViewModel(BarDetailsViewModel viewModel)
        //{
        //    return new BarDTO()
        //    {
        //        BarId = dto.Id,
        //        BarAddress = dto.Address,
        //        BarComments
        //    };
        //}
    }
}
