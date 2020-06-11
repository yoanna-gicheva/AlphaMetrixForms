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

namespace AlphaMetrix.Services.Tests.TextQuestionServiceTests
{
    [TestClass]
    public class UpdateTextQuestionAsync_Should
    {
        [TestMethod]
        public async Task UpdateTextQuestion_If_ParamsAreValid()
        {
            var options = TestUtils.GetOptions(nameof(UpdateTextQuestion_If_ParamsAreValid));

            var form = new Form
            {
                Id = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
                Title = "TestTitle",
                Description = "TestDescription",
            };

            var textQuestion = new TextQuestion
            {
                Id = Guid.Parse("2c6f2674-aee7-47a5-ab70-fb30416af3e3"),
                Text = "Q1",
                IsLongAnswer = true,
                IsRequired = false,
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518")
            };

            var textQuestionUpdate = new TextQuestionDTO
            {
                Id = Guid.Parse("2c6f2674-aee7-47a5-ab70-fb30416af3e3"),
                Text = "Q2",
                IsLongAnswer = false,
                IsRequired = true,
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518")
            };

            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Forms.AddAsync(form);
                await arrangeContext.TextQuestions.AddAsync(textQuestion);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new TextQuestionService(assertContext);
                var resultDTO = await sut.UpdateTextQuestionAsync(textQuestion.Id, textQuestionUpdate);
                var result = await assertContext.TextQuestions.Where(x => x.Id == textQuestion.Id).FirstOrDefaultAsync();

                Assert.AreEqual(textQuestionUpdate.Text, result.Text);
                Assert.AreEqual(textQuestionUpdate.IsRequired, result.IsRequired);
                Assert.AreEqual(textQuestionUpdate.IsLongAnswer, result.IsLongAnswer);
                Assert.AreEqual(textQuestionUpdate.Id, result.Id);
            }
        }

        [TestMethod]
        public async Task FailToUpdateTextQuestion_If_QuestionNotExist()
        {
            var options = TestUtils.GetOptions(nameof(FailToUpdateTextQuestion_If_QuestionNotExist));

            var textQuestionUpdate = new TextQuestionDTO
            {
                Id = Guid.Parse("2c6f2674-aee7-47a5-ab70-fb30416af3e3"),
                Text = "Q2",
                IsLongAnswer = false,
                IsRequired = true,
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518")
            };

            using (var assertContext = new FormsContext(options))
            {
                var sut = new TextQuestionService(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.UpdateTextQuestionAsync(textQuestionUpdate.Id, textQuestionUpdate));
            }
        }
    }

}
