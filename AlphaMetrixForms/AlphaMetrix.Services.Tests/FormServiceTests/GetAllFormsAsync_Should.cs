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
    public class GetAllFormsAsync_Should
    {
        [TestMethod]
        public async Task GetAllForms()
        {
            var options = TestUtils.GetOptions(nameof(GetAllForms));
            var mockTextQuestionService = new Mock<ITextQuestionService>();
            var mockOptionQuestionService = new Mock<IOptionQuestionService>();
            var mockDocumentQuestionService = new Mock<IDocumentQuestionService>();

            var user = new User
            {
                Id = Guid.Parse("e0ee6692-93cd-4018-a566-e0ac127c6901"),
                UserName = "TestUser"
            };

            var form1 = new Form
            {
                Title = "TestTitle1",
                Description = "TestDescription",
                OwnerId = Guid.Parse("e0ee6692-93cd-4018-a566-e0ac127c6901")
            };

            var form2 = new Form
            {
                Title = "TestTitle2",
                Description = "TestDescription",
                OwnerId = Guid.Parse("e0ee6692-93cd-4018-a566-e0ac127c6901")
            };

            var form3 = new Form
            {
                Title = "TestTitle3",
                Description = "TestDescription",
                OwnerId = Guid.Parse("e0ee6692-93cd-4018-a566-e0ac127c6901")
            };


            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Users.AddAsync(user);
                await arrangeContext.Forms.AddAsync(form1);
                await arrangeContext.Forms.AddAsync(form2);
                await arrangeContext.Forms.AddAsync(form3);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new FormService(assertContext, mockTextQuestionService.Object, mockOptionQuestionService.Object, mockDocumentQuestionService.Object);
                var resultDTOs = await sut.GetAllFormsAsync();
                var result = resultDTOs.Select(f => f.Title).ToList(); ;

                Assert.AreEqual(3, resultDTOs.Count);
                Assert.IsTrue(result.Contains("TestTitle1"));
                Assert.IsTrue(result.Contains("TestTitle2"));
                Assert.IsTrue(result.Contains("TestTitle3"));
            }
        }
    }
}

