using IriOnCocktailService.Data;
using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using IriOnCocktailService.ServiceLayer.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriOnCocktailService.ServiceLayer.Services
{
    public class CocktailService : ICocktailService
    {
        private readonly IriOnCocktailServiceDbContext context;
        private readonly ICocktailIngredientService cocktailIngredientService;
        private readonly IDTOServiceMapper<Cocktail, CocktailDTO> mapper;
        private readonly IDTOServiceMapper<CommentDTO, CocktailComment> cocktailCommentMapper;
        private readonly IDTOServiceMapper<RatingDTO, CocktailRating> cocktailRatingMapper;

        public CocktailService(IriOnCocktailServiceDbContext context,
                               ICocktailIngredientService cocktailIngredientService,
                               IDTOServiceMapper<Cocktail, CocktailDTO> mapper,
                               IDTOServiceMapper<CommentDTO, CocktailComment> cocktailCommentMapper,
                               IDTOServiceMapper<RatingDTO, CocktailRating> cocktailRatingMapper)
        {
            this.context = context;
            this.cocktailIngredientService = cocktailIngredientService;
            this.mapper = mapper;
            this.cocktailCommentMapper = cocktailCommentMapper;
            this.cocktailRatingMapper = cocktailRatingMapper;
        }

        public async Task<CocktailDTO> CreateCocktail(CocktailDTO cocktailDTO)
        {
            var cocktail = new Cocktail
            {
                Name = cocktailDTO.Name,
            };

            await this.context.Cocktails.AddAsync(cocktail);
            await this.context.SaveChangesAsync();
            //cocktailDTO.Ingredients.Select(cdto => cdto.CocktailId = cocktail.Id);
            foreach (var item in cocktailDTO.Ingredients)
            {
                item.CocktailId = cocktail.Id;
            }
            await cocktailIngredientService.CreateCocktailIngredient(cocktailDTO.Ingredients);

            return cocktailDTO;
        }

        public async Task<CocktailDTO> GetCocktailDTO(string id)
        {
            var cocktail = await this.context.Cocktails
                .Include(c => c.CocktailIngredients)
                .Include(c => c.CocktailBars)
                .Include(c => c.Comments)
                .Include(c => c.Ratings)
                    .ThenInclude(r => r.Rate)
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
                .Include(c=>c.CocktailIngredients)
                    .ThenInclude(ci=>ci.Ingredient)
                .Include(c=>c.Ratings)
                .Where(c => c.NotAvailable == false)
                .Select(c => this.mapper.MapFrom(c))
                .ToListAsync();

            return cocktails;
        }

        public async Task<ICollection<CocktailDTO>> GetAllCocktailsByNameDTO(string name)
        {
            var cocktails = await this.context.Cocktails
                .Include(c => c.CocktailIngredients)
                    .ThenInclude(ci => ci.Ingredient)
                .Include(c => c.Ratings)
                .Where(c => c.NotAvailable == false)
                .Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();

            var cocktailsDTO = new List<CocktailDTO>();
            foreach (var cocktail in cocktails)
            {
                cocktailsDTO.Add(this.mapper.MapFrom(cocktail));
            }
            return cocktailsDTO;
        }

        public async Task<CommentDTO> CocktailCommentAsync(CommentDTO barCommentDTO)
        {
            var barComment = this.cocktailCommentMapper.MapFrom(barCommentDTO);

            await this.context.CocktailComments.AddAsync(barComment);
            await this.context.SaveChangesAsync();

            return barCommentDTO;
        }
        public async Task<RatingDTO> CocktailRatingAsync(RatingDTO cocktailRatingDTO)
        {
            var cocktailRating = this.cocktailRatingMapper.MapFrom(cocktailRatingDTO);

            await this.context.CocktailRatings.AddAsync(cocktailRating);
            await this.context.SaveChangesAsync();

            return cocktailRatingDTO;
        }
    }
}
