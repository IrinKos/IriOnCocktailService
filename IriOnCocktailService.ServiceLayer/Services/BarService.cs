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
        private readonly IDTOServiceMapper<BarDTO, Bar> mapperFromEntity;
        private readonly IDTOServiceMapper<ICollection<Bar>, CollectionDTO> collectionMapper;

        public BarService(IriOnCocktailServiceDbContext context, 
                         IDTOServiceMapper<Bar, BarDTO> mapper,
                         IDTOServiceMapper<BarDTO, Bar> mapperFromEntity,
                         IDTOServiceMapper<ICollection<Bar>, CollectionDTO> collectionMapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.mapperFromEntity = mapperFromEntity;
            this.collectionMapper = collectionMapper;
        }

        private async Task<Bar> GetBar(string barId)
        {
            return await this.context.Bars.SingleOrDefaultAsync(b => b.Id == barId);
        }
        public async Task<BarDTO> CreateBarAsync(BarDTO barDTO)
        {
            var bar = mapperFromEntity.MapFrom(barDTO);
            //var bar = new Bar
            //{
            //    Name = barDTO.BarName,
            //    Address=barDTO.BarAddress,
            //    PhoneNumber=barDTO.BarPhoneNumber,
            //    PicUrl=barDTO.BarPicUrl
            //};

            await this.context.Bars.AddAsync(bar);
            await this.context.SaveChangesAsync();

            return barDTO;
        }
        public async Task<BarDTO> GetBarAsync(string barId)
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

        public async Task<CollectionDTO> GetBarsAsync()
        {
            var bars = await this.context.Bars
                .Include(b => b.Ratings)
                .Include(b => b.Comments)
                .Include(b => b.CocktailBars)
                .ToListAsync();
            var barsDTOs = this.collectionMapper.MapFrom(bars);

            return barsDTOs;
        }

        public async Task DeleteBarAsync(string barId)
        {
            var bar = await this.context.Bars
                .Include(b => b.Ratings)
                .Include(b => b.Comments)
                .Include(b => b.CocktailBars)
                .SingleOrDefaultAsync(b => b.Id == barId);

            bar.NotAvailable = true;

            this.context.Bars.Update(bar);
            await this.context.SaveChangesAsync();
        }
        public async Task<BarDTO> EditBarAsync(BarDTO dto)
        {
            var bar = await GetBar(dto.BarId);

            bar.Name = dto.BarName;
            bar.PhoneNumber = dto.BarPhoneNumber;
            bar.PicUrl = dto.BarPicUrl;
            bar.Address = dto.BarAddress;

            this.context.Bars.Update(bar);
            await this.context.SaveChangesAsync();

            return dto;
        }
    }
}
