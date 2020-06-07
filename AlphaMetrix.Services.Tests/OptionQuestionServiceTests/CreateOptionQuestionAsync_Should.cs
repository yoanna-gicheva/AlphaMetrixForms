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
    public class CreateOptionQuestionAsync_Should
    {
        [TestMethod]
        public async Task CreateOptionQuestion_If_ParamsAreValid()
        {
            var options = TestUtils.GetOptions(nameof(CreateOptionQuestion_If_ParamsAreValid));

            var form = new Form
            {
                Id = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
                Title = "TestTitle",
                Description = "TestDescription",
            };

            var optionQuestionDTO = new OptionQuestionDTO
            {
                Text = "Q1",
                Options = new List<OptionDTO>(){ new OptionDTO { Text = "O1" }, new OptionDTO { Text ="O2"} }   
            };

            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Forms.AddAsync(form);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new OptionQuestionService(assertContext);
                var resultDTO = await sut.CreateOptionQuestionAsync(optionQuestionDTO, form.Id);
                var resultQuestion = await assertContext.OptionQuestions.Where(x => x.Text == "Q1").FirstOrDefaultAsync();
                var resultOptions = await assertContext.Options.Where(x => x.QuestionId == resultQuestion.Id).ToListAsync();

                Assert.AreEqual(resultDTO.Id, resultQuestion.Id);
                Assert.AreEqual(optionQuestionDTO.Text, resultQuestion.Text);
                Assert.AreEqual(optionQuestionDTO.Options.Count, resultOptions.Count);
                Assert.AreEqual(resultOptions[0].Text, "O1");
                Assert.AreEqual(resultOptions[1].Text, "O2");
                Assert.AreEqual(resultOptions[0].QuestionId, resultQuestion.Id);
                Assert.AreEqual(resultOptions[1].QuestionId, resultQuestion.Id);
            }
        }

        [TestMethod]
        public async Task FailToCreateOptionQuestion_If_FormNotExist()
        {
            var options = TestUtils.GetOptions(nameof(FailToCreateOptionQuestion_If_FormNotExist));

            var optionQuestionDTO = new OptionQuestionDTO
            {
                Text = "Q1",
                Options = new List<OptionDTO>() { new OptionDTO { Text = "O1" }, new OptionDTO { Text = "O2" } }
            };
            var formId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518");

            using (var assertContext = new FormsContext(options))
            {
                var sut = new OptionQuestionService(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.CreateOptionQuestionAsync(optionQuestionDTO, formId));
            }
        }

        [TestMethod]
        public async Task CreateOptionQuestions_If_ParamsAreValid()
        {
            var options = TestUtils.GetOptions(nameof(CreateOptionQuestions_If_ParamsAreValid));

            var form = new Form
            {
                Id = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
                Title = "TestTitle",
                Description = "TestDescription",
            };

            var optionQuestionDTO = new OptionQuestionDTO
            {
                Text = "Q1",
                Options = new List<OptionDTO>() { new OptionDTO { Text = "O1" }, new OptionDTO { Text = "O2" } }
            };

            var optionQuestionDTO2 = new OptionQuestionDTO
            {
                Text = "Q2",
                Options = new List<OptionDTO>() { new OptionDTO { Text = "O1" }, new OptionDTO { Text = "O2" } }
            };

            var collectionDTOs = new List<OptionQuestionDTO>();
            collectionDTOs.Add(optionQuestionDTO);
            collectionDTOs.Add(optionQuestionDTO2);

            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Forms.AddAsync(form);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new OptionQuestionService(assertContext);
                var result = await sut.CreateOptionQuestionAsync(collectionDTOs, form.Id);
                var resultList = await assertContext.OptionQuestions.Where(x => x.FormId == form.Id).ToListAsync();

                Assert.AreEqual(result, true);
                Assert.AreEqual(resultList.Count, collectionDTOs.Count);
                Assert.AreEqual(resultList[0].Text, collectionDTOs[0].Text);
                Assert.AreEqual(resultList[1].Text, collectionDTOs[1].Text);
            }
        }
        [TestMethod]
        public async Task FailToCreateOptionQuestions_If_CollectionIsEmpty()
        {
            var options = TestUtils.GetOptions(nameof(FailToCreateOptionQuestions_If_CollectionIsEmpty));

            var form = new Form
            {
                Id = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
                Title = "TestTitle",
                Description = "TestDescription",
            };

            var collectionDTOs = new List<OptionQuestionDTO>();

            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Forms.AddAsync(form);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new OptionQuestionService(assertContext);
                var result = await sut.CreateOptionQuestionAsync(collectionDTOs, form.Id);
                var resultQuestion = await assertContext.TextQuestions.Where(x => x.FormId == form.Id).FirstOrDefaultAsync();

                Assert.AreEqual(result, false);
                Assert.AreEqual(resultQuestion, null);
            }
        }
    }
}
