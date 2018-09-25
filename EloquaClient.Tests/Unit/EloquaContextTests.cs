using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Dtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Tests.Unit
{
    [TestClass]
    public class EloquaContextTests
    {
        [TestMethod]
        public void EloquaContextTest()
        {
            //Arrange
            var mockRestClient = new Mock<IRestClient>();

            //Act
            var eloquaContext = new EloquaContext(mockRestClient.Object);

            //Assert
            Assert.IsNotNull(eloquaContext.Contacts);
            Assert.IsInstanceOfType(eloquaContext.Contacts, typeof(IDbSet<Contact>));

            Assert.IsNotNull(eloquaContext.Bulk);
            Assert.IsInstanceOfType(eloquaContext.Bulk, typeof(BulkApi));
        }

        [TestMethod]
        public void CreateClientTest()
        {
            //Arrange

            //Act
            var restClient = EloquaContext.CreateClient("", "", "", new Uri("http://home.com"));

            //
            Assert.IsInstanceOfType(restClient, typeof(IRestClient));
        }

        #region DisableCustomCampaignObjectAsync
        [TestMethod]
        public async Task DbSetDisableCustomCampaignObjectAsyncPassTest()
        {
            //Arrange
            var mockRestResponse = new Mock<IRestResponse>();
            mockRestResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Completed);
            mockRestResponse.SetupGet(o => o.StatusCode).Returns(HttpStatusCode.OK);

            var mockRestClient = new Mock<IRestClient>();

            //Act
            var eloquaContext = new EloquaContext(mockRestClient.Object);


            mockRestClient.Setup(o => o.ExecuteTaskAsync(It.IsAny<IRestRequest>())).ReturnsAsync(mockRestResponse.Object);


            //Act
            var result = await eloquaContext.DisableCustomCampaignObjectsAsync(666, 420, 212);

            //Assert
            Assert.IsFalse(result.HasError);
        }

        [TestMethod]
        public async Task DbSetDisableCustomCampaignObjectAsyncFailTest()
        {
            //Arrange
            var mockRestResponse = new Mock<IRestResponse>();
            mockRestResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Completed);
            mockRestResponse.SetupGet(o => o.StatusCode).Returns(HttpStatusCode.BadRequest);

            var mockRestClient = new Mock<IRestClient>();

            //Act
            var eloquaContext = new EloquaContext(mockRestClient.Object);


            mockRestClient.Setup(o => o.ExecuteTaskAsync(It.IsAny<IRestRequest>())).ReturnsAsync(mockRestResponse.Object);


            //Act
            var result = await eloquaContext.DisableCustomCampaignObjectsAsync(666, 420, 212);

            //Assert
            Assert.IsTrue(result.HasError);
        }

        //[TestMethod]
        //public async Task DbSetDisableCustomCampaignObjectAsyncTest()
        //{
        //    //Arrange
        //    var mockRestResponse = new Mock<IRestResponse>();
        //    mockRestResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Completed);
        //    mockRestResponse.SetupSequence(o => o.StatusCode).Returns(HttpStatusCode.OK).Returns(HttpStatusCode.BadRequest);

        //    var mockRestClient = new Mock<IRestClient>();

        //    //Act
        //    var eloquaContext = new EloquaContext(mockRestClient.Object);

        //    var list = new List<CustomCampaignObjectDto>
        //    {
        //        new CustomCampaignObjectDto
        //        {
        //            ActivationId = 42,
        //            InstanceId = 666
        //        },
        //        new CustomCampaignObjectDto
        //        {
        //            ActivationId = 42,
        //            InstanceId = 666
        //        }
        //    };

        //    mockRestClient.Setup(o => o.ExecuteTaskAsync(It.IsAny<IRestRequest>())).ReturnsAsync(mockRestResponse.Object);


        //    //Act
        //    var results =  await eloquaContext.DisableCustomCampaignObjectsAsync(list);

        //    //Assert
        //    Assert.AreEqual(results.Count, 2);
        //    Assert.AreEqual(1,results.Count(o => o.Status == HttpStatusCode.OK));
        //    Assert.AreEqual(1,results.Count(o => o.Status == HttpStatusCode.BadRequest));
        //}
        #endregion
    }
}