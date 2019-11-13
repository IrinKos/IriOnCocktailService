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

                    b.Property<decimal>("Rate");

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

                    b.Property<decimal>("Rate");

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
