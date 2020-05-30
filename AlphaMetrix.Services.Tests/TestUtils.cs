using AlphaMetrixForms.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlphaMetrix.Services.Tests
{
    public static class TestUtils
    {
        public static DbContextOptions<FormsContext> GetOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<FormsContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
        }
    }
}
