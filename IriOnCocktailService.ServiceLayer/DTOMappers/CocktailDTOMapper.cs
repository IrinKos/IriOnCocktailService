using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOMappers
{
    public class CocktailDTOMapper : IDTOServiceMapper<Cocktail, CocktailDTO>
    {
        private readonly IDTOServiceMapper<CocktailIngredient, CocktailIngredientDTO> mapper;

        public CocktailDTOMapper(IDTOServiceMapper<CocktailIngredient, CocktailIngredientDTO> mapper)
        {
            this.mapper = mapper;
        }
        public CocktailDTO MapFrom(Cocktail entity)
        {
            var dto = new CocktailDTO
            {
            };
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.PicUrl = entity.PicUrl;
            dto.NotAvailable = entity.NotAvailable;
            dto.Ingredients = entity.CocktailIngredients.Where(ingr => ingr.CocktailId == entity.Id).Select(x => this.mapper.MapFrom(x)).ToList();
            if (entity.Ratings.Where(br => br.CocktailId == entity.Id).Any())
            {
                dto.Rating = entity.Ratings.Where(br => br.CocktailId == entity.Id).Average(g => g.Rate);
            }
            else
                dto.Rating = 0;

            return dto;
        }
    }
}
