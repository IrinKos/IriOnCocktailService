﻿// <auto-generated />
using System;
using IriOnCocktailService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IriOnCocktailService.Data.Migrations
{
    [DbContext(typeof(IriOnCocktailServiceDbContext))]
    partial class IriOnCocktailServiceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IriOnCocktailService.Data.Entities.Bar", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<bool>("NotAvailable");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PicUrl");

                    b.HasKey("Id");

                    b.ToTable("Bars");

                    b.HasData(
                        new
                        {
                            Id = "56d9e733-b150-45c4-8b87-f5a5e31bc23b",
                            Address = "Neofit Rilski 70 str.",
                            Name = "Camino Piano Bar",
                            NotAvailable = false,
                            PhoneNumber = "0899 121 219",
                            PicUrl = "https://www.bar.bg/img/entities/391/1460717100_200_piano-bar-Camino-sofia-215-x-130.jpg"
                        },
                        new
                        {
                            Id = "cdb2058c-0600-497d-b48d-f89d8cb4aaed",
                            Address = "Aksakov 18 str.",
                            Name = "Motto",
                            NotAvailable = false,
                            PhoneNumber = "02 987 27 23",
                            PicUrl = "https://www.bar.bg/img/entities/344/image344_thumb.jpg"
                        },
                        new
                        {
                            Id = "6e1ce019-108e-4ded-b308-486831d19e08",
                            Address = "Lege 8 str.",
                            Name = "Magnito",
                            NotAvailable = false,
                            PhoneNumber = "0888 144 777",
                            PicUrl = "https://www.bar.bg/img/entities/334/1505111472_200_magnito-sofia-215-x-130.png"
                        },
                        new
                        {
                            Id = "d886baac-17e6-49dd-93ec-b5ecadc14e06",
                            Address = "Moskovska 6A str.",
                            Name = "Tobacco Garden Bar",
                            NotAvailable = false,
                            PhoneNumber = "0884 600 044",
                            PicUrl = "https://www.bar.bg/img/entities/399/1465626692_200_Tobacco-garden-bar-sofia-215-x-130.png"
                        },
                        new
                        {
                            Id = "648ba3bd-70ae-4277-aa40-2da5ab120fa9",
                            Address = "Nikola Vaptsarov 35 bul",
                            Name = "The Corner",
                            NotAvailable = false,
                            PhoneNumber = "0884 555 444",
                            PicUrl = "https://www.bar.bg/img/entities/301/1509363711_200_LOGO_The-Corner-Sofia-2017---215-x-130.jpg"
                        },
                        new
                        {
                            Id = "0086952e-e33e-4daa-a678-d715afb9ce92",
                            Address = "Malko Tarnovo 1 str.",
                            Name = "After Five",
                            NotAvailable = false,
                            PhoneNumber = "0889 044 124",
                            PicUrl = "https://www.bar.bg/img/entities/514/1542282680_200_1-after%20five%20drink%20bar%20sofia%20215-x-130.jpg"
                        },
                        new
                        {
                            Id = "2600172c-9d3e-4143-850e-aeb80e2a1276",
                            Address = "Bitolya 2 str.",
                            Name = "Ginger",
                            NotAvailable = false,
                            PhoneNumber = "087 733 7337",
                            PicUrl = "https://www.bar.bg/img/entities/309/1542618320_200_1-ginger%20sofia%20215-x-130%20logo.png"
                        },
                        new
                        {
                            Id = "b14aaaf8-5cf8-4c3d-b082-e18afa02f563",
                            Address = "Vitosha 16 str.",
                            Name = "Sinatra",
                            NotAvailable = false,
                            PhoneNumber = "087 676 7647",
                            PicUrl = "https://www.bar.bg/img/entities/445/1495540391_200_Social-cafe-sofia-logo-215-x-130-jpeg.jpg"
                        },
                        new
                        {
                            Id = "5182e54c-ed6f-487f-b205-75649ef9ea2e",
                            Address = "Arsenalski 2 bul.",
                            Name = "Cache",
                            NotAvailable = false,
                            PhoneNumber = "089 446 4169",
                            PicUrl = "https://www.bar.bg/img/entities/392/1460818909_200_cache---215-x-130.jpg"
                        },
                        new
                        {
                            Id = "091bf67e-532c-498e-9a40-5f625ccee2e2",
                            Address = "Angel Kanchev 1 str.",
                            Name = "Public Bar",
                            NotAvailable = false,
                            PhoneNumber = "088 433 3781",
                            PicUrl = "https://www.bar.bg/img/entities/443/1495046748_200_public-bar-sofia--215-x-130.png"
                        });
                });

            modelBuilder.Entity("IriOnCocktailService.Data.Entities.BarComment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BarId");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BarId");

                    b.HasIndex("UserId");

                    b.ToTable("BarComments");
                });

            modelBuilder.Entity("IriOnCocktailService.Data.Entities.BarRating", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BarId");

                    b.Property<bool>("IsDeleted");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BarId");

                    b.HasIndex("UserId");

                    b.ToTable("BarRatings");
                });

            modelBuilder.Entity("IriOnCocktailService.Data.Entities.Cocktail", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<bool>("NotAvailable");

                    b.Property<string>("PicUrl");

                    b.HasKey("Id");

                    b.ToTable("Cocktails");
                });

            modelBuilder.Entity("IriOnCocktailService.Data.Entities.CocktailBar", b =>
                {
                    b.Property<string>("CocktailId");

                    b.Property<string>("BarId");

                    b.HasKey("CocktailId", "BarId");

                    b.HasIndex("BarId");

                    b.ToTable("CocktailBars");
                });

            modelBuilder.Entity("IriOnCocktailService.Data.Entities.CocktailComment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CocktailId");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CocktailId");

                    b.HasIndex("UserId");

                    b.ToTable("CocktailComments");
                });

            modelBuilder.Entity("IriOnCocktailService.Data.Entities.CocktailIngredient", b =>
                {
                    b.Property<string>("CocktailId");

                    b.Property<string>("IngredientId");

                    b.Property<string>("Quantity")
                        .IsRequired();

                    b.HasKey("CocktailId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("CocktailIngredients");
                });

            modelBuilder.Entity("IriOnCocktailService.Data.Entities.CocktailRating", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CocktailId");

                    b.Property<bool>("IsDeleted");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CocktailId");

                    b.HasIndex("UserId");

                    b.ToTable("CocktailRatings");
                });

            modelBuilder.Entity("IriOnCocktailService.Data.Entities.Ingredient", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("UnitType");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = "0af163c4-6210-4b51-9032-8cadf025083e",
                            IsDeleted = false,
                            Name = "Ground black pepper",
                            UnitType = 2
                        },
                        new
                        {
                            Id = "b46b8769-53d2-4aff-b538-f99948962172",
                            IsDeleted = false,
                            Name = "Tomato Juice",
                            UnitType = 1
                        },
                        new
                        {
                            Id = "514afb68-79a8-4deb-bd9c-9d9c61afc1cb",
                            IsDeleted = false,
                            Name = "Hot sauce",
                            UnitType = 1
                        },
                        new
                        {
                            Id = "7aab7c85-626f-4509-a357-56050fbe66e4",
                            IsDeleted = false,
                            Name = "Worcestershire sauce",
                            UnitType = 1
                        },
                        new
                        {
                            Id = "e045e88a-0151-4394-bd23-62622f3335ff",
                            IsDeleted = false,
                            Name = "Lemon juice",
                            UnitType = 1
                        },
                        new
                        {
                            Id = "8a26e862-811d-4053-bb2d-59587bb48188",
                            IsDeleted = false,
                            Name = "Gin Bombay Sapphire",
                            UnitType = 1
                        },
                        new
                        {
                            Id = "6c9dea74-cb47-4d4a-81ec-c21b1aec70ee",
                            IsDeleted = false,
                            Name = "Martini ",
                            UnitType = 1
                        },
                        new
                        {
                            Id = "dcb14d4d-6329-4641-bdd1-b02b7174ddcf",
                            IsDeleted = false,
                            Name = "Vodka",
                            UnitType = 1
                        },
                        new
                        {
                            Id = "2a34f05b-192a-46be-986a-3f23afa66a65",
                            IsDeleted = false,
                            Name = "Tequila",
                            UnitType = 1
                        },
                        new
                        {
                            Id = "cf9db0c7-b266-4238-9b14-2e0b89cda8ef",
                            IsDeleted = false,
                            Name = "Gin",
                            UnitType = 1
                        },
                        new
                        {
                            Id = "9dc9533e-6aa5-4483-8613-e7160a17547d",
                            IsDeleted = false,
                            Name = "Tonik",
                            UnitType = 1
                        },
                        new
                        {
                            Id = "f99c65e7-fb0b-4723-a3d5-8ac05a8ba1e4",
                            IsDeleted = false,
                            Name = "CocaCola",
                            UnitType = 1
                        },
                        new
                        {
                            Id = "a69c54ff-8e93-4181-8998-b4de42304075",
                            IsDeleted = false,
                            Name = "Soda",
                            UnitType = 1
                        },
                        new
                        {
                            Id = "6fe3620d-87be-4773-90c1-d0a072f0c838",
                            IsDeleted = false,
                            Name = "Wiskey",
                            UnitType = 1
                        },
                        new
                        {
                            Id = "b96ae8b3-7fad-406c-97d2-bc5e6dcc0d8c",
                            IsDeleted = false,
                            Name = "Red Bull",
                            UnitType = 1
                        },
                        new
                        {
                            Id = "07ee6b8c-8986-4886-bbfd-cdca6e52a5df",
                            IsDeleted = false,
                            Name = "Water",
                            UnitType = 1
                        },
                        new
                        {
                            Id = "d82e5701-27e5-45a2-955d-01d1071fce02",
                            IsDeleted = false,
                            Name = "Banana Juice",
                            UnitType = 1
                        },
                        new
                        {
                            Id = "44ebac14-88ca-404f-87e6-ee0f3d3c180e",
                            IsDeleted = false,
                            Name = "Orange Juice",
                            UnitType = 1
                        },
                        new
                        {
                            Id = "3fea7311-64e6-4325-af27-28cb41a5cf2c",
                            IsDeleted = false,
                            Name = "Salt",
                            UnitType = 3
                        },
                        new
                        {
                            Id = "6852531d-f7ca-4c05-8b02-019a3ac53737",
                            IsDeleted = false,
                            Name = "Cinnamon",
                            UnitType = 3
                        },
                        new
                        {
                            Id = "00b7970b-96e4-49ee-97c0-896871d4bd9f",
                            IsDeleted = false,
                            Name = "Ice",
                            UnitType = 2
                        },
                        new
                        {
                            Id = "6e3634b2-518f-40e2-ac20-1bf56297364a",
                            IsDeleted = false,
                            Name = "Olive",
                            UnitType = 2
                        });
                });

            modelBuilder.Entity("IriOnCocktailService.Data.Entities.Rating", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BarId");

                    b.Property<string>("CocktailId");

                    b.Property<bool>("IsDeleted");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BarId");

                    b.HasIndex("CocktailId");

                    b.HasIndex("UserId");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("IriOnCocktailService.Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("RoleId");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("IriOnCocktailService.Data.Entities.BarComment", b =>
                {
                    b.HasOne("IriOnCocktailService.Data.Entities.Bar", "Bar")
                        .WithMany("BarComments")
                        .HasForeignKey("BarId");

                    b.HasOne("IriOnCocktailService.Data.Entities.User", "User")
                        .WithMany("BarComments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("IriOnCocktailService.Data.Entities.BarRating", b =>
                {
                    b.HasOne("IriOnCocktailService.Data.Entities.Bar", "Bar")
                        .WithMany("BarRatings")
                        .HasForeignKey("BarId");

                    b.HasOne("IriOnCocktailService.Data.Entities.User", "User")
                        .WithMany("BarRatings")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("IriOnCocktailService.Data.Entities.CocktailBar", b =>
                {
                    b.HasOne("IriOnCocktailService.Data.Entities.Bar", "Bar")
                        .WithMany("CocktailBars")
                        .HasForeignKey("BarId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IriOnCocktailService.Data.Entities.Cocktail", "Cocktail")
                        .WithMany("CocktailBars")
                        .HasForeignKey("CocktailId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("IriOnCocktailService.Data.Entities.CocktailComment", b =>
                {
                    b.HasOne("IriOnCocktailService.Data.Entities.Cocktail", "Cocktail")
                        .WithMany("Comments")
                        .HasForeignKey("CocktailId");

                    b.HasOne("IriOnCocktailService.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("IriOnCocktailService.Data.Entities.CocktailIngredient", b =>
                {
                    b.HasOne("IriOnCocktailService.Data.Entities.Cocktail", "Cocktail")
                        .WithMany("CocktailIngredients")
                        .HasForeignKey("CocktailId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IriOnCocktailService.Data.Entities.Ingredient", "Ingredient")
                        .WithMany("CocktailIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("IriOnCocktailService.Data.Entities.CocktailRating", b =>
                {
                    b.HasOne("IriOnCocktailService.Data.Entities.Cocktail", "Cocktail")
                        .WithMany("Ratings")
                        .HasForeignKey("CocktailId");

                    b.HasOne("IriOnCocktailService.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("IriOnCocktailService.Data.Entities.Rating", b =>
                {
                    b.HasOne("IriOnCocktailService.Data.Entities.Bar", "Bar")
                        .WithMany()
                        .HasForeignKey("BarId");

                    b.HasOne("IriOnCocktailService.Data.Entities.Cocktail", "Cocktail")
                        .WithMany()
                        .HasForeignKey("CocktailId");

                    b.HasOne("IriOnCocktailService.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("IriOnCocktailService.Data.Entities.User", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("IriOnCocktailService.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("IriOnCocktailService.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IriOnCocktailService.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("IriOnCocktailService.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
