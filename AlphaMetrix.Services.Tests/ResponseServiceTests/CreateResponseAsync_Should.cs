using AlphaMetrixForms.Data.Context;
using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Services.Contracts;
using AlphaMetrixForms.Services.DTOs;
using AlphaMetrixForms.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMetrix.Services.Tests.ResponseServiceTests
{
    [TestClass]
    public class CreateResponseAsync_Should
    {
        [TestMethod]
        public async Task CreateResponse_If_ParamsAreValid()
        {
            var options = TestUtils.GetOptions(nameof(CreateResponse_If_ParamsAreValid));

            var user = new User
            {
                Id = Guid.Parse("e0ee6692-93cd-4018-a566-e0ac127c6901"),
                UserName = "TestUser",
                Email = "testmail@testmail.testmail"
            };

            var form = new Form
            {
                Id = Guid.Parse("a0e8b7cb-f75f-41c5-aec5-6ee82ebd665e"),
                Title = "TestTitle",
                Description = "TestDescription",
                OwnerId = Guid.Parse("e0ee6692-93cd-4018-a566-e0ac127c6901")
            };

            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Users.AddAsync(user);
                await arrangeContext.Forms.AddAsync(form);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new ResponseService(assertContext);
                var responseId = await sut.CreateResponseAsync(form.Id);
                var result = await assertContext.Responses.Where(x => x.FormId==form.Id).FirstOrDefaultAsync();

                Assert.AreEqual(responseId, result.Id);
            }
        }

        [TestMethod]
        public async Task FailToCreateResponse_If_FormNotExist()
        {
            var options = TestUtils.GetOptions(nameof(FailToCreateResponse_If_FormNotExist));

            Guid randomGuid = Guid.Parse("9795a980-65bf-41be-b051-764265cec71e");

            using (var assertContext = new FormsContext(options))
            {
                var sut = new ResponseService(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.CreateResponseAsync(randomGuid));
            }
        }

    }
}
