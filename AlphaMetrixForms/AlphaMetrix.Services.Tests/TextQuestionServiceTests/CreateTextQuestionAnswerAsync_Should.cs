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
    public class CreateTextQuestionAnswerAsync_Should
    {
        [TestMethod]
        public async Task CreateTextQuestionAnswer_If_ParamsAreValid()
        {
            var options = TestUtils.GetOptions(nameof(CreateTextQuestionAnswer_If_ParamsAreValid));

            var response = new Response
            {
                Id = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518")
            };

            var textQuestion = new TextQuestion
            {
                Id = Guid.Parse("52cb5dc3-2600-41d2-bb3f-b73f7b242812")
            };

            string answer = "answer";
            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Responses.AddAsync(response);
                await arrangeContext.TextQuestions.AddAsync(textQuestion);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new TextQuestionService(assertContext);
                await sut.CreateTextQuestionAnswerAsync(response.Id, textQuestion.Id, answer);
                var result = await assertContext.TextQuestionAnswers.Where(x => x.TextQuestionId == textQuestion.Id).FirstOrDefaultAsync();

                Assert.AreEqual(result.ResponseId, response.Id);
                Assert.AreEqual(result.Answer, answer);
            }
        }

        [TestMethod]
        public async Task FailToCreateTextQuestionAnswer_If_ResponseNotExist()
        {
            var options = TestUtils.GetOptions(nameof(FailToCreateTextQuestionAnswer_If_ResponseNotExist));

            var textQuestion = new TextQuestion
            {
                Id = Guid.Parse("52cb5dc3-2600-41d2-bb3f-b73f7b242812")
            };

            var responseId = Guid.Parse("e5f43398-283a-4788-a3c3-e8b8b5ac631a");
            string answer = "answer";
            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.TextQuestions.AddAsync(textQuestion);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new TextQuestionService(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.CreateTextQuestionAnswerAsync(responseId, textQuestion.Id, answer));
            }
        }

        [TestMethod]
        public async Task FailToCreateTextQuestionAnswer_If_QuestionNotExist()
        {
            var options = TestUtils.GetOptions(nameof(FailToCreateTextQuestionAnswer_If_QuestionNotExist));

            var response = new Response
            {
                Id = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518")
            };

            var questionId = Guid.Parse("e5f43398-283a-4788-a3c3-e8b8b5ac631a");
            string answer = "answer";
            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Responses.AddAsync(response);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new TextQuestionService(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.CreateTextQuestionAnswerAsync(response.Id, questionId, answer));
            }
        }

        [TestMethod]
        public async Task FailToCreateTextQuestionAnswer_If_AnswerIsNull()
        {
            var options = TestUtils.GetOptions(nameof(FailToCreateTextQuestionAnswer_If_AnswerIsNull));

            var response = new Response
            {
                Id = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518")
            };

            var textQuestion = new TextQuestion
            {
                Id = Guid.Parse("52cb5dc3-2600-41d2-bb3f-b73f7b242812")
            };

            string answer=null;
            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Responses.AddAsync(response);
                await arrangeContext.TextQuestions.AddAsync(textQuestion);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new TextQuestionService(assertContext);
                await sut.CreateTextQuestionAnswerAsync(response.Id, textQuestion.Id, answer);
                var result = await assertContext.TextQuestionAnswers.Where(x => x.TextQuestionId == textQuestion.Id).FirstOrDefaultAsync();

                Assert.AreEqual(result, null);
            }
        }
    }
}
