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
        private readonly IDTOServiceMapper<CocktailDTO, Cocktail> cocktailMapper;

        private readonly IDTOServiceMapper<CommentDTO, CocktailComment> cocktailCommentMapper;
        private readonly IDTOServiceMapper<CocktailComment, CommentDTO> cocktailCommentDTOMapper; 
        private readonly IDTOServiceMapper<Cocktail, AddCocktailDTO> addCocktailMapper;
        private readonly IDTOServiceMapper<RatingDTO, CocktailRating> cocktailRatingMapper;

        public CocktailService(IriOnCocktailServiceDbContext context,
                               ICocktailIngredientService cocktailIngredientService,
                               IDTOServiceMapper<Cocktail, CocktailDTO> mapper,
                               IDTOServiceMapper<CocktailDTO, Cocktail> cocktailMapper,
                               IDTOServiceMapper<CommentDTO, CocktailComment> cocktailCommentMapper,
                               IDTOServiceMapper<CocktailComment, CommentDTO> cocktailCommentDTOMapper,
                               IDTOServiceMapper<Cocktail, AddCocktailDTO> addCocktailMapper,
                               IDTOServiceMapper<RatingDTO, CocktailRating> cocktailRatingMapper)
        {
            this.context = context;
            this.cocktailIngredientService = cocktailIngredientService;
            this.mapper = mapper;
            this.cocktailMapper = cocktailMapper;
            this.cocktailCommentMapper = cocktailCommentMapper;
            this.cocktailCommentDTOMapper = cocktailCommentDTOMapper;
            this.addCocktailMapper = addCocktailMapper;
            this.cocktailRatingMapper = cocktailRatingMapper;
        }

        public async Task<CocktailDTO> CreateCocktail(CocktailDTO cocktailDTO)
        {
            if(cocktailDTO==null)
            {
                throw new ArgumentException("The parameter is null");
            }
            var cocktail = this.cocktailMapper.MapFrom(cocktailDTO);

            await this.context.Cocktails.AddAsync(cocktail);
            await this.context.SaveChangesAsync();

            cocktailDTO.Ingredients.ForEach(cdto => cdto.CocktailId = cocktail.Id);
            await cocktailIngredientService.CreateCocktailIngredient(cocktailDTO.Ingredients);

            return cocktailDTO;
        }

        public async Task<CocktailDTO> GetCocktailDTO(string id)
        {
            var cocktail = await this.context.Cocktails
                .Include(c => c.CocktailIngredients)
                    .ThenInclude(ci=>ci.Ingredient)
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
                .Include(c=>c.CocktailIngredients)
                    .ThenInclude(ci=>ci.Ingredient)
                .Include(c=>c.Ratings)
                .Where(c => c.NotAvailable == false)
                .Select(c => this.mapper.MapFrom(c))
                .ToListAsync();

            if(cocktails.Count == 0)
            {
                throw new ArgumentNullException(GlobalConstants.NoCocktailsFound);
            }

            return cocktails;
        }

        public async Task<ICollection<CocktailDTO>> GetAllCocktailsByNameDTO(string name)
        {
            var cocktails = await this.context.Cocktails
                .Include(c => c.CocktailIngredients)
                    .ThenInclude(ci => ci.Ingredient)
                .Include(c => c.Ratings)
                .Where(c => c.NotAvailable == false && c.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();

            if(cocktails.Count()==0)
            {
                throw new ArgumentException(GlobalConstants.NoCocktailsFound);
            }

            return cocktails.Select(this.mapper.MapFrom).ToList(); 
        }
        public async Task<CocktailDTO> EditCocktailAsync(CocktailDTO cocktailDTO)
        {
            var cocktail = await GetCocktail(cocktailDTO.Id);

            cocktail.Name = cocktailDTO.Name;
            cocktail.PicUrl = cocktailDTO.PicUrl;

            this.context.Cocktails.Update(cocktail);
            await this.context.SaveChangesAsync();

            return cocktailDTO;
        }

        public async Task<ICollection<CocktailDTO>> GetAllCocktailsByIngredientDTO(string ingredient)
        {
            var ingr = await this.context.Cocktails.
                Include(c => c.CocktailIngredients)
                    .ThenInclude(ci => ci.Ingredient)
                .Include(c => c.Ratings)
                .Where(c => c.CocktailIngredients
                    .Where(ci => ci.CocktailId == c.Id)
                .Select(ci => ci.Ingredient.Name.ToLower())
                .Contains(ingredient.ToLower())).ToListAsync();

            var ingredients = await this.context.Ingredients.Where(u => u.Name.ToLower().Contains(ingredient.ToLower())).ToListAsync();

            var list = new List<CocktailIngredient>();

            ingredients.ForEach(i => list.AddRange(this.context.CocktailIngredients.Where(c => c.IngredientId == i.Id)));

            var cocktails = new List<Cocktail>();

            list.ForEach(u => cocktails.AddRange(this.context.Cocktails.Include(c => c.Ratings).Where(c => c.Id == u.CocktailId)));

            return cocktails.Select(this.mapper.MapFrom).ToList();
        }

        public async Task<CommentDTO> CocktailCommentAsync(CommentDTO barCommentDTO)
        {
            var barComment = this.cocktailCommentMapper.MapFrom(barCommentDTO);
            if(barComment==null)
            {
                throw new ArgumentException(GlobalConstants.IncorrectMapping);
            }
            await this.context.CocktailComments.AddAsync(barComment);
            await this.context.SaveChangesAsync();

            return barCommentDTO;
        }
        public async Task<RatingDTO> CocktailRatingAsync(RatingDTO cocktailRatingDTO)
        {
            var cocktailRating = this.cocktailRatingMapper.MapFrom(cocktailRatingDTO);

            if(cocktailRating == null)
            {
                throw new ArgumentNullException(GlobalConstants.InvalidComment);
            }
            await this.context.CocktailRatings.AddAsync(cocktailRating);
            await this.context.SaveChangesAsync();

            return cocktailRatingDTO;
        }

        public async Task<ICollection<CommentDTO>> GetAllCommentsForCoctail(string cocktailId)
        {
            var comments = this.context.CocktailComments
                .Include(bc => bc.User)
                .Where(bc => bc.CocktailId == cocktailId);
            var commentDTOs = comments.Select(c => this.cocktailCommentDTOMapper.MapFrom(c));

            return await commentDTOs.ToListAsync();
        }

        public async Task<ICollection<AddCocktailDTO>> GetAllContainedCocktailsDTO(string barId)
        {
            var cocktails = new List<Cocktail>();

            var containedCocktails = await this.context.CocktailBars.Where(cb => cb.BarId == barId).Select(cb => cb.CocktailId).ToListAsync();

            foreach (var item in containedCocktails)
            {
                var cocktailToBeAdded = this.context.Cocktails.FirstOrDefault(x => x.Id == item);
                if(cocktailToBeAdded !=null)
                cocktails.Add(cocktailToBeAdded);
            }
            var cocktailsDTO = cocktails.Select(x => this.addCocktailMapper.MapFrom(x)).ToList();
            return cocktailsDTO;
        }
        public async Task<ICollection<AddCocktailDTO>> GetAllNotContainedCocktailsDTO(string barId)
        {
            var cocktails = await this.context.Cocktails
                .Include(c=>c.Ratings)
                .Include(c=>c.CocktailIngredients)
                .ToListAsync();

            var containedCocktails = await this.context.CocktailBars.Where(cb => cb.BarId == barId).Select(cb => cb.CocktailId).ToListAsync();
            foreach (var item in containedCocktails)
            {
                var cocktailToBeRemoved = this.context.Cocktails.FirstOrDefault(x => x.Id == item);
            cocktails.Remove(cocktailToBeRemoved);
            }
            var cocktailsDTO = cocktails.Select(x => this.addCocktailMapper.MapFrom(x)).ToList();
            return cocktailsDTO;
        }
    }
}
