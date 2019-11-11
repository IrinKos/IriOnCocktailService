﻿using IriOnCocktailService.App.Areas.Crawler.Models;
using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers.Registration
{
    public static class MapperRegistration
    {
        public static IServiceCollection AddVMCustomMapper(this IServiceCollection services)
        {
            //
            services.AddSingleton <IViewModelMapper<BarDTO, DisplayBarsViewModel>, DisplayBarsViewModelMapper> ();


            //
            services.AddSingleton <IDTOMapper<CreateCocktailViewModel, CocktailDTO>, CreateCocktailViewModelMapper> ();


            services.AddSingleton <IDTOMapper<RatingViewModel, RatingDTO> ,BarRatingViewModelMapper> ();
            //
            services.AddSingleton <IDTOMapper<AddIngredientToCocktailViewModel, CocktailIngredientDTO>, AddIngredientToCocktailViewModelMapper> ();


            //BarComment VM to DTO
            services.AddSingleton <IDTOMapper<CommentViewModel, CommentDTO>, BarCommentViewModelMapper>();

            //Collection DTO to VM
            services.AddSingleton <IViewModelMapper<ICollection<BarDTO>, CollectionViewModel>, CollectionViewModelMapper>();

            //User VM to DTO
            services.AddSingleton <IDTOMapper<ChangeRoleViewModel, UserDTO>, ChangeRoleViewModelMapper>();

            //Bar DTO to VM
            services.AddSingleton < IViewModelMapper<BarDTO, CreateBarViewModel>, CreateBarViewModelMapper>();
            services.AddSingleton < IViewModelMapper<BarDTO, DeleteBarViewModel>, DeleteBarViewModelMapper>();
            // Bar VM to DTO
            services.AddSingleton < IDTOMapper<CreateBarViewModel, BarDTO>, CreateBarViewModelMapper>();

            // Ingredient DTO to VM
            services.AddSingleton < IViewModelMapper<IngredientDTO, CreateIngredientViewModel>, CreateIngredientViewModelMapper>();
            // Ingredient VM to DTO
            services.AddSingleton < IDTOMapper<CreateIngredientViewModel, IngredientDTO>, CreateIngredientViewModelMapper>();;


            return services;
        }
    }
}
