using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOMappers.Registration
{
    public static class MapperRegistration
    {
        public static IServiceCollection AddCustomDTOMappers(this IServiceCollection services)
        {


            services.AddScoped<IDTOServiceMapper<Bar, BarDTO>, BarDTOMapper>();
            services.AddScoped<IDTOServiceMapper<BarDTO, Bar>, BarDTOMapper>();
            services.AddScoped<IDTOServiceMapper<BarCommentDTO, BarComment>, BarCommentDTOMapper>();
            services.AddScoped<IDTOServiceMapper<BarRating, BarRatingDTO>, BarRatingDTOMapper>();

            services.AddScoped<IDTOServiceMapper<ICollection<Bar>, CollectionDTO>,CollectionDTOMapper>();

            services.AddScoped<IDTOServiceMapper<Ingredient, IngredientDTO>, IngredientDTOMapper>();
            services.AddScoped<IDTOServiceMapper<Cocktail, CocktailDTO>, CocktailDTOMapper>();
            
            return services;
        }
    }
}
