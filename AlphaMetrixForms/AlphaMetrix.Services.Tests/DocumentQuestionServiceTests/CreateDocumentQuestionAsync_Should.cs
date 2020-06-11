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

namespace AlphaMetrix.Services.Tests.DocumentQuestionServiceTests
{
    [TestClass]
    public class CreateDocumentQuestionAsync_Should
    {
        [TestMethod]
        public async Task CreateDocumentQuestion_If_ParamsAreValid()
        {
            var options = TestUtils.GetOptions(nameof(CreateDocumentQuestion_If_ParamsAreValid));

            var form = new Form
            {
                Id = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
                Title = "TestTitle",
                Description = "TestDescription",
            };

            var documentQuestionDTO = new DocumentQuestionDTO
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
                var sut = new DocumentQuestionService(assertContext);
                var resultDTO = await sut.CreateDocumentQuestionAsync(documentQuestionDTO, form.Id);
                var result = await assertContext.DocumentQuestions.Where(x => x.Text == "Q1").FirstOrDefaultAsync();

                Assert.AreEqual(resultDTO.Id, result.Id);
                Assert.AreEqual(resultDTO.FormId, form.Id);
            }
        }

        [TestMethod]
        public async Task FailToCreateDocumentQuestion_If_FormNotExist()
        {
            var options = TestUtils.GetOptions(nameof(FailToCreateDocumentQuestion_If_FormNotExist));

            var documentQuestionDTO = new DocumentQuestionDTO
            {
                Text = "Q1",
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518")
            };

            using (var assertContext = new FormsContext(options))
            {
                var sut = new DocumentQuestionService(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.CreateDocumentQuestionAsync(documentQuestionDTO, documentQuestionDTO.FormId));
            }
        }

        [TestMethod]
        public async Task CreateDocumentQuestions_If_ParamsAreValid()
        {
            var options = TestUtils.GetOptions(nameof(CreateDocumentQuestions_If_ParamsAreValid));

            var form = new Form
            {
                Id = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
                Title = "TestTitle",
                Description = "TestDescription",
            };

            var documentQuestionDTO = new DocumentQuestionDTO
            {
                Text = "Q1",
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518")
            };

            var documentQuestionDTO2 = new DocumentQuestionDTO
            {
                Text = "Q2",
                FormId = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518")
            };

            var collectionDTOs = new List<DocumentQuestionDTO>();
            collectionDTOs.Add(documentQuestionDTO);
            collectionDTOs.Add(documentQuestionDTO2);

            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Forms.AddAsync(form);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new DocumentQuestionService(assertContext);
                var result = await sut.CreateDocumentQuestionAsync(collectionDTOs, form.Id);
                var resultList = await assertContext.DocumentQuestions.Where(x => x.FormId == form.Id).ToListAsync();

                Assert.AreEqual(result, true);
                Assert.AreEqual(resultList.Count, collectionDTOs.Count);
                Assert.AreEqual(resultList[0].Text, collectionDTOs[0].Text);
                Assert.AreEqual(resultList[1].Text, collectionDTOs[1].Text);
            }
        }
        [TestMethod]
        public async Task FailToCreateDocumentQuestions_If_CollectionIsEmpty()
        {
            var options = TestUtils.GetOptions(nameof(FailToCreateDocumentQuestions_If_CollectionIsEmpty));

            var form = new Form
            {
                Id = Guid.Parse("3cccbee2-bbe9-4a9e-a164-125478002518"),
                Title = "TestTitle",
                Description = "TestDescription",
            };

            var collectionDTOs = new List<DocumentQuestionDTO>();

            using (var arrangeContext = new FormsContext(options))
            {
                await arrangeContext.Forms.AddAsync(form);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FormsContext(options))
            {
                var sut = new DocumentQuestionService(assertContext);
                var result = await sut.CreateDocumentQuestionAsync(collectionDTOs, form.Id);
                var resultQuestion = await assertContext.DocumentQuestions.Where(x => x.FormId == form.Id).FirstOrDefaultAsync();

                Assert.AreEqual(result, false);
                Assert.AreEqual(resultQuestion, null);
            }
        }
    }
}
