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
            services.AddScoped<IDTOMapper<Bar, BarDTO>, BarDTOMapper>();
            services.AddScoped<IDTOMapper<Ingredient, IngredientDTO>, IngredientDTOMapper>();
            
            return services;
        }
    }
}
