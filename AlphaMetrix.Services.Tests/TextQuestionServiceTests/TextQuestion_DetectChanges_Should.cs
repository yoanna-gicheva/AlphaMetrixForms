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
    public class TextQuestion_DetectChanges_Should
    {
        [TestMethod]
        public async Task DetectUpdateTextQuestion_If_ParamsAreValid()
        {
            var options = TestUtils.GetOptions(nameof(DetectUpdateTextQuestion_If_ParamsAreValid));

            var form = new Form
            {
                Id = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
                Title = "TestTitle",
                Description = "TestDescription",
            };

            var textQuestion = new TextQuestion
            {
                Id = Guid.Parse("ffb789df-ceed-49d1-9171-6aa70286eedf"),
                Text = "Q1",
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
                IsLongAnswer = true
            };

            var textQuestion2 = new TextQuestion
            {
                Id = Guid.Parse("6e100656-1104-4e6f-8eb2-50ca94f56ae4"),
                Text = "Q2",
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
                IsLongAnswer = true
            };

            var textQuestionDTO = new TextQuestionDTO
            {
                Id = Guid.Parse("ffb789df-ceed-49d1-9171-6aa70286eedf"),
                Text = "Q1111",
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
                IsLongAnswer=false
            };

            var textQuestionDTO2 = new TextQuestionDTO
            {
                Id = Guid.Parse("6e100656-1104-4e6f-8eb2-50ca94f56ae4"),
                Text = "Q2222",
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
                IsLongAnswer = false
            };

            var collectionDTOs = new List<TextQuestionDTO>();
            collectionDTOs.Add(textQuestionDTO);
            collectionDTOs.Add(textQuestionDTO2);

            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Forms.AddAsync(form);
                await arrangeContext.TextQuestions.AddAsync(textQuestion);
                await arrangeContext.TextQuestions.AddAsync(textQuestion2);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new TextQuestionService(assertContext);
                await sut.TextQuestion_DetectChanges(form.Id, collectionDTOs);
                var resultList = await assertContext.TextQuestions.Where(x => x.FormId == form.Id).ToListAsync();

                Assert.AreEqual(resultList.Count, collectionDTOs.Count);
                Assert.AreEqual(resultList[0].Text, collectionDTOs[0].Text);
                Assert.AreEqual(resultList[0].IsLongAnswer, collectionDTOs[0].IsLongAnswer);
                Assert.AreEqual(resultList[1].Text, collectionDTOs[1].Text);
                Assert.AreEqual(resultList[1].IsLongAnswer, collectionDTOs[1].IsLongAnswer);
            }
        }

        [TestMethod]
        public async Task DetectCreateTextQuestion_If_ParamsAreValid()
        {
            var options = TestUtils.GetOptions(nameof(DetectCreateTextQuestion_If_ParamsAreValid));

            var form = new Form
            {
                Id = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
                Title = "TestTitle",
                Description = "TestDescription",
            };

            var textQuestion = new TextQuestion
            {
                Id = Guid.Parse("ffb789df-ceed-49d1-9171-6aa70286eedf"),
                Text = "Q1",
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
            };

            var textQuestion2 = new TextQuestion
            {
                Id = Guid.Parse("6e100656-1104-4e6f-8eb2-50ca94f56ae4"),
                Text = "Q2",
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
            };

            var textQuestionDTO = new TextQuestionDTO
            {
                Text = "Q3",
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
            };

            var textQuestionDTO2 = new TextQuestionDTO
            {
                Text = "Q4",
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
            };

            var collectionDTOs = new List<TextQuestionDTO>();
            collectionDTOs.Add(textQuestionDTO);
            collectionDTOs.Add(textQuestionDTO2);

            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Forms.AddAsync(form);
                await arrangeContext.TextQuestions.AddAsync(textQuestion);
                await arrangeContext.TextQuestions.AddAsync(textQuestion2);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new TextQuestionService(assertContext);
                await sut.TextQuestion_DetectChanges(form.Id, collectionDTOs);
                var resultList = await assertContext.TextQuestions.Where(x => x.FormId == form.Id).ToListAsync();

                Assert.AreEqual(resultList.Count, 4);
                Assert.AreEqual(resultList[2].Text, collectionDTOs[0].Text);
                Assert.AreEqual(resultList[3].Text, collectionDTOs[1].Text);
            }
        }
    }

}
