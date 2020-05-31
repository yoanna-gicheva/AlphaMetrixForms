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

namespace AlphaMetrix.Services.Tests.FormServiceTests
{
    [TestClass]
    public class GetFormAsync_Should
    {
        [TestMethod]
        public async Task GetForm_If_ParamsAreValid()
        {
            var options = TestUtils.GetOptions(nameof(GetForm_If_ParamsAreValid));
            var mockTextQuestionService = new Mock<ITextQuestionService>();
            var mockOptionQuestionService = new Mock<IOptionQuestionService>();
            var mockDocumentQuestionService = new Mock<IDocumentQuestionService>();

            var user = new User
            {
                Id = Guid.Parse("e0ee6692-93cd-4018-a566-e0ac127c6901"),
                UserName = "TestUser"
            };

            var form = new Form
            {
                Id = Guid.Parse("b9b317d8-fff2-462a-b3de-3099e8110f6d"),
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
                var sut = new FormService(assertContext, mockTextQuestionService.Object, mockOptionQuestionService.Object, mockDocumentQuestionService.Object);
                var formDTO = await sut.GetFormAsync(form.Id);

                Assert.AreEqual(form.Title, formDTO.Title);
                Assert.AreEqual(form.Id, formDTO.Id);
            }
        }

        [TestMethod]
        public async Task FailToGetForm_If_FormNotExist()
        {
            var options = TestUtils.GetOptions(nameof(FailToGetForm_If_FormNotExist));
            var mockTextQuestionService = new Mock<ITextQuestionService>();
            var mockOptionQuestionService = new Mock<IOptionQuestionService>();
            var mockDocumentQuestionService = new Mock<IDocumentQuestionService>();

            Guid randomGuid = Guid.Parse("9795a980-65bf-41be-b051-764265cec71e");

            using (var assertContext = new FormsContext(options))
            {
                var sut = new FormService(assertContext, mockTextQuestionService.Object, mockOptionQuestionService.Object, mockDocumentQuestionService.Object);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.GetFormAsync(randomGuid));
            }
        }

    }
}
