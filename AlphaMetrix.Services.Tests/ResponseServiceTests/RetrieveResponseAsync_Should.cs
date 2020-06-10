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
    public class RetrieveResponseAsync_Should
    {
        [TestMethod]
        public async Task RetreiveResponse_If_ParamsAreValid()
        {
            var options = TestUtils.GetOptions(nameof(RetreiveResponse_If_ParamsAreValid));

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
                var formDTO = await sut.RetrieveResponseAsync(response.Id, form.Id);

                Assert.AreEqual(formDTO.Title, form.Title);
                Assert.AreEqual(formDTO.Id, form.Id);
            }
        }

    }
}
