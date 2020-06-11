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
    public class RetrieveResponseForFormAsync_Should
    {
        [TestMethod]
        public async Task RetreiveResponseForForm_If_ParamsAreValid()
        {
            var options = TestUtils.GetOptions(nameof(RetreiveResponseForForm_If_ParamsAreValid));

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

            var response = new Response
            {
                Id = Guid.Parse("9d5a328e-05d8-47f7-aefc-24394e5fbd77"),
                FormId = Guid.Parse("a0e8b7cb-f75f-41c5-aec5-6ee82ebd665e")
            };

            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Users.AddAsync(user);
                await arrangeContext.Forms.AddAsync(form);
                await arrangeContext.Responses.AddAsync(response);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new ResponseService(assertContext);
                var responseDTO = await sut.RetrieveResponseForFormAsync(form.Id);

                Assert.AreEqual(responseDTO.Title, form.Title);
                Assert.AreEqual(responseDTO.Id, form.Id);
            }
        }

        [TestMethod]
        public async Task FailToRetreiveResponseForForm_If_FormNotExist()
        {
            var options = TestUtils.GetOptions(nameof(FailToRetreiveResponseForForm_If_FormNotExist));

            Guid randomGuid = Guid.Parse("9795a980-65bf-41be-b051-764265cec71e");

            using (var assertContext = new FormsContext(options))
            {
                var sut = new ResponseService(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.RetrieveResponseForFormAsync(randomGuid));
            }
        }

    }
}
