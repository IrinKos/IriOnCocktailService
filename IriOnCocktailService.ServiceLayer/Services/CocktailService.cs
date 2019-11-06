using IriOnCocktailService.Data;
using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriOnCocktailService.ServiceLayer.Services
{
    public class CocktailService
    {
        private readonly IriOnCocktailServiceDbContext context;
        private readonly IDTOServiceMapper<Cocktail, CocktailDTO> mapper;

        public CocktailService(IriOnCocktailServiceDbContext context, IDTOServiceMapper<Cocktail, CocktailDTO> mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<CocktailDTO> CreateCocktail(CocktailDTO cocktailDTO)
        {
            var cocktail = new Cocktail
            {
                Id = cocktailDTO.Id,
                Name = cocktailDTO.Name,
                PicUrl = cocktailDTO.PicUrl,
                NotAvailable = cocktailDTO.NotAvailable
            };

            await this.context.Cocktails.AddAsync(cocktail);
            await this.context.SaveChangesAsync();

            return cocktailDTO;
        }

        public async Task<CocktailDTO> GetCocktailDTO(string id)
        {
            var cocktail = await this.context.Cocktails
                .Include(c => c.CocktailIngredients)
                .Include(c => c.CocktailBars)
                .Include(c => c.Comments)
                .Include(c => c.Ratings)
                .SingleOrDefaultAsync(c => c.Id == id && c.NotAvailable == false);

            if (cocktail == null || cocktail.NotAvailable == true)
                throw new ArgumentException(GlobalConstants.UnavailableCocktail);

            var cocktailDTO = this.mapper.MapFrom(cocktail);

            return cocktailDTO;
        }

        public async Task<Cocktail> GetCocktail(string id)
        {
            var cocktail = await this.context.Cocktails
                .Include(c => c.CocktailIngredients)
                .Include(c => c.CocktailBars)
                .Include(c => c.Comments)
                .Include(c => c.Ratings)
                .SingleOrDefaultAsync(c => c.Id == id && c.NotAvailable == false);

            if (cocktail == null || cocktail.NotAvailable == true)
                throw new ArgumentException(GlobalConstants.UnavailableCocktail);

            return cocktail;
        }

        public async Task<ICollection<CocktailDTO>> GetAllCocktailsDTO()
        {
            var cocktails = await this.context.Cocktails
                .Where(c => c.NotAvailable == false)
                .Select(c => new CocktailDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    PicUrl = c.PicUrl,
                    NotAvailable = c.NotAvailable
                })
                .ToListAsync();

            return cocktails;
        }
    }
}
