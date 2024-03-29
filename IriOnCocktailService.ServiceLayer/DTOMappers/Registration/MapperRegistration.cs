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
            services.AddScoped<IDTOServiceMapper<Cocktail, AddCocktailDTO>, AddCocktailDTOMapper>();
            services.AddScoped<IDTOServiceMapper<User, UserDTO>, UserDTOMapper>();
            services.AddScoped<IDTOServiceMapper<User, UserDTO>, UserDTOMapper>();

            //
            services.AddScoped<IDTOServiceMapper<RatingDTO, BarRating>, BarRatingDTOMapper>();

            //
            services.AddScoped<IDTOServiceMapper<Bar, BarDTO>, BarDTOMapper>();
            services.AddScoped<IDTOServiceMapper<ICollection<BarDTO>, ICollection<Bar>>, BarDTOMapper>();
            services.AddScoped<IDTOServiceMapper<ICollection<Bar>, ICollection<BarDTO>>, BarDTOMapper>();

            // Bar
            services.AddScoped<IDTOServiceMapper<Bar, BarDTO>, BarDTOMapper>();
            services.AddScoped<IDTOServiceMapper<BarDTO, Bar>, BarDTOMapper>();
            services.AddScoped<IDTOServiceMapper<BarComment, CommentDTO>, BarCommentDTOMapper>();
            services.AddScoped<IDTOServiceMapper<CommentDTO, BarComment>, BarCommentDTOMapper>();
            services.AddScoped<IDTOServiceMapper<CommentDTO, CocktailComment>, CocktailCommentDTOMapper>();
            services.AddScoped<IDTOServiceMapper<CocktailComment, CommentDTO>, CocktailCommentDTOMapper>();
            services.AddScoped<IDTOServiceMapper<RatingDTO, CocktailRating>, CocktailRatingDTOMapper>();

            // Ingredient
            services.AddScoped<IDTOServiceMapper<Ingredient, IngredientDTO>, IngredientDTOMapper>();
            services.AddScoped<IDTOServiceMapper<IngredientDTO, Ingredient>, IngredientDTOMapper>();
            services.AddScoped<IDTOServiceMapper<Cocktail, CocktailDTO>, CocktailDTOMapper>();
            services.AddScoped<IDTOServiceMapper<CocktailDTO, Cocktail>, CocktailDTOMapper>();

            // CocktailIngredient
            services.AddScoped<IDTOServiceMapper<CocktailIngredient, CocktailIngredientDTO>, CocktailIngredientDTOMapper>();
            services.AddScoped<IDTOServiceMapper<CocktailIngredientDTO, CocktailIngredient>, CocktailIngredientDTOMapper>();
            return services;
        }
    }
}
