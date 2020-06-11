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

namespace AlphaMetrix.Services.Tests.OptionQuestionServiceTests
{
    [TestClass]
    public class CreateOptionQuestionAnswerCheckboxAsync_Should
    {
        [TestMethod]
        public async Task CreateOptionQuestionAnswerCheckbox_If_ParamsAreValid()
        {
            var options = TestUtils.GetOptions(nameof(CreateOptionQuestionAnswerCheckbox_If_ParamsAreValid));

            var response = new Response
            {
                Id = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518")
            };

            var optionQuestion = new OptionQuestion
            {
                Id = Guid.Parse("52cb5dc3-2600-41d2-bb3f-b73f7b242812")
            };
            var option1 = new Option
            {
                Id = Guid.Parse("c63e82e0-c0b9-46c4-92bf-3c5f4fb7b1d1"),
                Text = "Option1",
                QuestionId = Guid.Parse("52cb5dc3-2600-41d2-bb3f-b73f7b242812"),
                OrderNumber=1
            };

            var option2 = new Option
            {
                Id = Guid.Parse("dcdcc6da-f23b-4902-82dd-c83fca9e9294"),
                Text = "Option2",
                QuestionId = Guid.Parse("52cb5dc3-2600-41d2-bb3f-b73f7b242812"),
                OrderNumber=2
            };

            var option3 = new Option
            {
                Id = Guid.Parse("6d09957c-01f2-449d-a9a2-ab50125ff2f0"),
                Text = "Option3",
                QuestionId = Guid.Parse("52cb5dc3-2600-41d2-bb3f-b73f7b242812"),
                OrderNumber=3
            };

            List<bool> boolAnswers = new List<bool>() { false, true, true };

            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Responses.AddAsync(response);
                await arrangeContext.OptionQuestions.AddAsync(optionQuestion);
                await arrangeContext.Options.AddAsync(option1);
                await arrangeContext.Options.AddAsync(option2);
                await arrangeContext.Options.AddAsync(option3);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new OptionQuestionService(assertContext);
                await sut.CreateOptionQuestionAnswerCheckboxAsync(response.Id, optionQuestion.Id, boolAnswers);
                var result = await assertContext.OptionQuestionAnswers.Where(x => x.OptionQuestionId == optionQuestion.Id).ToListAsync();

                Assert.AreEqual(result.Count, 2);
                Assert.AreEqual(result[0].Answer, "Option2");
                Assert.AreEqual(result[1].Answer, "Option3");
            }
        }

        [TestMethod]
        public async Task FailToCreateOptionQuestionAnswerCheckBox_If_ResponseNotExist()
        {
            var options = TestUtils.GetOptions(nameof(FailToCreateOptionQuestionAnswerCheckBox_If_ResponseNotExist));

            var optionQuestion = new OptionQuestion
            {
                Id = Guid.Parse("52cb5dc3-2600-41d2-bb3f-b73f7b242812")
            };
            var option1 = new Option
            {
                Id = Guid.Parse("c63e82e0-c0b9-46c4-92bf-3c5f4fb7b1d1"),
                Text = "Option1",
                QuestionId = Guid.Parse("52cb5dc3-2600-41d2-bb3f-b73f7b242812"),
                OrderNumber = 1
            };

            var option2 = new Option
            {
                Id = Guid.Parse("dcdcc6da-f23b-4902-82dd-c83fca9e9294"),
                Text = "Option2",
                QuestionId = Guid.Parse("52cb5dc3-2600-41d2-bb3f-b73f7b242812"),
                OrderNumber = 2
            };

            var option3 = new Option
            {
                Id = Guid.Parse("6d09957c-01f2-449d-a9a2-ab50125ff2f0"),
                Text = "Option3",
                QuestionId = Guid.Parse("52cb5dc3-2600-41d2-bb3f-b73f7b242812"),
                OrderNumber = 3
            };

            List<bool> boolAnswers = new List<bool>() { false, true, true };

            var responseId = Guid.Parse("e5f43398-283a-4788-a3c3-e8b8b5ac631a");

            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.OptionQuestions.AddAsync(optionQuestion);
                await arrangeContext.Options.AddAsync(option1);
                await arrangeContext.Options.AddAsync(option2);
                await arrangeContext.Options.AddAsync(option3);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new OptionQuestionService(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.CreateOptionQuestionAnswerCheckboxAsync(responseId, optionQuestion.Id, boolAnswers));
            }
        }

        [TestMethod]
        public async Task FailToCreateOptionQuestionAnswerCheckBox_If_QuestionNotExist()
        {
            var options = TestUtils.GetOptions(nameof(FailToCreateOptionQuestionAnswerCheckBox_If_QuestionNotExist));

            var response = new Response
            {
                Id = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518")
            };

            var questionId = Guid.Parse("e5f43398-283a-4788-a3c3-e8b8b5ac631a");
            List<bool> boolAnswers = new List<bool>() { false, true, true };
            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Responses.AddAsync(response);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new OptionQuestionService(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.CreateOptionQuestionAnswerCheckboxAsync(response.Id, questionId, boolAnswers));
            }
        }

        [TestMethod]
        public async Task FailToCreateOptionQuestionAnswerCheckBox_If_AnswerIsNull()
        {
            var options = TestUtils.GetOptions(nameof(FailToCreateOptionQuestionAnswerCheckBox_If_AnswerIsNull));

            var response = new Response
            {
                Id = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518")
            };

            var optionQuestion = new OptionQuestion
            {
                Id = Guid.Parse("52cb5dc3-2600-41d2-bb3f-b73f7b242812")
            };
            var option1 = new Option
            {
                Id = Guid.Parse("c63e82e0-c0b9-46c4-92bf-3c5f4fb7b1d1"),
                Text = "Option1",
                QuestionId = Guid.Parse("52cb5dc3-2600-41d2-bb3f-b73f7b242812"),
                OrderNumber = 1
            };

            var option2 = new Option
            {
                Id = Guid.Parse("dcdcc6da-f23b-4902-82dd-c83fca9e9294"),
                Text = "Option2",
                QuestionId = Guid.Parse("52cb5dc3-2600-41d2-bb3f-b73f7b242812"),
                OrderNumber = 2
            };

            var option3 = new Option
            {
                Id = Guid.Parse("6d09957c-01f2-449d-a9a2-ab50125ff2f0"),
                Text = "Option3",
                QuestionId = Guid.Parse("52cb5dc3-2600-41d2-bb3f-b73f7b242812"),
                OrderNumber = 3
            };

            List<bool> boolAnswers = new List<bool>() { false, false, false };
            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Responses.AddAsync(response);
                await arrangeContext.OptionQuestions.AddAsync(optionQuestion);
                await arrangeContext.Options.AddAsync(option1);
                await arrangeContext.Options.AddAsync(option2);
                await arrangeContext.Options.AddAsync(option3);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new OptionQuestionService(assertContext);
                await sut.CreateOptionQuestionAnswerCheckboxAsync(response.Id, optionQuestion.Id, boolAnswers);
                var result = await assertContext.OptionQuestionAnswers.Where(x => x.OptionQuestionId == optionQuestion.Id).FirstOrDefaultAsync();

                Assert.AreEqual(result, null);
            }
        }

        [TestMethod]
        public async Task FailToCreateOptionQuestionAnswerCheckBox_If_AnswerCountIsDifferentFromOptionCount()
        {
            var options = TestUtils.GetOptions(nameof(FailToCreateOptionQuestionAnswerCheckBox_If_AnswerCountIsDifferentFromOptionCount));

            var response = new Response
            {
                Id = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518")
            };

            var optionQuestion = new OptionQuestion
            {
                Id = Guid.Parse("52cb5dc3-2600-41d2-bb3f-b73f7b242812")
            };
            var option1 = new Option
            {
                Id = Guid.Parse("c63e82e0-c0b9-46c4-92bf-3c5f4fb7b1d1"),
                Text = "Option1",
                QuestionId = Guid.Parse("52cb5dc3-2600-41d2-bb3f-b73f7b242812"),
                OrderNumber = 1
            };

            var option2 = new Option
            {
                Id = Guid.Parse("dcdcc6da-f23b-4902-82dd-c83fca9e9294"),
                Text = "Option2",
                QuestionId = Guid.Parse("52cb5dc3-2600-41d2-bb3f-b73f7b242812"),
                OrderNumber = 2
            };

            var option3 = new Option
            {
                Id = Guid.Parse("6d09957c-01f2-449d-a9a2-ab50125ff2f0"),
                Text = "Option3",
                QuestionId = Guid.Parse("52cb5dc3-2600-41d2-bb3f-b73f7b242812"),
                OrderNumber = 3
            };

            List<bool> boolAnswers = new List<bool>() { false, false, false, true };
            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Responses.AddAsync(response);
                await arrangeContext.OptionQuestions.AddAsync(optionQuestion);
                await arrangeContext.Options.AddAsync(option1);
                await arrangeContext.Options.AddAsync(option2);
                await arrangeContext.Options.AddAsync(option3);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new OptionQuestionService(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.CreateOptionQuestionAnswerCheckboxAsync(response.Id, optionQuestion.Id, boolAnswers));
            }
        }
    }
}
