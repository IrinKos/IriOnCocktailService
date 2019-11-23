using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IriOnCocktailService.Data;
using IriOnCocktailService.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IriOnCocktailService.Data
{
    public class IriOnCocktailServiceDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        private readonly List<Cocktail> cocktailSeeder = new List<Cocktail>()
        {

            new Cocktail()
            {
                Id = "26531c92-59cd-4503-86c9-17ab02d0e4c1",
                Name = "Dry Martini",
                PicUrl = "https://www.bascofinefoods.com/spanish-recipes-wpfiles/wp-content/uploads/2015/07/dry_martini_recipe-e1505646628151.jpg",
                Motto = "H.L Mencken called the Martini \"the only American invention as perfect as the sonnet\"."
            },
            new Cocktail()
            {
                Id = "11b8db86-d375-4cde-81c5-66be2938acdd",
                Name = "Daiquiri",
                PicUrl = "https://www.thespruceeats.com/thmb/XmHuAIwiqm_YMOsF6lmFCswLYt4=/960x0/filters:no_upscale():max_bytes(150000):strip_icc()/hemingway-daiquiri-recipe-760527-Hero-5bbfa3c2c9e77c0052b8b7d2.jpg",
                //Put picture here
                Motto = "Due to Roosevelt`s Good Neighbour policy (which opened up trade with Cuba, Latin America and the Carribean) rum became easily obtainable in the 1940S and this helped drive the popularity of the daiquiri in the US."
            },
            new Cocktail()
            {
                Id = "77c8a1f5-66f6-4c5d-b06d-1ad0cdd1097d",
                Name = "Esspresso Martini",
                PicUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRcI5X1cmG98KMGYLkMkls8vGbKLdBkSTJf8JsM6m9oMatX6TBI&s",
                Motto = "Coffee is the second most traded commodity on earth."
            },
            new Cocktail()
            {
                Id = "ff98b546-3f4d-486c-acaf-6da5a2d1f4fc",
                Name = "Old Fashioned",
                PicUrl = "http://res.cloudinary.com/hjqklbxsu/image/upload/f_auto,fl_lossy,q_auto/v1536680101/social-share/JDSB_OldFashioned_DigitalRecipePost.jpg",
                Motto = "The name references the combinations age, as it is perhaps the first drink to be called a cocktail."
            },
            new Cocktail()
            {
                Id = "42cd2509-9e0d-4451-b20b-4822931ac723",
                Name = "Cosmopolitan",
                PicUrl = "https://peopledotcom.files.wordpress.com/2018/02/unknown-12.jpeg",
                Motto = "The Cosmopolitan gained significant popularity in the 1990s partly due to the fact that Sarah Jessica Parkers character, Carrie Bradshaw, in the hit televsion programme, \"Sex in the City\", often ordered the drink."
            },
            new Cocktail()
            {
                Id = "da9ef59d-7f71-4631-bda5-878e410c4e7f",
                Name = "White Russian",
                PicUrl = "https://images2.minutemediacdn.com/image/upload/c_fill,g_auto,h_1248,w_2220/f_auto,q_auto,w_1100/v1555340239/shape/mentalfloss/istock_000065613079_small.jpg",
                Motto = "The White Russian is the favourite drink of Jeffrey \"The Dude\" Lebowski, the main character of the 1998 film, \"The Big Lebowski\"."
            },
            new Cocktail()
            {
                Id = "957de258-83ae-4314-a015-6014a3f312d5",
                Name = "B-52",
                PicUrl = "https://casaveneracion.com/wp-content/uploads/2010/09/absinthe-b55.jpg",
                Motto = "B-52 carries up to 70,000 pounds of weapons."
            },
            new Cocktail()
            {
                Id = "aa0976da-4b5a-4b80-b7d0-c456c6be594d",
                Name = "Manhattan",
                PicUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQstaIovPmxlc5PnPTQ4n4P2kWnWv3ImmqiCSWKoswE5oSk2Nva&s",
                Motto = "Some cocktail experts argue that rye whisky makes the best Manhattans, as opposed to Bourbon"
            },
            new Cocktail()
            {
                Id = "4fae34e6-e1a1-462b-9e52-9e851079b41e",
                Name = "Mojito",
                PicUrl = "https://www.thespruceeats.com/thmb/uph9GgtfGnN3rlLSEaP1WhYI2Ag=/1000x562/smart/filters:no_upscale()/mojito-5a8f339fba61770036ec61d8.jpg",
                Motto = "In the 2006 movie \"Miami Vice\" lead character Crockett is seen drinking a Mojito from the bartender in the very first scene."
            }
        };
        private readonly List<CocktailIngredient> cocktailIngredientSeeder = new List<CocktailIngredient>()
        {
            // Dry Martini 26531c92-59cd-4503-86c9-17ab02d0e4c1
            new CocktailIngredient()
            {
                CocktailId = "26531c92-59cd-4503-86c9-17ab02d0e4c1",
                IngredientId = "8a26e862-811d-4053-bb2d-59587bb48188",
                Quantity = "60"
            },
            new CocktailIngredient()
            {
                CocktailId = "26531c92-59cd-4503-86c9-17ab02d0e4c1",
                IngredientId = "6c9dea74-cb47-4d4a-81ec-c21b1aec70ee",
                Quantity = "60"
            },
            // Esspresso Martinni 77c8a1f5-66f6-4c5d-b06d-1ad0cdd1097d
            new CocktailIngredient()
            {
                CocktailId = "77c8a1f5-66f6-4c5d-b06d-1ad0cdd1097d",
                IngredientId = "dff51835-fdd3-4695-9954-28da0435ac7a",
                Quantity = "37"
            },
            new CocktailIngredient()
            {
                CocktailId = "77c8a1f5-66f6-4c5d-b06d-1ad0cdd1097d",
                IngredientId = "703d3be1-ce27-483b-ad61-130b5500d368",
                Quantity = "12"
            },
            new CocktailIngredient()
            {
                CocktailId = "77c8a1f5-66f6-4c5d-b06d-1ad0cdd1097d",
                IngredientId = "42304a2b-6806-4c5d-80a2-a2a50ae21b70",
                Quantity = "30"
            },
            new CocktailIngredient()
            {
                CocktailId = "77c8a1f5-66f6-4c5d-b06d-1ad0cdd1097d",
                IngredientId = "7aff3750-c7bd-412b-b869-f28f3d44d046",
                Quantity = "12"
            },
            new CocktailIngredient()
            {
                CocktailId = "77c8a1f5-66f6-4c5d-b06d-1ad0cdd1097d",
                IngredientId = "3caa9be9-e557-40b6-a9fe-f31bdadcdb2f",
                Quantity = "3"
            },
                //Name = "Daiquiri",
                //Id = "11b8db86-d375-4cde-81c5-66be2938acdd",
            new CocktailIngredient()
            {
                CocktailId = "11b8db86-d375-4cde-81c5-66be2938acdd",
                IngredientId = "96d08841-a7ed-4eca-9f3f-72c2a777a167",
                Quantity = "50"
            },
            new CocktailIngredient()
            {
                CocktailId = "11b8db86-d375-4cde-81c5-66be2938acdd",
                IngredientId = "416809dc-3855-4bbf-8341-f3b4811d90bd",
                Quantity = "7.5"
            },
            new CocktailIngredient()
            {
                CocktailId = "11b8db86-d375-4cde-81c5-66be2938acdd",
                IngredientId = "d12faec1-8f1d-41b8-ab00-5aa9e8f9c7cb",
                Quantity = "25"
            },
             //Name = "Old Fashioned",
             //Id = "ff98b546-3f4d-486c-acaf-6da5a2d1f4fc",
            new CocktailIngredient()
            {
                CocktailId = "ff98b546-3f4d-486c-acaf-6da5a2d1f4fc",
                IngredientId = "416809dc-3855-4bbf-8341-f3b4811d90bd",
                Quantity = "5"
            },
            new CocktailIngredient()
            {
                CocktailId = "ff98b546-3f4d-486c-acaf-6da5a2d1f4fc",
                IngredientId = "e75bf641-54f4-474f-a7d7-3faaaf53759a",
                Quantity = "50"
            },
            new CocktailIngredient()
            {
                CocktailId = "ff98b546-3f4d-486c-acaf-6da5a2d1f4fc",
                IngredientId = "42252d46-40cc-48b5-b594-3a7ec63ba985",
                Quantity = "1"
            },
            new CocktailIngredient()
            {
                CocktailId = "ff98b546-3f4d-486c-acaf-6da5a2d1f4fc",
                IngredientId = "7d2c7d7d-4836-4b7a-8806-874bfe63fabf",
                Quantity = "1"
            },
            //Name = "Cosmopolitan",
            //Id = "42cd2509-9e0d-4451-b20b-4822931ac723",
            new CocktailIngredient()
            {
                CocktailId = "42cd2509-9e0d-4451-b20b-4822931ac723",
                IngredientId = "d6d57e51-bc61-4c4c-87cc-2a3cd7e440b5",
                Quantity = "37 1/2"
            },
            new CocktailIngredient()
            {
                CocktailId = "42cd2509-9e0d-4451-b20b-4822931ac723",
                IngredientId = "348b2dfc-9b80-4e6c-9709-e25a25195530",
                Quantity = "12 1/2"
            },
            new CocktailIngredient()
            {
                CocktailId = "42cd2509-9e0d-4451-b20b-4822931ac723",
                IngredientId = "a5d0b498-9470-4281-93f0-d38f3e456d8a",
                Quantity = "30"
            },
            new CocktailIngredient()
            {
                CocktailId = "42cd2509-9e0d-4451-b20b-4822931ac723",
                IngredientId = "7aff3750-c7bd-412b-b869-f28f3d44d046",
                Quantity = "12 1/2"
            },
            //    Name = "White Russian",
            //Id = "da9ef59d-7f71-4631-bda5-878e410c4e7f",
            new CocktailIngredient()
            {
                CocktailId = "da9ef59d-7f71-4631-bda5-878e410c4e7f",
                IngredientId = "dcb14d4d-6329-4641-bdd1-b02b7174ddcf",
                Quantity = "37 1/2"
            },
            new CocktailIngredient()
            {
                CocktailId = "da9ef59d-7f71-4631-bda5-878e410c4e7f",
                IngredientId = "85ee0d01-72fe-4fea-a1e8-3a31471110cf",
                Quantity = "25"
            },
            new CocktailIngredient()
            {
                CocktailId = "da9ef59d-7f71-4631-bda5-878e410c4e7f",
                IngredientId = "1adb7444-06eb-42a2-9783-98788907bfa6",
                Quantity = "15"
            },
            new CocktailIngredient()
            {
                CocktailId = "da9ef59d-7f71-4631-bda5-878e410c4e7f",
                IngredientId = "faeb50b9-c23f-4cc3-b8ed-f41f8d19eb38",
                Quantity = "15"
            },
            new CocktailIngredient()
            {
                CocktailId = "da9ef59d-7f71-4631-bda5-878e410c4e7f",
                IngredientId = "3caa9be9-e557-40b6-a9fe-f31bdadcdb2f",
                Quantity = "1"
            },
        //        Name = "B-52",
        //Id = "957de258-83ae-4314-a015-6014a3f312d5",
        new CocktailIngredient()
            {
                CocktailId = "957de258-83ae-4314-a015-6014a3f312d5",
                IngredientId = "85ee0d01-72fe-4fea-a1e8-3a31471110cf",
                Quantity = "10"
            },
        new CocktailIngredient()
            {
                CocktailId = "957de258-83ae-4314-a015-6014a3f312d5",
                IngredientId = "f885192f-3a79-4109-aa1d-313d5ee2291a",
                Quantity = "10"
            },
        new CocktailIngredient()
            {
                CocktailId = "957de258-83ae-4314-a015-6014a3f312d5",
                IngredientId = "348b2dfc-9b80-4e6c-9709-e25a25195530",
                Quantity = "10"
            },
        //        Name = "Manhattan",
        //Id = "aa0976da-4b5a-4b80-b7d0-c456c6be594d",
        new CocktailIngredient()
            {
                CocktailId = "aa0976da-4b5a-4b80-b7d0-c456c6be594d",
                IngredientId = "e75bf641-54f4-474f-a7d7-3faaaf53759a",
                Quantity = "50"
            },
        new CocktailIngredient()
            {
                CocktailId = "aa0976da-4b5a-4b80-b7d0-c456c6be594d",
                IngredientId = "e66d1721-8b0b-4d52-b71d-48a0e171ecfc",
                Quantity = "10"
            },
        new CocktailIngredient()
            {
                CocktailId = "aa0976da-4b5a-4b80-b7d0-c456c6be594d",
                IngredientId = "f6b8ead2-9bcb-437f-a079-2270a628512e",
                Quantity = "10"
            },
        new CocktailIngredient()
            {
                CocktailId = "aa0976da-4b5a-4b80-b7d0-c456c6be594d",
                IngredientId = "42252d46-40cc-48b5-b594-3a7ec63ba985",
                Quantity = "2"
            },
        // Mojito 
        new CocktailIngredient()
            {
                CocktailId = "4fae34e6-e1a1-462b-9e52-9e851079b41e",
                IngredientId = "599b0c7d-2c10-431b-b986-296df0a888b5",
                Quantity = "8"
            },
        new CocktailIngredient()
            {
                CocktailId = "4fae34e6-e1a1-462b-9e52-9e851079b41e",
                IngredientId = "7aff3750-c7bd-412b-b869-f28f3d44d046",
                Quantity = "10"
            },
        new CocktailIngredient()
            {
                CocktailId = "4fae34e6-e1a1-462b-9e52-9e851079b41e",
                IngredientId = "96d08841-a7ed-4eca-9f3f-72c2a777a167",
                Quantity = "50"
            },
        new CocktailIngredient()
            {
                CocktailId = "4fae34e6-e1a1-462b-9e52-9e851079b41e",
                IngredientId = "d12faec1-8f1d-41b8-ab00-5aa9e8f9c7cb",
                Quantity = "25"
            }
        };
        private readonly List<Ingredient> ingredientSeeder = new List<Ingredient>()
        {
            new Ingredient() {Id = "0af163c4-6210-4b51-9032-8cadf025083e", IsDeleted = false, UnitType = Unit.Quantity, Name = "Ground black pepper"},
            new Ingredient() {Id = "b46b8769-53d2-4aff-b538-f99948962172", IsDeleted = false, UnitType = Unit.Ml, Name = "Tomato Juice"},
            new Ingredient() {Id = "514afb68-79a8-4deb-bd9c-9d9c61afc1cb", IsDeleted = false, UnitType = Unit.Ml, Name = "Hot sauce"},
            new Ingredient() {Id = "7aab7c85-626f-4509-a357-56050fbe66e4", IsDeleted = false, UnitType = Unit.Ml, Name = "Worcestershire sauce"},
            new Ingredient() {Id = "e045e88a-0151-4394-bd23-62622f3335ff", IsDeleted = false, UnitType = Unit.Ml, Name = "Lemon juice"},
            new Ingredient() {Id = "8a26e862-811d-4053-bb2d-59587bb48188", IsDeleted = false, UnitType = Unit.Ml, Name = "Gin Bombay Sapphire"},
            new Ingredient() {Id = "6c9dea74-cb47-4d4a-81ec-c21b1aec70ee", IsDeleted = false, UnitType = Unit.Ml, Name = "Martini "},
            new Ingredient() {Id = "dcb14d4d-6329-4641-bdd1-b02b7174ddcf", IsDeleted = false, UnitType = Unit.Ml, Name = "Vodka"},
            new Ingredient() {Id = "2a34f05b-192a-46be-986a-3f23afa66a65", IsDeleted = false, UnitType = Unit.Ml, Name = "Tequila" },
            new Ingredient() {Id = "cf9db0c7-b266-4238-9b14-2e0b89cda8ef", IsDeleted = false, UnitType = Unit.Ml, Name = "Gin" },
            new Ingredient() {Id = "9dc9533e-6aa5-4483-8613-e7160a17547d", IsDeleted = false, UnitType = Unit.Ml, Name = "Tonik" },
            new Ingredient() {Id = "f99c65e7-fb0b-4723-a3d5-8ac05a8ba1e4", IsDeleted = false, UnitType = Unit.Ml, Name = "CocaCola" },
            new Ingredient() {Id = "a69c54ff-8e93-4181-8998-b4de42304075", IsDeleted = false, UnitType = Unit.Ml, Name = "Soda" },
            new Ingredient() {Id = "6fe3620d-87be-4773-90c1-d0a072f0c838", IsDeleted = false, UnitType = Unit.Ml, Name = "Wiskey" },
            new Ingredient() {Id = "b96ae8b3-7fad-406c-97d2-bc5e6dcc0d8c", IsDeleted = false, UnitType = Unit.Ml, Name = "Red Bull" },
            new Ingredient() {Id = "07ee6b8c-8986-4886-bbfd-cdca6e52a5df", IsDeleted = false, UnitType = Unit.Ml, Name = "Water" },
            new Ingredient() {Id = "d82e5701-27e5-45a2-955d-01d1071fce02", IsDeleted = false, UnitType = Unit.Ml, Name = "Banana Juice" },
            new Ingredient() {Id = "44ebac14-88ca-404f-87e6-ee0f3d3c180e", IsDeleted = false, UnitType = Unit.Ml, Name = "Orange Juice" },
            new Ingredient() {Id = "3fea7311-64e6-4325-af27-28cb41a5cf2c", IsDeleted = false, UnitType = Unit.Gr, Name = "Salt" },
            new Ingredient() {Id = "6852531d-f7ca-4c05-8b02-019a3ac53737", IsDeleted = false, UnitType = Unit.Gr, Name = "Cinnamon" },
            new Ingredient() {Id = "00b7970b-96e4-49ee-97c0-896871d4bd9f", IsDeleted = false, UnitType = Unit.Quantity, Name = "Ice" },
            new Ingredient() {Id = "6e3634b2-518f-40e2-ac20-1bf56297364a", IsDeleted = false, UnitType = Unit.Quantity, Name = "Olive" },
            new Ingredient() {Id = "dff51835-fdd3-4695-9954-28da0435ac7a", IsDeleted = false, UnitType = Unit.Ml, Name = "Vanila Vodka" },
            new Ingredient() {Id = "703d3be1-ce27-483b-ad61-130b5500d368", IsDeleted = false, UnitType = Unit.Ml, Name = "Kahlua" },
            new Ingredient() {Id = "42304a2b-6806-4c5d-80a2-a2a50ae21b70", IsDeleted = false, UnitType = Unit.Ml, Name = "Esspresso" },
            new Ingredient() {Id = "7aff3750-c7bd-412b-b869-f28f3d44d046", IsDeleted = false, UnitType = Unit.Ml, Name = "Sugar Syrop" },
            new Ingredient() {Id = "3caa9be9-e557-40b6-a9fe-f31bdadcdb2f", IsDeleted = false, UnitType = Unit.Quantity, Name = "Coffee Beans" },
            new Ingredient() {Id = "96d08841-a7ed-4eca-9f3f-72c2a777a167", IsDeleted = false, UnitType = Unit.Ml, Name = "White rum" },
            new Ingredient() {Id = "599b0c7d-2c10-431b-b986-296df0a888b5", IsDeleted = false, UnitType = Unit.Ml, Name = "Mint Leaves" },
            new Ingredient() {Id = "d12faec1-8f1d-41b8-ab00-5aa9e8f9c7cb", IsDeleted = false, UnitType = Unit.Ml, Name = "Lime Juice" },
            new Ingredient() {Id = "2a1498fb-00ce-4363-af6c-2ade242ce8bf", IsDeleted = false, UnitType = Unit.Ml, Name = "Mint sprigs" },
            new Ingredient() {Id = "416809dc-3855-4bbf-8341-f3b4811d90bd", IsDeleted = false, UnitType = Unit.Gr, Name = "Sugar" },
            new Ingredient() {Id = "e75bf641-54f4-474f-a7d7-3faaaf53759a", IsDeleted = false, UnitType = Unit.Ml, Name = "Bourbon" },
            new Ingredient() {Id = "42252d46-40cc-48b5-b594-3a7ec63ba985", IsDeleted = false, UnitType = Unit.Ml, Name = "Angostura Bitters" },
            new Ingredient() {Id = "7d2c7d7d-4836-4b7a-8806-874bfe63fabf", IsDeleted = false, UnitType = Unit.Ml, Name = "Orange Bitters" },
            new Ingredient() {Id = "d6d57e51-bc61-4c4c-87cc-2a3cd7e440b5", IsDeleted = false, UnitType = Unit.Ml, Name = "Citrus Vodka" },
            new Ingredient() {Id = "348b2dfc-9b80-4e6c-9709-e25a25195530", IsDeleted = false, UnitType = Unit.Ml, Name = "Triple Sec" },
            new Ingredient() {Id = "a5d0b498-9470-4281-93f0-d38f3e456d8a", IsDeleted = false, UnitType = Unit.Ml, Name = "Cranberry Juice" },
            new Ingredient() {Id = "85ee0d01-72fe-4fea-a1e8-3a31471110cf", IsDeleted = false, UnitType = Unit.Ml, Name = "Coffee Liqueur" },
            new Ingredient() {Id = "1adb7444-06eb-42a2-9783-98788907bfa6", IsDeleted = false, UnitType = Unit.Ml, Name = "Cream" },
            new Ingredient() {Id = "faeb50b9-c23f-4cc3-b8ed-f41f8d19eb38", IsDeleted = false, UnitType = Unit.Ml, Name = "Milk" },
            new Ingredient() {Id = "bec1efc2-cfc4-4297-9353-e2d90cedbcfc", IsDeleted = false, UnitType = Unit.Ml, Name = "Pineapple Juice" },
            new Ingredient() {Id = "c6b27053-e9f4-4907-a618-81410763ef65", IsDeleted = false, UnitType = Unit.Ml, Name = "Coconut Cream" },
            new Ingredient() {Id = "2ca0b8ed-3d8f-4a91-a3b3-c55a4e947a56", IsDeleted = false, UnitType = Unit.Ml, Name = "Simple Syrup" },
            new Ingredient() {Id = "1f1fbb0a-35a5-4ae5-b17a-5a5e1393f674", IsDeleted = false, UnitType = Unit.Ml, Name = "Dark Rum" },
            new Ingredient() {Id = "e66d1721-8b0b-4d52-b71d-48a0e171ecfc", IsDeleted = false, UnitType = Unit.Ml, Name = "Sweet Vermouth" },
            new Ingredient() {Id = "f6b8ead2-9bcb-437f-a079-2270a628512e", IsDeleted = false, UnitType = Unit.Ml, Name = "Dry Vermouth" },
            new Ingredient() {Id = "26848428-7ed4-4aa7-96b0-75f72bf90285", IsDeleted = false, UnitType = Unit.Ml, Name = "Gomme Syrup" },
            new Ingredient() {Id = "dddb8073-93b0-43dc-889c-d83dd3c7ffe8", IsDeleted = false, UnitType = Unit.Ml, Name = "Amaretto" },
            new Ingredient() {Id = "b9ba6611-eeab-45ae-9b94-399c1ce2b541", IsDeleted = false, UnitType = Unit.Ml, Name = "Egg-White" },
            new Ingredient() {Id = "2ca497aa-5518-4282-9e17-eb976cbd9728", IsDeleted = false, UnitType = Unit.Ml, Name = "Bacardi Rum" },
            new Ingredient() {Id = "cda1210e-5bfd-4314-aa3a-359f37f8e3ea", IsDeleted = false, UnitType = Unit.Ml, Name = "Strawberry Liqueur" },
            new Ingredient() {Id = "f885192f-3a79-4109-aa1d-313d5ee2291a", IsDeleted = false, UnitType = Unit.Ml, Name = "Cream Liqueur" },
            new Ingredient() {Id = "f11fa0c5-0203-486b-9592-21f7aa58d6b2", IsDeleted = false, UnitType = Unit.Ml, Name = "Irish Cream Liqueur" },
        };

        private List<Bar> barSeeder = new List<Bar>()
        {
            new Bar() {Id = "56d9e733-b150-45c4-8b87-f5a5e31bc23b", Name = "Camino Piano Bar", Address = "Neofit Rilski 70 str.", PhoneNumber = "0899 121 219", PicUrl = "https://www.bar.bg/img/entities/391/thumbnails/1460717284_thumbnail_piano%20Bar%20Camino%20Sofia%20Bar.bg%20%20%286%29.jpg", Motto = "Here’s to what I won’t remember." },

            new Bar() {Id = "cdb2058c-0600-497d-b48d-f89d8cb4aaed", Name = "Motto", Address = "Aksakov 18 str.", PhoneNumber = "02 987 27 23", PicUrl = "https://www.bar.bg/img/entities/344/thumbnails/1460948353_thumbnail_Motto%20Sofia%20bar%20and%20dinner%20%289%29.jpg", Motto = "It’s not just a bar, it’s a destination!"},

            new Bar() {Id = "6e1ce019-108e-4ded-b308-486831d19e08", Name = "Magnito", Address = "Lege 8 str.", PhoneNumber = "0888 144 777",PicUrl = "https://www.bar.bg/img/entities/334/12.jpg", Motto = "Keep Calm and Party On." },

            new Bar() {Id = "d886baac-17e6-49dd-93ec-b5ecadc14e06", Name = "Tobacco Garden Bar", Address = "Moskovska 6A str.", PhoneNumber = "0884 600 044", PicUrl = "https://www.bar.bg/img/entities/399/thumbnails/1465627827_thumbnail_Tobacco%20by%20night%20%281%29.jpg", Motto = "Less thinking more drinking."},

            new Bar() {Id = "648ba3bd-70ae-4277-aa40-2da5ab120fa9", Name = "The Corner", Address = "Nikola Vaptsarov 35 bul", PhoneNumber = "0884 555 444", PicUrl = "https://www.bar.bg/img/entities/301/thumbnails/1465991940_thumbnail_The%20corner%20sofia%20%285%29.JPG", Motto = "Old school bar for the modern man."},

            new Bar() {Id = "0086952e-e33e-4daa-a678-d715afb9ce92", Name = "After Five", Address = "Malko Tarnovo 1 str.", PhoneNumber = "0889 044 124", PicUrl = "https://www.bar.bg/img/entities/514/thumbnails/1542282996_thumbnail_45587111_10155553340756402_8161139793200152576_o.jpg", Motto = "Shut up and drink."},

            new Bar() {Id = "2600172c-9d3e-4143-850e-aeb80e2a1276", Name = "Ginger", Address = "Bitolya 2 str.", PhoneNumber = "087 733 7337", PicUrl = "https://www.bar.bg/img/entities/309/thumbnails/1543487164_thumbnail_46508867_945234368933866_6411033979784265728_o.jpg", Motto = "The luck is gone, the brain is shot, but the liquor we still got."},

            new Bar() {Id = "b14aaaf8-5cf8-4c3d-b082-e18afa02f563", Name = "Sinatra", Address = "Vitosha 16 str.", PhoneNumber = "087 676 7647", PicUrl = "https://scontent.fsof10-1.fna.fbcdn.net/v/t1.0-9/69596049_2511881822225915_3748776760234213376_o.jpg?_nc_cat=106&_nc_ohc=tXMpZ5pg5EsAQm6ITiX6rG7SzNUjVkk6VofwaXC1Qg2DMgADPB9ShY55Q&_nc_ht=scontent.fsof10-1.fna&oh=5481adeb4d42c82c2e7e31e9fd8e0180&oe=5E8147BB", Motto = "The problem with the world is that everyone is a few drinks behind."},

            new Bar() {Id = "5182e54c-ed6f-487f-b205-75649ef9ea2e", Name = "Cache", Address = "Arsenalski 2 bul.", PhoneNumber = "089 446 4169", PicUrl = "https://www.bar.bg/img/entities/392/thumbnails/1460819224_thumbnail_Bar%20Cache%20Sofia%20opening%20%281%29.jpg", Motto = "Hiding from wife."},

            new Bar() {Id = "091bf67e-532c-498e-9a40-5f625ccee2e2", Name = "Public Bar", Address = "Angel Kanchev 1 str.", PhoneNumber = "088 433 3781", PicUrl = "https://www.bar.bg/img/entities/443/thumbnails/1495192251_thumbnail_public%20bar%20sofia%20special%20moments%20%283%29.jpg", Motto = "What happens at the reception stays at the reception."}
        };

        public DbSet<BarComment> BarComments { get; set; }
        public DbSet<BarRating> BarRatings { get; set; }
        public DbSet<CocktailComment> CocktailComments { get; set; }
        public DbSet<CocktailRating> CocktailRatings { get; set; }

        public DbSet<Bar> Bars { get; set; }
        public DbSet<Cocktail> Cocktails { get; set; }
        public DbSet<CocktailBar> CocktailBars { get; set; }
        public DbSet<CocktailIngredient> CocktailIngredients { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        //public DbSet<Comment> Comments { get; set; }
        //public DbSet<Rating> Ratings { get; set; }

        public IriOnCocktailServiceDbContext(DbContextOptions<IriOnCocktailServiceDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // User
            builder.Entity<User>()
                .HasKey(user => user.Id);

            builder.Entity<User>()
                .HasMany(user => user.BarComments)
                .WithOne(comment => comment.User);

            builder.Entity<User>()
                .HasMany(user => user.BarRatings)
                .WithOne(rating => rating.User);

            // Bar
            builder.Entity<Bar>()
                .HasData(barSeeder);

            builder.Entity<Bar>()
                .HasKey(bar => bar.Id);

            builder.Entity<Bar>()
                .Property(bar => bar.Name)
                .IsRequired();

            // TODO IsUnique attribute 
            builder.Entity<Bar>()
                .Property(bar => bar.Address)
                .IsRequired();

            builder.Entity<Bar>()
                .Property(bar => bar.PicUrl)
                .IsRequired();

            builder.Entity<Bar>()
                .HasMany(bar => bar.BarComments)
                .WithOne(comment => comment.Bar)
                .HasForeignKey(comment => comment.BarId);

            builder.Entity<BarRating>()
                .HasKey(br => new { br.UserId, br.BarId });

            builder.Entity<CocktailRating>()
                .HasKey(br => new { br.UserId, br.CocktailId });
            //builder.Entity<Bar>()
            //    .HasMany(bar => bar.BarRatings)
            //    .WithOne(rating => rating.Bar)
            //    .HasForeignKey(rating => rating.BarId);

            // Cocktail
            builder.Entity<Cocktail>()
                .HasKey(cocktail => cocktail.Id);

            builder.Entity<Cocktail>()
                .HasData(cocktailSeeder);

            builder.Entity<Cocktail>()
                .Property(cocktail => cocktail.Name)
                .IsRequired();

            builder.Entity<Cocktail>()
                .Property(cocktail => cocktail.PicUrl)
                .IsRequired();

            builder.Entity<Cocktail>()
                .HasMany(bar => bar.Comments)
                .WithOne(comment => comment.Cocktail)
                .HasForeignKey(comment => comment.CocktailId);

            builder.Entity<Cocktail>()
                .HasMany(bar => bar.Ratings)
                .WithOne(rating => rating.Cocktail)
                .HasForeignKey(rating => rating.CocktailId);

            // CocktailBar
            builder.Entity<CocktailBar>()
                .HasKey(cocktailBar => new { cocktailBar.CocktailId, cocktailBar.BarId });

            builder.Entity<CocktailBar>()
                .HasOne(cocktailBar => cocktailBar.Cocktail)
                .WithMany(cocktail => cocktail.CocktailBars)
                .HasForeignKey(cocktailBar => cocktailBar.CocktailId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CocktailBar>()
                .HasOne(cocktailBar => cocktailBar.Bar)
                .WithMany(bar => bar.CocktailBars)
                .HasForeignKey(cocktailBar => cocktailBar.BarId)
                .OnDelete(DeleteBehavior.Restrict);

            // Ingredient
            builder.Entity<Ingredient>()
                .HasData(ingredientSeeder);

            builder.Entity<Ingredient>()
                .HasKey(ingredient => ingredient.Id);

            builder.Entity<Ingredient>()
                .Property(ingredient => ingredient.Name)
                .IsRequired();

            builder.Entity<Ingredient>()
                .Property(ingredient => ingredient.UnitType)
                .IsRequired();

            // CocktailIngredient
            builder.Entity<CocktailIngredient>()
                .HasKey(cocktailIngredient => new { cocktailIngredient.CocktailId, cocktailIngredient.IngredientId });

            builder.Entity<CocktailIngredient>()
                .HasData(cocktailIngredientSeeder);

            builder.Entity<CocktailIngredient>()
                .Property(cocktailIngredient => cocktailIngredient.Quantity)
                .IsRequired();

            builder.Entity<CocktailIngredient>()
                .HasOne(cocktailIngredient => cocktailIngredient.Cocktail)
                .WithMany(cocktail => cocktail.CocktailIngredients)
                .HasForeignKey(cocktailIngredient => cocktailIngredient.CocktailId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CocktailIngredient>()
                .HasOne(cocktailIngredient => cocktailIngredient.Ingredient)
                .WithMany(ingredient => ingredient.CocktailIngredients)
                .HasForeignKey(cocktailIngredient => cocktailIngredient.IngredientId)
                .OnDelete(DeleteBehavior.Restrict);

            // BarRating
            builder.Entity<BarRating>()
                .Property(br => br.Rate)
                .HasColumnType("decimal(18,2)");

            // CocktailRating
            builder.Entity<CocktailRating>()
                .Property(cr => cr.Rate)
                .HasColumnType("decimal(18,2)");
        }
    }
}
