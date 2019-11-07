﻿using IriOnCocktailService.Data;
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
        private readonly IDTOServiceMapper<BarCommentDTO, BarComment> barCommentMapper;
        private readonly IDTOServiceMapper<BarRatingDTO, BarRating> barRatingMapper;

        public BarService(IriOnCocktailServiceDbContext context, 
                         IDTOServiceMapper<Bar, BarDTO> mapper,
                         IDTOServiceMapper<BarDTO, Bar> mapperFromEntity,
                         IDTOServiceMapper<ICollection<Bar>, CollectionDTO> collectionMapper,
                         IDTOServiceMapper<BarCommentDTO, BarComment> barCommentMapper,
                         IDTOServiceMapper<BarRatingDTO, BarRating> barRatingMapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.mapperFromEntity = mapperFromEntity;
            this.collectionMapper = collectionMapper;
            this.barCommentMapper = barCommentMapper;
            this.barRatingMapper = barRatingMapper;
        }

        private async Task<Bar> GetBar(string barId)
        {
            return await this.context.Bars.SingleOrDefaultAsync(b => b.Id == barId);
        }
        public async Task<BarDTO> CreateBarAsync(BarDTO barDTO)
        {
            var bar = mapperFromEntity.MapFrom(barDTO);

            await this.context.Bars.AddAsync(bar);
            await this.context.SaveChangesAsync();

            return barDTO;
        }
        public async Task<BarDTO> GetBarAsync(string barId)
        {
            var bar = await this.context.Bars
                .Include(b => b.BarRatings)
                .Include(b => b.BarComments)
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
                .Include(b => b.BarRatings)
                .Include(b => b.BarComments)
                .Include(b => b.CocktailBars)
                .ToListAsync();
            var barsDTOs = this.collectionMapper.MapFrom(bars);

            return barsDTOs;
        }

        public async Task DeleteBarAsync(string barId)
        {
            var bar = await this.context.Bars
                .Include(b => b.BarRatings)
                .Include(b => b.BarComments)
                .Include(b => b.CocktailBars)
                .SingleOrDefaultAsync(b => b.Id == barId);

            bar.NotAvailable = true;

            this.context.Bars.Update(bar);
            await this.context.SaveChangesAsync();
        }
        public async Task<BarDTO> EditBarAsync(BarDTO barDto)
        {
            var bar = await GetBar(barDto.BarId);

            bar.Name = barDto.BarName;
            bar.PhoneNumber = barDto.BarPhoneNumber;
            bar.PicUrl = barDto.BarPicUrl;
            bar.Address = barDto.BarAddress;

            this.context.Bars.Update(bar);
            await this.context.SaveChangesAsync();

            return barDto;
        }

        public async Task<BarCommentDTO> BarCommentAsync(BarCommentDTO barCommentDTO)
        {
            var barComment = this.barCommentMapper.MapFrom(barCommentDTO);

            await this.context.BarComments.AddAsync(barComment);
            await this.context.SaveChangesAsync();

            return barCommentDTO;
        }
        public async Task<BarRatingDTO> BarRatingAsync(BarRatingDTO barRatingDTO)
        {
            var barComment = this.barRatingMapper.MapFrom(barRatingDTO);

            await this.context.BarRating.AddAsync(barComment);
            await this.context.SaveChangesAsync();

            return barRatingDTO;
        }
    }
}
