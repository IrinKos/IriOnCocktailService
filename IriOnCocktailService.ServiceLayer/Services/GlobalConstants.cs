using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.Services
{
    public class GlobalConstants
    {
        // Ingredient
        public const string UnavailbleIngredient = "The ingredient does not exist!";
        public const string DeletedIngredient = "The ingredient is deleted!";
        public const string ExistedIngredient = "This ingredient already exist!";
        public const string ContainedIngredient = "You cannot delete this ingredient because it is contained in one or more cocktails!";

        // Cocktails
        public const string UnavailableCocktail = "The cocktail does not exist";
        public const string NoCocktailsFound = "No cocktails found";

        //Cocktail Comments
        public const string InvalidComment = "There was an error proceeding your comment";

        //Mapper
        public const string IncorrectMapping = "There was an error with the mapper";

    }
}
