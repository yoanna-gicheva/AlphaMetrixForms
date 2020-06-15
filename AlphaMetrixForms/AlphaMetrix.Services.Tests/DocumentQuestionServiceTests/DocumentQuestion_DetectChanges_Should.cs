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
    public class DocumentQuestion_DetectChanges_Should
    {
        IBlobProvider blob = new BlobProvider();

        [TestMethod]
        public async Task DetectUpdateDocumentQuestion_If_ParamsAreValid()
        {
            var options = TestUtils.GetOptions(nameof(DetectUpdateDocumentQuestion_If_ParamsAreValid));

            var form = new Form
            {
                Id = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
                Title = "TestTitle",
                Description = "TestDescription",
            };

            var documentQuestion = new DocumentQuestion
            {
                Id = Guid.Parse("ffb789df-ceed-49d1-9171-6aa70286eedf"),
                Text = "Q1",
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
                IsRequired = true
            };

            var documentQuestion2 = new DocumentQuestion
            {
                Id = Guid.Parse("6e100656-1104-4e6f-8eb2-50ca94f56ae4"),
                Text = "Q2",
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
                IsRequired = true
            };

            var documentQuestionDTO = new DocumentQuestionDTO
            {
                Id = Guid.Parse("ffb789df-ceed-49d1-9171-6aa70286eedf"),
                Text = "Q1111",
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
                IsRequired = false
            };

            var documentQuestionDTO2 = new DocumentQuestionDTO
            {
                Id = Guid.Parse("6e100656-1104-4e6f-8eb2-50ca94f56ae4"),
                Text = "Q2222",
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
                IsRequired = false
            };

            var collectionDTOs = new List<DocumentQuestionDTO>();
            collectionDTOs.Add(documentQuestionDTO);
            collectionDTOs.Add(documentQuestionDTO2);

            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Forms.AddAsync(form);
                await arrangeContext.DocumentQuestions.AddAsync(documentQuestion);
                await arrangeContext.DocumentQuestions.AddAsync(documentQuestion2);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new DocumentQuestionService(assertContext, blob);
                await sut.DocumentQuestion_DetectChanges(form.Id, collectionDTOs);
                var resultList = await assertContext.DocumentQuestions.Where(x => x.FormId == form.Id).ToListAsync();

                Assert.AreEqual(resultList.Count, collectionDTOs.Count);
                Assert.AreEqual(resultList[0].Text, collectionDTOs[0].Text);
                Assert.AreEqual(resultList[0].IsRequired, collectionDTOs[0].IsRequired);
                Assert.AreEqual(resultList[1].Text, collectionDTOs[1].Text);
                Assert.AreEqual(resultList[1].IsRequired, collectionDTOs[1].IsRequired);
            }
        }

        [TestMethod]
        public async Task DetectCreateDocumentQuestion_If_ParamsAreValid()
        {
            var options = TestUtils.GetOptions(nameof(DetectCreateDocumentQuestion_If_ParamsAreValid));

            var form = new Form
            {
                Id = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
                Title = "TestTitle",
                Description = "TestDescription",
            };

            var documentQuestion = new DocumentQuestion
            {
                Id = Guid.Parse("ffb789df-ceed-49d1-9171-6aa70286eedf"),
                Text = "Q1",
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
            };

            var documentQuestion2 = new DocumentQuestion
            {
                Id = Guid.Parse("6e100656-1104-4e6f-8eb2-50ca94f56ae4"),
                Text = "Q2",
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
            };

            var documentQuestionDTO = new DocumentQuestionDTO
            {
                Text = "Q3",
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
            };

            var documentQuestionDTO2 = new DocumentQuestionDTO
            {
                Text = "Q4",
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
            };

            var collectionDTOs = new List<DocumentQuestionDTO>();
            collectionDTOs.Add(documentQuestionDTO);
            collectionDTOs.Add(documentQuestionDTO2);

            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Forms.AddAsync(form);
                await arrangeContext.DocumentQuestions.AddAsync(documentQuestion);
                await arrangeContext.DocumentQuestions.AddAsync(documentQuestion2);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new DocumentQuestionService(assertContext, blob);
                await sut.DocumentQuestion_DetectChanges(form.Id, collectionDTOs);
                var resultList = await assertContext.DocumentQuestions.Where(x => x.FormId == form.Id).ToListAsync();

                Assert.AreEqual(resultList.Count, 4);
                Assert.AreEqual(resultList[2].Text, collectionDTOs[0].Text);
                Assert.AreEqual(resultList[3].Text, collectionDTOs[1].Text);
            }
        }
    }

}
