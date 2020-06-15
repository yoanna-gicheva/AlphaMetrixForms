using AlphaMetrixForms.Data.Context;
using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Services.DTOs;
using AlphaMetrixForms.Services.Providers;
using AlphaMetrixForms.Services.Providers.Contracts;
using AlphaMetrixForms.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMetrix.Services.Tests.DocumentQuestionServiceTests
{
    [TestClass]
    public class UpdateDocumentQuestionAsync_Should
    {

        IBlobProvider blob = new BlobProvider();

        [TestMethod]
        public async Task UpdateDocumentQuestion_If_ParamsAreValid()
        {
            var options = TestUtils.GetOptions(nameof(UpdateDocumentQuestion_If_ParamsAreValid));

            var form = new Form
            {
                Id = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
                Title = "TestTitle",
                Description = "TestDescription",
            };

            var documentQuestion = new DocumentQuestion
            {
                Id = Guid.Parse("2c6f2674-aee7-47a5-ab70-fb30416af3e3"),
                Text = "Q1",
                FileNumberLimit = 1,
                FileSizeLimit = 1,
                IsRequired = false,
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518")
            };

            var documentQuestionUpdate = new DocumentQuestionDTO
            {
                Id = Guid.Parse("2c6f2674-aee7-47a5-ab70-fb30416af3e3"),
                Text = "Q2",
                FileNumberLimit = 10,
                FileSizeLimit = 10,
                IsRequired = true,
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518")
            };

            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Forms.AddAsync(form);
                await arrangeContext.DocumentQuestions.AddAsync(documentQuestion);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new DocumentQuestionService(assertContext, blob);
                var resultDTO = await sut.UpdateDocumentQuestionAsync(documentQuestion.Id, documentQuestionUpdate);
                var result = await assertContext.DocumentQuestions.Where(x => x.Id == documentQuestion.Id).FirstOrDefaultAsync();

                Assert.AreEqual(documentQuestionUpdate.Text, result.Text);
                Assert.AreEqual(documentQuestionUpdate.IsRequired, result.IsRequired);
                Assert.AreEqual(documentQuestionUpdate.FileNumberLimit, result.FileNumberLimit);
                Assert.AreEqual(documentQuestionUpdate.FileSizeLimit, result.FileSizeLimit);
            }
        }

        [TestMethod]
        public async Task FailToUpdateDocumentQuestion_If_QuestionNotExist()
        {
            var options = TestUtils.GetOptions(nameof(FailToUpdateDocumentQuestion_If_QuestionNotExist));

            var documentQuestionUpdate = new DocumentQuestionDTO
            {
                Id = Guid.Parse("2c6f2674-aee7-47a5-ab70-fb30416af3e3"),
                Text = "Q2",
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518")
            };

            using (var assertContext = new FormsContext(options))
            {
                var sut = new DocumentQuestionService(assertContext, blob);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.UpdateDocumentQuestionAsync(documentQuestionUpdate.Id, documentQuestionUpdate));
            }
        }
    }

}
