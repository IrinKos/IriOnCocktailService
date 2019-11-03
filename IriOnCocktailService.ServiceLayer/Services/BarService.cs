using IriOnCocktailService.Data;
using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using IriOnCocktailService.ServiceLayer.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IriOnCocktailService.ServiceLayer.Services
{
    public class BarService : IBarService
    {
        private readonly IriOnCocktailServiceDbContext context;
        private readonly IDTOServiceMapper<Bar, BarDTO> mapper;

        public BarService(IriOnCocktailServiceDbContext context, IDTOServiceMapper<Bar, BarDTO> mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<BarDTO> CreateBar(BarDTO barDTO)
        {
            var bar = new Bar
            {
                Name = barDTO.BarName,
                Address=barDTO.BarAddress,
                PhoneNumber=barDTO.BarPhoneNumber,
                PicUrl=barDTO.BarPicUrl
            };

            await this.context.Bars.AddAsync(bar);
            await this.context.SaveChangesAsync();

            return barDTO;
        }
        public async Task<BarDTO> GetBar(string barId)
        {
            var bar = await this.context.Bars
                .Include(b => b.Ratings)
                .Include(b => b.Comments)
                .Include(b => b.CocktailBars)
                .SingleOrDefaultAsync(b => b.Id == barId);

            if (bar == null)
            {
                //TODO Handle Exception
                throw new Exception();
            }

            var barDTO = this.mapper.MapFrom(bar);

            return barDTO;
        }
    }
}
