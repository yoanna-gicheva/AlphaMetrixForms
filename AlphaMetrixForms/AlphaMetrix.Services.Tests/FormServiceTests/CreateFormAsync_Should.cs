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
    public class CreateFormAsync_Should
    {
        [TestMethod]
        public async Task CreateForm_If_ParamsAreValid()
        {
            var options = TestUtils.GetOptions(nameof(CreateForm_If_ParamsAreValid));
            var mockTextQuestionService = new Mock<ITextQuestionService>();
            var mockOptionQuestionService = new Mock<IOptionQuestionService>();
            var mockDocumentQuestionService = new Mock<IDocumentQuestionService>();

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
                var sut = new FormService(assertContext,mockTextQuestionService.Object,mockOptionQuestionService.Object,mockDocumentQuestionService.Object);
                var resultDTO = await sut.CreateFormAsync(formDTO,user.Id);
                var result = await assertContext.Forms.Where(x => x.Title == "TestTitle").FirstOrDefaultAsync();

                Assert.AreEqual(user.Id, result.OwnerId);
                Assert.AreEqual("TestTitle", result.Title);
                Assert.AreEqual("TestDescription", result.Description);
            }
        }

        [TestMethod]
        public async Task FailToCreateForm_If_OwnerNotExist()
        {
            var options = TestUtils.GetOptions(nameof(FailToCreateForm_If_OwnerNotExist));
            var mockTextQuestionService = new Mock<ITextQuestionService>();
            var mockOptionQuestionService = new Mock<IOptionQuestionService>();
            var mockDocumentQuestionService = new Mock<IDocumentQuestionService>();

            Guid randomGuid = Guid.Parse("9795a980-65bf-41be-b051-764265cec71e");

            var formDTO = new FormDTO
            {
                Title = "TestTitle",
                Description = "TestDescription",
                OwnerId = Guid.Parse("e0ee6692-93cd-4018-a566-e0ac127c6901")
            };

            using (var assertContext = new FormsContext(options))
            {
                var sut = new FormService(assertContext, mockTextQuestionService.Object, mockOptionQuestionService.Object, mockDocumentQuestionService.Object);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.CreateFormAsync(formDTO,randomGuid));
            }
        }

        [TestMethod]
        public async Task FailToCreateForm_If_FormHasNoTitle()
        {
            var options = TestUtils.GetOptions(nameof(FailToCreateForm_If_FormHasNoTitle));
            var mockTextQuestionService = new Mock<ITextQuestionService>();
            var mockOptionQuestionService = new Mock<IOptionQuestionService>();
            var mockDocumentQuestionService = new Mock<IDocumentQuestionService>();

            var user = new User
            {
                Id = Guid.Parse("e0ee6692-93cd-4018-a566-e0ac127c6901"),
                UserName = "TestUser"
            };

            var formDTO = new FormDTO
            {
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
                var sut = new FormService(assertContext, mockTextQuestionService.Object, mockOptionQuestionService.Object, mockDocumentQuestionService.Object);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.CreateFormAsync(formDTO, user.Id));
            }
        }
    }
}
