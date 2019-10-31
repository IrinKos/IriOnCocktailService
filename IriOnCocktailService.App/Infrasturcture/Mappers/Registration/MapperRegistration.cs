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
            services.AddSingleton < IViewModelMapper<BarDTO, CreateBarViewModel>, CreateBarViewModelMapper>();
            services.AddSingleton < IDTOMapper<CreateBarViewModel, BarDTO>, CreateBarViewModelMapper>();

            return services;
        }
    }
}
