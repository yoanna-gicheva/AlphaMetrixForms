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
    public class UpdateOptionQuestionAsync_Should
    {
        [TestMethod]
        public async Task UpdateOptionQuestion_If_ParamsAreValid()
        {
            var options = TestUtils.GetOptions(nameof(UpdateOptionQuestion_If_ParamsAreValid));

            var form = new Form
            {
                Id = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
                Title = "TestTitle",
                Description = "TestDescription",
            };

            var optionQuestion = new OptionQuestion
            {
                Id = Guid.Parse("2c6f2674-aee7-47a5-ab70-fb30416af3e3"),
                Text = "Q1",
                IsRequired = false,
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518")
            };
            var option1 = new Option
            {
                Id = Guid.Parse("c63e82e0-c0b9-46c4-92bf-3c5f4fb7b1d1"),
                Text = "Option1",
                QuestionId = Guid.Parse("2c6f2674-aee7-47a5-ab70-fb30416af3e3")
            };

            var option2 = new Option
            {
                Id = Guid.Parse("dcdcc6da-f23b-4902-82dd-c83fca9e9294"),
                Text = "Option2",
                QuestionId = Guid.Parse("2c6f2674-aee7-47a5-ab70-fb30416af3e3")
            };

            var optionQuestionUpdate = new OptionQuestionDTO
            {
                Id = Guid.Parse("2c6f2674-aee7-47a5-ab70-fb30416af3e3"),
                Text = "Q2",
                IsRequired = true,
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
                Options = new List<OptionDTO>() { new OptionDTO { Text = "1" }, new OptionDTO { Text = "2" }, new OptionDTO { Text = "3" } }
            };

            var optionQuestion2 = new OptionQuestion
            {
                Id = Guid.Parse("f6c9a506-9733-4374-afdf-279cb1d560e5"),
                Text = "Q3",
                IsRequired = false,
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518")
            };
            var option3 = new Option
            {
                Id = Guid.Parse("6a1b6243-a85e-47f5-843b-4fbee85ac787"),
                Text = "Option1",
                QuestionId = Guid.Parse("f6c9a506-9733-4374-afdf-279cb1d560e5")
            };

            var option4 = new Option
            {
                Id = Guid.Parse("d9466552-d8be-4217-8ef5-9af0e1e64a7d"),
                Text = "Option2",
                QuestionId = Guid.Parse("f6c9a506-9733-4374-afdf-279cb1d560e5")
            };

            var option5 = new Option
            {
                Id = Guid.Parse("54a07cce-c410-443c-840f-81dfff3c0d35"),
                Text = "Option3",
                QuestionId = Guid.Parse("f6c9a506-9733-4374-afdf-279cb1d560e5")
            };

            var optionQuestionUpdate2 = new OptionQuestionDTO
            {
                Id = Guid.Parse("f6c9a506-9733-4374-afdf-279cb1d560e5"),
                Text = "Q4",
                IsRequired = true,
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
                Options = new List<OptionDTO>() { new OptionDTO { Text = "1" }, new OptionDTO { Text = "2" } }
            };

            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Forms.AddAsync(form);
                await arrangeContext.OptionQuestions.AddAsync(optionQuestion);
                await arrangeContext.OptionQuestions.AddAsync(optionQuestion2);
                await arrangeContext.Options.AddAsync(option1);
                await arrangeContext.Options.AddAsync(option2);
                await arrangeContext.Options.AddAsync(option3);
                await arrangeContext.Options.AddAsync(option4);
                await arrangeContext.Options.AddAsync(option5);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                //Test when we are increasing the number of options

                var sut = new OptionQuestionService(assertContext);
                var resultDTO = await sut.UpdateOptionQuestionAsync(optionQuestion.Id, optionQuestionUpdate);
                var result = await assertContext.OptionQuestions.Where(x => x.Id == optionQuestion.Id).FirstOrDefaultAsync();
                var newOptions = await assertContext.Options.Where(x => x.QuestionId == optionQuestion.Id).ToListAsync();

                Assert.AreEqual(optionQuestionUpdate.Text, result.Text);
                Assert.AreEqual(optionQuestionUpdate.IsRequired, result.IsRequired);
                Assert.AreEqual(optionQuestionUpdate.Id, result.Id);
                Assert.AreEqual(newOptions.Count, 3);
                Assert.AreEqual(newOptions[2].Text, "3");
                Assert.AreEqual(newOptions[1].Text, "2");
                Assert.AreEqual(newOptions[0].Text, "1");

                //Test when we are decreasing the number of options

                var resultDTO2 = await sut.UpdateOptionQuestionAsync(optionQuestion2.Id, optionQuestionUpdate2);
                var result2 = await assertContext.OptionQuestions.Where(x => x.Id == optionQuestion2.Id).FirstOrDefaultAsync();
                var newOptions2 = await assertContext.Options.Where(x => x.QuestionId == optionQuestion2.Id).ToListAsync();

                Assert.AreEqual(optionQuestionUpdate2.Text, result2.Text);
                Assert.AreEqual(optionQuestionUpdate2.IsRequired, result2.IsRequired);
                Assert.AreEqual(optionQuestionUpdate2.Id, result2.Id);
                Assert.AreEqual(newOptions2.Count, 2);
                Assert.AreEqual(newOptions[1].Text, "2");
                Assert.AreEqual(newOptions[0].Text, "1");

            }
        }

        [TestMethod]
        public async Task FailToUpdateOptionQuestion_If_QuestionNotExist()
        {
            var options = TestUtils.GetOptions(nameof(FailToUpdateOptionQuestion_If_QuestionNotExist));

            var optionQuestionUpdate = new OptionQuestionDTO
            {
                Id = Guid.Parse("2c6f2674-aee7-47a5-ab70-fb30416af3e3"),
                Text = "Q2",
                IsRequired = true,
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518")
            };

            using (var assertContext = new FormsContext(options))
            {
                var sut = new OptionQuestionService(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.UpdateOptionQuestionAsync(optionQuestionUpdate.Id, optionQuestionUpdate));
            }
        }
    }

}
