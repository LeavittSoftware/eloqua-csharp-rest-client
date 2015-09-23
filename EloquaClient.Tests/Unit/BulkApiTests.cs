using System;
using System.Net;
using System.Threading.Tasks;
using LG.Eloqua.Api.Rest.ClientLibrary.Exceptions;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.CustomObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using RestSharp;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Tests.Unit
{
    [TestClass()]
    public class BulkApiTests
    {
        [ExpectedException(typeof(DbSetException))]
        [TestMethod]
        public async Task CreateCustomObjectDataAsyncNullAttributeTest()
        {
            //Arrange
            var mockRestClient = new Mock<IRestClient>();

            var bulkApi = new BulkApi(mockRestClient.Object);

            //Act
            await bulkApi.CreateCustomObjectDataAsync(1, new MockInvalidCustomObjectData());

            //Assert - throws
        }

        [ExpectedException(typeof(JsonSerializationException))]
        [TestMethod]
        public async Task CreateCustomObjectDataAsyncDeserializeObjectErrorTest()
        {
           
            //Arrange
            var mockRestResponse = new Mock<IRestResponse>();
            mockRestResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Completed);
            mockRestResponse.SetupGet(o => o.StatusCode).Returns(HttpStatusCode.OK);
            mockRestResponse.SetupGet(o => o.Content).Returns(@"{
                  ""contactId"": ""48620"",
                
            ");

            var mockRestClient = new Mock<IRestClient>();
            mockRestClient.Setup(o => o.ExecuteTaskAsync(It.IsAny<IRestRequest>())).ReturnsAsync(mockRestResponse.Object);

            var bulkApi = new BulkApi(mockRestClient.Object);

            //Act
            await bulkApi.CreateCustomObjectDataAsync(1, new MockCustomObjectData());

            //Assert - throws
        }

        [TestMethod]
        public async Task CreateCustomObjectDataAsyncTest()
        {
            //Arrange
            var mockRestResponse = new Mock<IRestResponse>();
            mockRestResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Completed);
            mockRestResponse.SetupGet(o => o.StatusCode).Returns(HttpStatusCode.OK);
            mockRestResponse.SetupGet(o => o.Content).Returns(@"
                {""createdAt"": ""2015-09-23T17:53:08.6076269Z""}
                
            ");

            var mockRestClient = new Mock<IRestClient>();
            mockRestClient.Setup(o => o.ExecuteTaskAsync(It.IsAny<IRestRequest>())).ReturnsAsync(mockRestResponse.Object);

            var bulkApi = new BulkApi(mockRestClient.Object);

            //Act
            var result = await bulkApi.CreateCustomObjectDataAsync(1, new MockCustomObjectData());

            //Assert
            Assert.AreEqual(DateTime.Parse("2015-09-23 5:53:08.6076269 PM"), result);
        }

        [TestMethod]
        public async Task CreateCustomObjectDataAsyncNotCreatedTest()
        {
            //Arrange
            var mockRestResponse = new Mock<IRestResponse>();
            mockRestResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Completed);
            mockRestResponse.SetupGet(o => o.StatusCode).Returns(HttpStatusCode.OK);
            mockRestResponse.SetupGet(o => o.Content).Returns(@"
                {""updated"": ""2015-09-23T17:53:08.6076269Z""}
                
            ");

            var mockRestClient = new Mock<IRestClient>();
            mockRestClient.Setup(o => o.ExecuteTaskAsync(It.IsAny<IRestRequest>())).ReturnsAsync(mockRestResponse.Object);

            var bulkApi = new BulkApi(mockRestClient.Object);

            //Act
            var result = await bulkApi.CreateCustomObjectDataAsync(1, new MockCustomObjectData());

            //Assert
            Assert.IsNull(result);
        }

        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public async Task CreateCustomObjectDataAsyncBadRequestTest()
        {
            //Arrange
            var mockRestResponse = new Mock<IRestResponse>();
            mockRestResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Completed);
            mockRestResponse.SetupGet(o => o.StatusCode).Returns(HttpStatusCode.BadRequest);
            mockRestResponse.SetupGet(o => o.Content).Returns(@"
                {""updated"": ""2015-09-23T17:53:08.6076269Z""}
                
            ");

            var mockRestClient = new Mock<IRestClient>();
            mockRestClient.Setup(o => o.ExecuteTaskAsync(It.IsAny<IRestRequest>())).ReturnsAsync(mockRestResponse.Object);

            var bulkApi = new BulkApi(mockRestClient.Object);

            //Act
            var result = await bulkApi.CreateCustomObjectDataAsync(1, new MockCustomObjectData());

            //Assert - throws
        }

        public class MockInvalidCustomObjectData : CustomObjectData
        {
            public string ApplicationId { get; set; }

        }
        [EloquaCustomObject(37)]
        public class MockCustomObjectData : CustomObjectData
        {
            public string ApplicationId { get; set; }

        }
    }
}