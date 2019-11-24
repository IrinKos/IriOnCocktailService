using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOMappers
{
    public class CocktailDTOMapper : IDTOServiceMapper<Cocktail, CocktailDTO>,                                              IDTOServiceMapper<CocktailDTO, Cocktail>
    {
        private readonly IDTOServiceMapper<CocktailIngredient, CocktailIngredientDTO> mapper;

        public CocktailDTOMapper(IDTOServiceMapper<CocktailIngredient, CocktailIngredientDTO> mapper)
        {
            this.mapper = mapper;
        }
        public CocktailDTO MapFrom(Cocktail entity)
        {
            return new CocktailDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                PicUrl = entity.PicUrl,
                NotAvailable = entity.NotAvailable,
                Motto = entity.Motto,
                Ingredients = entity.CocktailIngredients.Where(ingr => ingr.CocktailId == entity.Id).Select(x => this.mapper.MapFrom(x)).ToList(),
                Rating = entity.Ratings.Where(br => br.CocktailId == entity.Id).Any() ? entity.Ratings.Where(br => br.CocktailId == entity.Id).Average(g => g.Rate) : 0,
            };
        }

        public Cocktail MapFrom(CocktailDTO entity)
        {
            return new Cocktail()
            {
                Name = entity.Name,
                PicUrl=entity.PicUrl,
                Motto = entity.Motto
            };
        }
    }
}
