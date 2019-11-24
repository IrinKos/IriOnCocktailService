using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IriOnCocktailService.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bars",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PicUrl = table.Column<string>(nullable: false),
                    NotAvailable = table.Column<bool>(nullable: false),
                    Motto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cocktails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PicUrl = table.Column<string>(nullable: false),
                    NotAvailable = table.Column<bool>(nullable: false),
                    Motto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cocktails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    UnitType = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    RoleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CocktailBars",
                columns: table => new
                {
                    CocktailId = table.Column<string>(nullable: false),
                    BarId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocktailBars", x => new { x.CocktailId, x.BarId });
                    table.ForeignKey(
                        name: "FK_CocktailBars_Bars_BarId",
                        column: x => x.BarId,
                        principalTable: "Bars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CocktailBars_Cocktails_CocktailId",
                        column: x => x.CocktailId,
                        principalTable: "Cocktails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CocktailIngredients",
                columns: table => new
                {
                    CocktailId = table.Column<string>(nullable: false),
                    IngredientId = table.Column<string>(nullable: false),
                    Quantity = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocktailIngredients", x => new { x.CocktailId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_CocktailIngredients_Cocktails_CocktailId",
                        column: x => x.CocktailId,
                        principalTable: "Cocktails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CocktailIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BarComments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    BarId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarComments_Bars_BarId",
                        column: x => x.BarId,
                        principalTable: "Bars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BarComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BarRatings",
                columns: table => new
                {
                    BarId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarRatings", x => new { x.UserId, x.BarId });
                    table.ForeignKey(
                        name: "FK_BarRatings_Bars_BarId",
                        column: x => x.BarId,
                        principalTable: "Bars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarRatings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CocktailComments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CocktailId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocktailComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CocktailComments_Cocktails_CocktailId",
                        column: x => x.CocktailId,
                        principalTable: "Cocktails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CocktailComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CocktailRatings",
                columns: table => new
                {
                    CocktailId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocktailRatings", x => new { x.UserId, x.CocktailId });
                    table.ForeignKey(
                        name: "FK_CocktailRatings_Cocktails_CocktailId",
                        column: x => x.CocktailId,
                        principalTable: "Cocktails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CocktailRatings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bars",
                columns: new[] { "Id", "Address", "Motto", "Name", "NotAvailable", "PhoneNumber", "PicUrl" },
                values: new object[,]
                {
                    { "56d9e733-b150-45c4-8b87-f5a5e31bc23b", "Neofit Rilski 70 str.", "Here’s to what I won’t remember.", "Camino Piano Bar", false, "0899 121 219", "https://www.bar.bg/img/entities/391/thumbnails/1460717284_thumbnail_piano%20Bar%20Camino%20Sofia%20Bar.bg%20%20%286%29.jpg" },
                    { "cdb2058c-0600-497d-b48d-f89d8cb4aaed", "Aksakov 18 str.", "It’s not just a bar, it’s a destination!", "Motto", false, "02 987 27 23", "https://www.bar.bg/img/entities/344/thumbnails/1460948353_thumbnail_Motto%20Sofia%20bar%20and%20dinner%20%289%29.jpg" },
                    { "6e1ce019-108e-4ded-b308-486831d19e08", "Lege 8 str.", "Keep Calm and Party On.", "Magnito", false, "0888 144 777", "https://www.bar.bg/img/entities/334/12.jpg" },
                    { "d886baac-17e6-49dd-93ec-b5ecadc14e06", "Moskovska 6A str.", "Less thinking more drinking.", "Tobacco Garden Bar", false, "0884 600 044", "https://www.bar.bg/img/entities/399/thumbnails/1465627827_thumbnail_Tobacco%20by%20night%20%281%29.jpg" },
                    { "648ba3bd-70ae-4277-aa40-2da5ab120fa9", "Nikola Vaptsarov 35 bul", "Old school bar for the modern man.", "The Corner", false, "0884 555 444", "https://www.bar.bg/img/entities/301/thumbnails/1465991940_thumbnail_The%20corner%20sofia%20%285%29.JPG" },
                    { "0086952e-e33e-4daa-a678-d715afb9ce92", "Malko Tarnovo 1 str.", "Shut up and drink.", "After Five", false, "0889 044 124", "https://www.bar.bg/img/entities/514/thumbnails/1542282996_thumbnail_45587111_10155553340756402_8161139793200152576_o.jpg" },
                    { "2600172c-9d3e-4143-850e-aeb80e2a1276", "Bitolya 2 str.", "The luck is gone, the brain is shot, but the liquor we still got.", "Ginger", false, "087 733 7337", "https://www.bar.bg/img/entities/309/thumbnails/1543487164_thumbnail_46508867_945234368933866_6411033979784265728_o.jpg" },
                    { "b14aaaf8-5cf8-4c3d-b082-e18afa02f563", "Vitosha 16 str.", "The problem with the world is that everyone is a few drinks behind.", "Sinatra", false, "087 676 7647", "https://scontent.fsof10-1.fna.fbcdn.net/v/t1.0-9/69596049_2511881822225915_3748776760234213376_o.jpg?_nc_cat=106&_nc_ohc=tXMpZ5pg5EsAQm6ITiX6rG7SzNUjVkk6VofwaXC1Qg2DMgADPB9ShY55Q&_nc_ht=scontent.fsof10-1.fna&oh=5481adeb4d42c82c2e7e31e9fd8e0180&oe=5E8147BB" },
                    { "5182e54c-ed6f-487f-b205-75649ef9ea2e", "Arsenalski 2 bul.", "Hiding from wife.", "Cache", false, "089 446 4169", "https://www.bar.bg/img/entities/392/thumbnails/1460819224_thumbnail_Bar%20Cache%20Sofia%20opening%20%281%29.jpg" },
                    { "091bf67e-532c-498e-9a40-5f625ccee2e2", "Angel Kanchev 1 str.", "What happens at the reception stays at the reception.", "Public Bar", false, "088 433 3781", "https://www.bar.bg/img/entities/443/thumbnails/1495192251_thumbnail_public%20bar%20sofia%20special%20moments%20%283%29.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "Id", "Motto", "Name", "NotAvailable", "PicUrl" },
                values: new object[,]
                {
                    { "4fae34e6-e1a1-462b-9e52-9e851079b41e", "In the 2006 movie \"Miami Vice\" lead character Crockett is seen drinking a Mojito from the bartender in the very first scene.", "Mojito", false, "https://www.thespruceeats.com/thmb/uph9GgtfGnN3rlLSEaP1WhYI2Ag=/1000x562/smart/filters:no_upscale()/mojito-5a8f339fba61770036ec61d8.jpg" },
                    { "aa0976da-4b5a-4b80-b7d0-c456c6be594d", "Some cocktail experts argue that rye whisky makes the best Manhattans, as opposed to Bourbon", "Manhattan", false, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQstaIovPmxlc5PnPTQ4n4P2kWnWv3ImmqiCSWKoswE5oSk2Nva&s" },
                    { "957de258-83ae-4314-a015-6014a3f312d5", "B-52 carries up to 70,000 pounds of weapons.", "B-52", false, "https://casaveneracion.com/wp-content/uploads/2010/09/absinthe-b55.jpg" },
                    { "42cd2509-9e0d-4451-b20b-4822931ac723", "The Cosmopolitan gained significant popularity in the 1990s partly due to the fact that Sarah Jessica Parkers character, Carrie Bradshaw, in the hit televsion programme, \"Sex in the City\", often ordered the drink.", "Cosmopolitan", false, "https://peopledotcom.files.wordpress.com/2018/02/unknown-12.jpeg" },
                    { "da9ef59d-7f71-4631-bda5-878e410c4e7f", "The White Russian is the favourite drink of Jeffrey \"The Dude\" Lebowski, the main character of the 1998 film, \"The Big Lebowski\".", "White Russian", false, "https://images2.minutemediacdn.com/image/upload/c_fill,g_auto,h_1248,w_2220/f_auto,q_auto,w_1100/v1555340239/shape/mentalfloss/istock_000065613079_small.jpg" },
                    { "77c8a1f5-66f6-4c5d-b06d-1ad0cdd1097d", "Coffee is the second most traded commodity on earth.", "Esspresso Martini", false, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRcI5X1cmG98KMGYLkMkls8vGbKLdBkSTJf8JsM6m9oMatX6TBI&s" },
                    { "11b8db86-d375-4cde-81c5-66be2938acdd", "Due to Roosevelt`s Good Neighbour policy (which opened up trade with Cuba, Latin America and the Carribean) rum became easily obtainable in the 1940S and this helped drive the popularity of the daiquiri in the US.", "Daiquiri", false, "https://www.thespruceeats.com/thmb/XmHuAIwiqm_YMOsF6lmFCswLYt4=/960x0/filters:no_upscale():max_bytes(150000):strip_icc()/hemingway-daiquiri-recipe-760527-Hero-5bbfa3c2c9e77c0052b8b7d2.jpg" },
                    { "26531c92-59cd-4503-86c9-17ab02d0e4c1", "H.L Mencken called the Martini \"the only American invention as perfect as the sonnet\".", "Dry Martini", false, "https://www.bascofinefoods.com/spanish-recipes-wpfiles/wp-content/uploads/2015/07/dry_martini_recipe-e1505646628151.jpg" },
                    { "ff98b546-3f4d-486c-acaf-6da5a2d1f4fc", "The name references the combinations age, as it is perhaps the first drink to be called a cocktail.", "Old Fashioned", false, "http://res.cloudinary.com/hjqklbxsu/image/upload/f_auto,fl_lossy,q_auto/v1536680101/social-share/JDSB_OldFashioned_DigitalRecipePost.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "IsDeleted", "Name", "UnitType" },
                values: new object[,]
                {
                    { "85ee0d01-72fe-4fea-a1e8-3a31471110cf", false, "Coffee Liqueur", 1 },
                    { "599b0c7d-2c10-431b-b986-296df0a888b5", false, "Mint Leaves", 1 },
                    { "d12faec1-8f1d-41b8-ab00-5aa9e8f9c7cb", false, "Lime Juice", 1 },
                    { "2a1498fb-00ce-4363-af6c-2ade242ce8bf", false, "Mint sprigs", 1 },
                    { "416809dc-3855-4bbf-8341-f3b4811d90bd", false, "Sugar", 3 },
                    { "e75bf641-54f4-474f-a7d7-3faaaf53759a", false, "Bourbon", 1 },
                    { "42252d46-40cc-48b5-b594-3a7ec63ba985", false, "Angostura Bitters", 1 },
                    { "7d2c7d7d-4836-4b7a-8806-874bfe63fabf", false, "Orange Bitters", 1 },
                    { "d6d57e51-bc61-4c4c-87cc-2a3cd7e440b5", false, "Citrus Vodka", 1 },
                    { "348b2dfc-9b80-4e6c-9709-e25a25195530", false, "Triple Sec", 1 },
                    { "a5d0b498-9470-4281-93f0-d38f3e456d8a", false, "Cranberry Juice", 1 },
                    { "1adb7444-06eb-42a2-9783-98788907bfa6", false, "Cream", 1 },
                    { "dddb8073-93b0-43dc-889c-d83dd3c7ffe8", false, "Amaretto", 1 },
                    { "bec1efc2-cfc4-4297-9353-e2d90cedbcfc", false, "Pineapple Juice", 1 },
                    { "c6b27053-e9f4-4907-a618-81410763ef65", false, "Coconut Cream", 1 },
                    { "2ca0b8ed-3d8f-4a91-a3b3-c55a4e947a56", false, "Simple Syrup", 1 },
                    { "1f1fbb0a-35a5-4ae5-b17a-5a5e1393f674", false, "Dark Rum", 1 },
                    { "e66d1721-8b0b-4d52-b71d-48a0e171ecfc", false, "Sweet Vermouth", 1 },
                    { "f6b8ead2-9bcb-437f-a079-2270a628512e", false, "Dry Vermouth", 1 },
                    { "26848428-7ed4-4aa7-96b0-75f72bf90285", false, "Gomme Syrup", 1 },
                    { "96d08841-a7ed-4eca-9f3f-72c2a777a167", false, "White rum", 1 },
                    { "b9ba6611-eeab-45ae-9b94-399c1ce2b541", false, "Egg-White", 1 },
                    { "2ca497aa-5518-4282-9e17-eb976cbd9728", false, "Bacardi Rum", 1 },
                    { "cda1210e-5bfd-4314-aa3a-359f37f8e3ea", false, "Strawberry Liqueur", 1 },
                    { "faeb50b9-c23f-4cc3-b8ed-f41f8d19eb38", false, "Milk", 1 },
                    { "3caa9be9-e557-40b6-a9fe-f31bdadcdb2f", false, "Coffee Beans", 2 },
                    { "44ebac14-88ca-404f-87e6-ee0f3d3c180e", false, "Orange Juice", 1 },
                    { "42304a2b-6806-4c5d-80a2-a2a50ae21b70", false, "Esspresso", 1 },
                    { "0af163c4-6210-4b51-9032-8cadf025083e", false, "Ground black pepper", 2 },
                    { "b46b8769-53d2-4aff-b538-f99948962172", false, "Tomato Juice", 1 },
                    { "514afb68-79a8-4deb-bd9c-9d9c61afc1cb", false, "Hot sauce", 1 },
                    { "7aab7c85-626f-4509-a357-56050fbe66e4", false, "Worcestershire sauce", 1 },
                    { "e045e88a-0151-4394-bd23-62622f3335ff", false, "Lemon juice", 1 },
                    { "8a26e862-811d-4053-bb2d-59587bb48188", false, "Gin Bombay Sapphire", 1 },
                    { "6c9dea74-cb47-4d4a-81ec-c21b1aec70ee", false, "Martini ", 1 },
                    { "dcb14d4d-6329-4641-bdd1-b02b7174ddcf", false, "Vodka", 1 },
                    { "2a34f05b-192a-46be-986a-3f23afa66a65", false, "Tequila", 1 },
                    { "cf9db0c7-b266-4238-9b14-2e0b89cda8ef", false, "Gin", 1 },
                    { "9dc9533e-6aa5-4483-8613-e7160a17547d", false, "Tonik", 1 },
                    { "7aff3750-c7bd-412b-b869-f28f3d44d046", false, "Sugar Syrop", 1 },
                    { "f99c65e7-fb0b-4723-a3d5-8ac05a8ba1e4", false, "CocaCola", 1 },
                    { "6fe3620d-87be-4773-90c1-d0a072f0c838", false, "Wiskey", 1 },
                    { "b96ae8b3-7fad-406c-97d2-bc5e6dcc0d8c", false, "Red Bull", 1 },
                    { "07ee6b8c-8986-4886-bbfd-cdca6e52a5df", false, "Water", 1 },
                    { "d82e5701-27e5-45a2-955d-01d1071fce02", false, "Banana Juice", 1 },
                    { "f885192f-3a79-4109-aa1d-313d5ee2291a", false, "Cream Liqueur", 1 },
                    { "3fea7311-64e6-4325-af27-28cb41a5cf2c", false, "Salt", 3 },
                    { "6852531d-f7ca-4c05-8b02-019a3ac53737", false, "Cinnamon", 3 },
                    { "00b7970b-96e4-49ee-97c0-896871d4bd9f", false, "Ice", 2 },
                    { "6e3634b2-518f-40e2-ac20-1bf56297364a", false, "Olive", 2 },
                    { "dff51835-fdd3-4695-9954-28da0435ac7a", false, "Vanila Vodka", 1 },
                    { "703d3be1-ce27-483b-ad61-130b5500d368", false, "Kahlua", 1 },
                    { "a69c54ff-8e93-4181-8998-b4de42304075", false, "Soda", 1 },
                    { "f11fa0c5-0203-486b-9592-21f7aa58d6b2", false, "Irish Cream Liqueur", 1 }
                });

            migrationBuilder.InsertData(
                table: "CocktailIngredients",
                columns: new[] { "CocktailId", "IngredientId", "Quantity" },
                values: new object[,]
                {
                    { "26531c92-59cd-4503-86c9-17ab02d0e4c1", "8a26e862-811d-4053-bb2d-59587bb48188", "60" },
                    { "aa0976da-4b5a-4b80-b7d0-c456c6be594d", "e66d1721-8b0b-4d52-b71d-48a0e171ecfc", "10" },
                    { "da9ef59d-7f71-4631-bda5-878e410c4e7f", "faeb50b9-c23f-4cc3-b8ed-f41f8d19eb38", "15" },
                    { "da9ef59d-7f71-4631-bda5-878e410c4e7f", "1adb7444-06eb-42a2-9783-98788907bfa6", "15" },
                    { "957de258-83ae-4314-a015-6014a3f312d5", "85ee0d01-72fe-4fea-a1e8-3a31471110cf", "10" },
                    { "da9ef59d-7f71-4631-bda5-878e410c4e7f", "85ee0d01-72fe-4fea-a1e8-3a31471110cf", "25" },
                    { "42cd2509-9e0d-4451-b20b-4822931ac723", "a5d0b498-9470-4281-93f0-d38f3e456d8a", "30" },
                    { "957de258-83ae-4314-a015-6014a3f312d5", "348b2dfc-9b80-4e6c-9709-e25a25195530", "10" },
                    { "42cd2509-9e0d-4451-b20b-4822931ac723", "348b2dfc-9b80-4e6c-9709-e25a25195530", "12 1/2" },
                    { "42cd2509-9e0d-4451-b20b-4822931ac723", "d6d57e51-bc61-4c4c-87cc-2a3cd7e440b5", "37 1/2" },
                    { "ff98b546-3f4d-486c-acaf-6da5a2d1f4fc", "7d2c7d7d-4836-4b7a-8806-874bfe63fabf", "1" },
                    { "aa0976da-4b5a-4b80-b7d0-c456c6be594d", "42252d46-40cc-48b5-b594-3a7ec63ba985", "2" },
                    { "ff98b546-3f4d-486c-acaf-6da5a2d1f4fc", "42252d46-40cc-48b5-b594-3a7ec63ba985", "1" },
                    { "aa0976da-4b5a-4b80-b7d0-c456c6be594d", "e75bf641-54f4-474f-a7d7-3faaaf53759a", "50" },
                    { "ff98b546-3f4d-486c-acaf-6da5a2d1f4fc", "e75bf641-54f4-474f-a7d7-3faaaf53759a", "50" },
                    { "ff98b546-3f4d-486c-acaf-6da5a2d1f4fc", "416809dc-3855-4bbf-8341-f3b4811d90bd", "5" },
                    { "11b8db86-d375-4cde-81c5-66be2938acdd", "416809dc-3855-4bbf-8341-f3b4811d90bd", "7.5" },
                    { "4fae34e6-e1a1-462b-9e52-9e851079b41e", "d12faec1-8f1d-41b8-ab00-5aa9e8f9c7cb", "25" },
                    { "26531c92-59cd-4503-86c9-17ab02d0e4c1", "6c9dea74-cb47-4d4a-81ec-c21b1aec70ee", "60" },
                    { "da9ef59d-7f71-4631-bda5-878e410c4e7f", "dcb14d4d-6329-4641-bdd1-b02b7174ddcf", "37 1/2" },
                    { "77c8a1f5-66f6-4c5d-b06d-1ad0cdd1097d", "dff51835-fdd3-4695-9954-28da0435ac7a", "37" },
                    { "77c8a1f5-66f6-4c5d-b06d-1ad0cdd1097d", "703d3be1-ce27-483b-ad61-130b5500d368", "12" },
                    { "77c8a1f5-66f6-4c5d-b06d-1ad0cdd1097d", "42304a2b-6806-4c5d-80a2-a2a50ae21b70", "30" },
                    { "77c8a1f5-66f6-4c5d-b06d-1ad0cdd1097d", "7aff3750-c7bd-412b-b869-f28f3d44d046", "12" },
                    { "aa0976da-4b5a-4b80-b7d0-c456c6be594d", "f6b8ead2-9bcb-437f-a079-2270a628512e", "10" },
                    { "42cd2509-9e0d-4451-b20b-4822931ac723", "7aff3750-c7bd-412b-b869-f28f3d44d046", "12 1/2" },
                    { "77c8a1f5-66f6-4c5d-b06d-1ad0cdd1097d", "3caa9be9-e557-40b6-a9fe-f31bdadcdb2f", "3" },
                    { "da9ef59d-7f71-4631-bda5-878e410c4e7f", "3caa9be9-e557-40b6-a9fe-f31bdadcdb2f", "1" },
                    { "11b8db86-d375-4cde-81c5-66be2938acdd", "96d08841-a7ed-4eca-9f3f-72c2a777a167", "50" },
                    { "4fae34e6-e1a1-462b-9e52-9e851079b41e", "96d08841-a7ed-4eca-9f3f-72c2a777a167", "50" },
                    { "4fae34e6-e1a1-462b-9e52-9e851079b41e", "599b0c7d-2c10-431b-b986-296df0a888b5", "8" },
                    { "11b8db86-d375-4cde-81c5-66be2938acdd", "d12faec1-8f1d-41b8-ab00-5aa9e8f9c7cb", "25" },
                    { "4fae34e6-e1a1-462b-9e52-9e851079b41e", "7aff3750-c7bd-412b-b869-f28f3d44d046", "10" },
                    { "957de258-83ae-4314-a015-6014a3f312d5", "f885192f-3a79-4109-aa1d-313d5ee2291a", "10" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_BarComments_BarId",
                table: "BarComments",
                column: "BarId");

            migrationBuilder.CreateIndex(
                name: "IX_BarComments_UserId",
                table: "BarComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BarRatings_BarId",
                table: "BarRatings",
                column: "BarId");

            migrationBuilder.CreateIndex(
                name: "IX_CocktailBars_BarId",
                table: "CocktailBars",
                column: "BarId");

            migrationBuilder.CreateIndex(
                name: "IX_CocktailComments_CocktailId",
                table: "CocktailComments",
                column: "CocktailId");

            migrationBuilder.CreateIndex(
                name: "IX_CocktailComments_UserId",
                table: "CocktailComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CocktailIngredients_IngredientId",
                table: "CocktailIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_CocktailRatings_CocktailId",
                table: "CocktailRatings",
                column: "CocktailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BarComments");

            migrationBuilder.DropTable(
                name: "BarRatings");

            migrationBuilder.DropTable(
                name: "CocktailBars");

            migrationBuilder.DropTable(
                name: "CocktailComments");

            migrationBuilder.DropTable(
                name: "CocktailIngredients");

            migrationBuilder.DropTable(
                name: "CocktailRatings");

            migrationBuilder.DropTable(
                name: "Bars");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Cocktails");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");
        }
    }
}
