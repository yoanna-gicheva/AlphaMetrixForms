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
    public class OptionQuestion_DetectChanges_Should
    {
        [TestMethod]
        public async Task DetectUpdateOptionQuestion_If_ParamsAreValid()
        {
            var options = TestUtils.GetOptions(nameof(DetectUpdateOptionQuestion_If_ParamsAreValid));

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

            var collectionDTOs = new List<OptionQuestionDTO>();
            collectionDTOs.Add(optionQuestionUpdate);

            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Forms.AddAsync(form);
                await arrangeContext.OptionQuestions.AddAsync(optionQuestion);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new OptionQuestionService(assertContext);
                await sut.OptionQuestion_DetectChanges(form.Id, collectionDTOs);
                var resultList = await assertContext.OptionQuestions.Where(x => x.FormId == form.Id).ToListAsync();

                Assert.AreEqual(resultList.Count, collectionDTOs.Count);
                Assert.AreEqual(resultList[0].Text, collectionDTOs[0].Text);
            }
        }

        [TestMethod]
        public async Task DetectCreateOptionQuestion_If_ParamsAreValid()
        {

            var options = TestUtils.GetOptions(nameof(DetectCreateOptionQuestion_If_ParamsAreValid));

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

            var optionQuestionUpdate2 = new OptionQuestionDTO
            {
                Text = "Q2",
                IsRequired = true,
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
                Options = new List<OptionDTO>() { new OptionDTO { Text = "1" }, new OptionDTO { Text = "2" } }
            };

            var collectionDTOs = new List<OptionQuestionDTO>();
            collectionDTOs.Add(optionQuestionUpdate);
            collectionDTOs.Add(optionQuestionUpdate2);

            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Forms.AddAsync(form);
                await arrangeContext.OptionQuestions.AddAsync(optionQuestion);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new OptionQuestionService(assertContext);
                await sut.OptionQuestion_DetectChanges(form.Id, collectionDTOs);
                var resultList = await assertContext.OptionQuestions.Where(x => x.FormId == form.Id).ToListAsync();

                Assert.AreEqual(resultList.Count, 2);
                Assert.AreEqual(resultList[1].Text, collectionDTOs[1].Text);
            }
        }
    }

}
