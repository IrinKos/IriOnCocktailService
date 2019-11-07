using IriOnCocktailService.App.Areas.Crawler.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers.Registration
{
    public class ListBarViewModelMapper : IViewModelMapper<BarDTO, ListBarsViewModel>
    {
        public ListBarsViewModel MapFromDTO(BarDTO dto)
        {
            return new ListBarsViewModel()
            {
                BarId = dto.BarId,
                BarName=dto.BarName,
                BarPicUrl=dto.BarPicUrl,
                BarNotAvailable=dto.BarNotAvailable,
                BarRating=(double)dto.BarRatings.Where(br=>br.BarId==dto.BarId).Average(br=>br.Rate)
            };
        }
    }
}
