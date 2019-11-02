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
    public class IngredientService
    {
        private readonly IriOnCocktailServiceDbContext context;
        private readonly IDTOMapper<Ingredient, IngredientDTO> mapper;

        public IngredientService(IriOnCocktailServiceDbContext context, IDTOMapper<Ingredient, IngredientDTO> mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IngredientDTO> CreateIngredient(IngredientDTO ingredientDTO)
        {
            if (this.GetIngredientDTO(ingredientDTO.Id) != null)
                throw new ArgumentException(GlobalConstants.ExistedIngredient);

            var ingredient = new Ingredient { Id = ingredientDTO.Id, Name = ingredientDTO.Name };

            await this.context.Ingredients.AddAsync(ingredient);
            await this.context.SaveChangesAsync();

            return ingredientDTO;
        }

        public async Task<IngredientDTO> GetIngredientDTO(string ingredientId)
        {
            var ingredient = await this.context.Ingredients
                .Include(i => i.CocktailIngredients)
                .SingleOrDefaultAsync(i => i.Id == ingredientId && i.IsDeleted == false);

            if (ingredient == null)
                throw new ArgumentNullException(GlobalConstants.UnavailbleIngredient);
            if (ingredient.IsDeleted == true)
                throw new ArgumentException(GlobalConstants.DeletedIngredient);

            var ingredientDTO = this.mapper.MapFrom(ingredient);

            return ingredientDTO;
        }

        public async Task<Ingredient> GetIngredient(string ingredientId)
        {
            var ingredient = await this.context.Ingredients
                .Include(i => i.CocktailIngredients)
                .SingleOrDefaultAsync(i => i.Id == ingredientId && i.IsDeleted == false);

            if (ingredient == null)
                throw new ArgumentNullException(GlobalConstants.UnavailbleIngredient);
            if (ingredient.IsDeleted == true)
                throw new ArgumentException(GlobalConstants.DeletedIngredient);

            return ingredient;
        }

        public async Task<ICollection<IngredientDTO>> GetAllIngredients()
        {
            var ingredients = await this.context.Ingredients
                .Where(i => i.IsDeleted == false)
                .Select(i => new IngredientDTO{ Id = i.Id, Name = i.Name })
                .ToListAsync();

            return ingredients;
        }

        //TODO Why cannot update DTO
        public async Task<Ingredient> UpdateIngredient(string id, string newName)
        {
            var ingredient = await this.GetIngredient(id); 
            ingredient.Name = newName;

            this.context.Ingredients.Update(ingredient);
            await this.context.SaveChangesAsync();

            return ingredient;
        }
    }
}
