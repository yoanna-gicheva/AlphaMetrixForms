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
    public class CreateTextQuestionAsync_Should
    {
        [TestMethod]
        public async Task CreateTextQuestion_If_ParamsAreValid()
        {
            var options = TestUtils.GetOptions(nameof(CreateTextQuestion_If_ParamsAreValid));

            var form = new Form
            {
                Id=Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
                Title = "TestTitle",
                Description = "TestDescription",
            };

            var textQuestionDTO = new TextQuestionDTO
            {
                Text = "Q1",
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518")
            };

            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Forms.AddAsync(form);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new TextQuestionService(assertContext);
                var resultDTO = await sut.CreateTextQuestionAsync(textQuestionDTO, form.Id);
                var result = await assertContext.TextQuestions.Where(x => x.Text == "Q1").FirstOrDefaultAsync();

                Assert.AreEqual(resultDTO.Id, result.Id);
                Assert.AreEqual(resultDTO.FormId, form.Id);
            }
        }

        [TestMethod]
        public async Task FailToCreateTextQuestion_If_FormNotExist()
        {
            var options = TestUtils.GetOptions(nameof(FailToCreateTextQuestion_If_FormNotExist));

            var textQuestionDTO = new TextQuestionDTO
            {
                Text = "Q1",
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518")
            };

            using (var assertContext = new FormsContext(options))
            {
                var sut = new TextQuestionService(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.CreateTextQuestionAsync(textQuestionDTO, textQuestionDTO.FormId));
            }
        }

        [TestMethod]
        public async Task CreateTextQuestions_If_ParamsAreValid()
        {
            var options = TestUtils.GetOptions(nameof(CreateTextQuestions_If_ParamsAreValid));

            var form = new Form
            {
                Id = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
                Title = "TestTitle",
                Description = "TestDescription",
            };

            var textQuestionDTO = new TextQuestionDTO
            {
                Text = "Q1",
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518")
            };

            var textQuestionDTO2 = new TextQuestionDTO
            {
                Text = "Q2",
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518")
            };

            var collectionDTOs = new List<TextQuestionDTO>();
            collectionDTOs.Add(textQuestionDTO);
            collectionDTOs.Add(textQuestionDTO2);

            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Forms.AddAsync(form);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new TextQuestionService(assertContext);
                var result = await sut.CreateTextQuestionAsync(collectionDTOs, form.Id);
                var resultList = await assertContext.TextQuestions.Where(x => x.FormId == form.Id).ToListAsync();

                Assert.AreEqual(result, true);
                Assert.AreEqual(resultList.Count, collectionDTOs.Count);
                Assert.AreEqual(resultList[0].Text, collectionDTOs[0].Text);
                Assert.AreEqual(resultList[1].Text, collectionDTOs[1].Text);
            }
        }
        [TestMethod]
        public async Task FailToCreateTextQuestions_If_CollectionIsEmpty()
        {
            var options = TestUtils.GetOptions(nameof(FailToCreateTextQuestions_If_CollectionIsEmpty));

            var form = new Form
            {
                Id = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
                Title = "TestTitle",
                Description = "TestDescription",
            };

            var collectionDTOs = new List<TextQuestionDTO>();

            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Forms.AddAsync(form);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new TextQuestionService(assertContext);
                var result = await sut.CreateTextQuestionAsync(collectionDTOs, form.Id);
                var resultQuestion = await assertContext.TextQuestions.Where(x => x.FormId == form.Id).FirstOrDefaultAsync();

                Assert.AreEqual(result, false);
                Assert.AreEqual(resultQuestion, null);
            }
        }
    }
}
