using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.CustomObjects;
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
        #endregion

        #region UpdateCustomCampaignObjectAsync
        [TestMethod]
        public async Task DbSetUpdateCustomCampaignObjectAsyncPassTest()
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
            var result = await eloquaContext.UpdateCustomCampaignObjectsAsync(0, 666, 420, 212);

            //Assert
            Assert.IsFalse(result.HasError);
        }

        [TestMethod]
        public async Task DbSetUpdateCustomCampaignObjectAsyncFailTest()
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
            var result = await eloquaContext.UpdateCustomCampaignObjectsAsync(0, 666, 420, 212);

            //Assert
            Assert.IsTrue(result.HasError);
        }
        #endregion

        #region SearchCustomCampaignObjectAsync
        [TestMethod]
        public async Task SearchCustomCampaignObjectAsyncPassTest()
        {
            //Arrange
            const string customObjectJson = @"{
                'elements': [
                {
                    'type': 'CustomObjectData',
                    'id': '10',
                    'createdAt': '1538070228',
                    'depth': 'minimal',
                    'name': 'test@test.com',
                    'updatedAt': '1538162787',
                    'contactId': '11',
                    'fieldValues': [
                    {
                        'type': 'FieldValue',
                        'id': '20',
                        'value': 'test@test.com'
                    },
                    {
                        'type': 'FieldValue',
                        'id': '21',
                        'value': '0'
                    },
                    {
                        'type': 'FieldValue',
                        'id': '22',
                        'value': '0'
                    }
                    ],
                    'isMapped': 'Yes',
                    'uniqueCode': 'test@test.com'
                }
                ],
                'page': 1,
                'pageSize': 1000,
                'total': 1
            }";
            var mockRestResponse = new Mock<IRestResponse>();
            mockRestResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Completed);
            mockRestResponse.SetupGet(o => o.StatusCode).Returns(HttpStatusCode.OK);
            mockRestResponse.SetupGet(o => o.Content).Returns(customObjectJson);

            var mockRestClient = new Mock<IRestClient>();

            //Act
            var eloquaContext = new EloquaContext(mockRestClient.Object);


            mockRestClient.Setup(o => o.ExecuteTaskAsync(It.IsAny<IRestRequest>())).ReturnsAsync(mockRestResponse.Object);


            //Act
            var result = await eloquaContext.SearchCustomCampaignObjectsAsync("test@test.com");

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<CustomObjectData>));

            
            Assert.AreEqual(10, result[0].Id);
        }
        #endregion

        #region CreateCustomCampaignObjectAsync
        [TestMethod]
        public async Task CreateCustomCampaignObjectAsyncPassTest()
        {
            //Arrange
            var mockRestResponse = new Mock<IRestResponse>();
            mockRestResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Completed);
            mockRestResponse.SetupGet(o => o.StatusCode).Returns(HttpStatusCode.OK);
            mockRestResponse.SetupGet(o => o.IsSuccessful).Returns(true);

            var mockRestClient = new Mock<IRestClient>();

            //Act
            var eloquaContext = new EloquaContext(mockRestClient.Object);


            mockRestClient.Setup(o => o.ExecuteTaskAsync(It.IsAny<IRestRequest>())).ReturnsAsync(mockRestResponse.Object);


            //Act
            var result = await eloquaContext.CreateCustomCampaignObjectsAsync("test@test.com",1,0,10);

            //Assert
            Assert.IsTrue(result.IsSuccessful);
        }
        #endregion

    }
}