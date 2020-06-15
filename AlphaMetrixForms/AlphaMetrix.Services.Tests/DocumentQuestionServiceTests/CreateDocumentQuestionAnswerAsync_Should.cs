using AlphaMetrixForms.Data.Context;
using AlphaMetrixForms.Data.Entities;
using AlphaMetrixForms.Services.Providers;
using AlphaMetrixForms.Services.Providers.Contracts;
using AlphaMetrixForms.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMetrix.Services.Tests.DocumentQuestionServiceTests
{
    [TestClass]
    public class CreateDocumentQuestionAnswerAsync_Should
    {
        IBlobProvider blob = new BlobProvider();

        [TestMethod]
        public async Task CreateDocumentQuestionAnswer_If_ParamsAreValid()
        {
            var options = TestUtils.GetOptions(nameof(CreateDocumentQuestionAnswer_If_ParamsAreValid));

            var response = new Response
            {
                Id = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518")
            };

            var documentQuestion = new DocumentQuestion
            {
                Id = Guid.Parse("52cb5dc3-2600-41d2-bb3f-b73f7b242812")
            };

            var answer = new FormFileCollection();
            IFormFile file = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file")), 0, 0, "Data", "dummy.txt");
            answer.Add(file);

            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Responses.AddAsync(response);
                await arrangeContext.DocumentQuestions.AddAsync(documentQuestion);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new DocumentQuestionService(assertContext, blob);
                await sut.CreateDocumentQuestionAnswerAsync(response.Id, documentQuestion.Id, answer);
                var result = await assertContext.DocumentQuestionAnswers.Where(x => x.DocumentQuestionId == documentQuestion.Id).FirstOrDefaultAsync();

                Assert.AreEqual(result.ResponseId, response.Id);
                Assert.AreEqual(result.Answer, $"{response.Id}_{documentQuestion.Id}/{file.FileName}");
            }
        }

        [TestMethod]
        public async Task FailToCreateDocumentQuestionAnswer_If_ResponseNotExist()
        {
            var options = TestUtils.GetOptions(nameof(FailToCreateDocumentQuestionAnswer_If_ResponseNotExist));

            var documentQuestion = new DocumentQuestion
            {
                Id = Guid.Parse("52cb5dc3-2600-41d2-bb3f-b73f7b242812")
            };

            var responseId = Guid.Parse("e5f43398-283a-4788-a3c3-e8b8b5ac631a");

            var answer = new FormFileCollection();
            IFormFile file = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file")), 0, 0, "Data", "dummy.txt");
            answer.Add(file);

            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.DocumentQuestions.AddAsync(documentQuestion);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new DocumentQuestionService(assertContext, blob);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.CreateDocumentQuestionAnswerAsync(responseId, documentQuestion.Id, answer));
            }
        }

        [TestMethod]
        public async Task FailToCreateDocumentQuestionAnswer_If_QuestionNotExist()
        {
            var options = TestUtils.GetOptions(nameof(FailToCreateDocumentQuestionAnswer_If_QuestionNotExist));

            var response = new Response
            {
                Id = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518")
            };

            var questionId = Guid.Parse("e5f43398-283a-4788-a3c3-e8b8b5ac631a");

            var answer = new FormFileCollection();
            IFormFile file = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file")), 0, 0, "Data", "dummy.txt");
            answer.Add(file);

            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Responses.AddAsync(response);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new DocumentQuestionService(assertContext, blob);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.CreateDocumentQuestionAnswerAsync(response.Id, questionId, answer));
            }
        }

        [TestMethod]
        public async Task FailToCreateDocumentQuestionAnswer_If_AnswerIsNull()
        {
            var options = TestUtils.GetOptions(nameof(FailToCreateDocumentQuestionAnswer_If_AnswerIsNull));

            var response = new Response
            {
                Id = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518")
            };

            var documentQuestion = new DocumentQuestion
            {
                Id = Guid.Parse("52cb5dc3-2600-41d2-bb3f-b73f7b242812")
            };

            var answer = new FormFileCollection();

            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Responses.AddAsync(response);
                await arrangeContext.DocumentQuestions.AddAsync(documentQuestion);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new DocumentQuestionService(assertContext, blob);
                await sut.CreateDocumentQuestionAnswerAsync(response.Id, documentQuestion.Id, answer);
                var result = await assertContext.DocumentQuestionAnswers.Where(x => x.DocumentQuestionId == documentQuestion.Id).FirstOrDefaultAsync();

                Assert.AreEqual(result, null);
            }
        }
    }
}
