﻿using IriOnCocktailService.Data.Entities;
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

            // Bar
            services.AddScoped<IDTOServiceMapper<Bar, BarDTO>, BarDTOMapper>();
            services.AddScoped<IDTOServiceMapper<BarDTO, Bar>, BarDTOMapper>();
            services.AddScoped<IDTOServiceMapper<CommentDTO, BarComment>, BarCommentDTOMapper>();
            services.AddScoped<IDTOServiceMapper<RatingDTO, BarRating>, BarRatingDTOMapper>();

            services.AddScoped<IDTOServiceMapper<ICollection<Bar>, CollectionDTO>,CollectionDTOMapper>();

            // Ingredient
            services.AddScoped<IDTOServiceMapper<Ingredient, IngredientDTO>, IngredientDTOMapper>();
            services.AddScoped<IDTOServiceMapper<Cocktail, CocktailDTO>, CocktailDTOMapper>();

            // CocktailIngredient
            services.AddScoped<IDTOServiceMapper<CocktailIngredient, CocktailIngredientDTO>, CocktailIngredientDTOMapper>();
            services.AddScoped<IDTOServiceMapper<CocktailIngredientDTO, CocktailIngredient>, CocktailIngredientDTOMapper>();
            return services;
        }
    }
}
