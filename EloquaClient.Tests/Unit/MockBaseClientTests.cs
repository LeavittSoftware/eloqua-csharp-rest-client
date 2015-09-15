using System;
using System.Net;
using System.Threading.Tasks;
using Eloqua.Api.Rest.ClientLibrary.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;
using Contact = Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts.Contact;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Unit
{
    [TestClass]
    public class DataContactUnitTests
    {

        [TestMethod]
        public async Task ContactGetSuccessUnitTest()
        {
            //Arrange
            var restResponse = new Mock<IRestResponse<Contact>>();
            restResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Completed);
            restResponse.SetupGet(o => o.Data).Returns(new Contact { EmailAddress = "Test@test.com" });

            var restClient = new Mock<IRestClient>();
            restClient.Setup(o => o.ExecuteTaskAsync<Contact>(It.IsAny<IRestRequest>())).ReturnsAsync(restResponse.Object);

            var client = new Client(new BaseClient(restClient.Object));

            //Act
            var contact = await client.Data.Contact.GetAsync(1, Depth.Complete);

            //Assert
            Assert.AreEqual("Test@test.com", contact.EmailAddress);
        }

        [TestMethod]
        [ExpectedException(typeof(ConnectionErrorException))]
        public async Task ContactGetTimedOutUnitTest()
        {
            //Arrange
            var restResponse = new Mock<IRestResponse<Contact>>();
            restResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.TimedOut);
            restResponse.SetupGet(o => o.Data).Returns(new Contact());

            var restClient = new Mock<IRestClient>();
            restClient.Setup(o => o.ExecuteTaskAsync<Contact>(It.IsAny<IRestRequest>())).ReturnsAsync(restResponse.Object);

            var client = new Client(new BaseClient(restClient.Object));

            //Act
            await client.Data.Contact.GetAsync(1, Depth.Complete);

            //Assert -throws
        }

        [TestMethod]
        [ExpectedException(typeof(ConnectionErrorException))]
        public async Task ContactGetAbortedOutUnitTest()
        {
            //Arrange
            var restResponse = new Mock<IRestResponse<Contact>>();
            restResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Aborted);
            restResponse.SetupGet(o => o.Data).Returns(new Contact());

            var restClient = new Mock<IRestClient>();
            restClient.Setup(o => o.ExecuteTaskAsync<Contact>(It.IsAny<IRestRequest>())).ReturnsAsync(restResponse.Object);

            var client = new Client(new BaseClient(restClient.Object));

            //Act
            await client.Data.Contact.GetAsync(1, Depth.Complete);

            //Assert -throws
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public async Task ContactGetConflictUnitTest()
        {
            //Arrange
            var restResponse = new Mock<IRestResponse<Contact>>();
            restResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.None);
            restResponse.SetupGet(o => o.StatusCode).Returns(HttpStatusCode.Conflict);
            restResponse.SetupGet(o => o.Data).Returns(new Contact());

            var restClient = new Mock<IRestClient>();
            restClient.Setup(o => o.ExecuteTaskAsync<Contact>(It.IsAny<IRestRequest>())).ReturnsAsync(restResponse.Object);

            var client = new Client(new BaseClient(restClient.Object));

            //Act
            await client.Data.Contact.GetAsync(1, Depth.Complete);

            //Assert -throws
        }



    }
}
