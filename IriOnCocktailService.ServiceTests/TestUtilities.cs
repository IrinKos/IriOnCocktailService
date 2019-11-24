using IriOnCocktailService.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.ServiceTests
{
    public static class TestUtilities
    {
        public static DbContextOptions<IriOnCocktailServiceDbContext> GetOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<IriOnCocktailServiceDbContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
        }
    }
}
