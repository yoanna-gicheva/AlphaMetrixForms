using AlphaMetrixForms.Data.Context;
using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Services.DTOs;
using AlphaMetrixForms.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMetrix.Services.Tests.FormServiceTests
{
    [TestClass]
    public class CreateFormAsync_Should
    {
        [TestMethod]
        public async Task CreateForm_If_ParamsAreValid()
        {
            var options = TestUtils.GetOptions(nameof(CreateForm_If_ParamsAreValid));

            var user = new User
            {
                Id = Guid.Parse("e0ee6692-93cd-4018-a566-e0ac127c6901"),
                UserName = "TestUser"
            };

            var formDTO = new FormDTO
            {
                Title = "TestTitle",
                Description = "TestDescription",
                OwnerId = Guid.Parse("e0ee6692-93cd-4018-a566-e0ac127c6901")
            };

            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Users.AddAsync(user);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new FormService(assertContext);
                var resultDTO = await sut.CreateFormAsync(formDTO,user.Id);
                var result = await assertContext.Forms.Where(x => x.Title == "TestTitle").FirstOrDefaultAsync();

                Assert.AreEqual(user.Id, result.OwnerId);
                Assert.AreEqual("TestTitle", result.Title);
                Assert.AreEqual("TestDescription", result.Description);
            }
        }
    }
}
