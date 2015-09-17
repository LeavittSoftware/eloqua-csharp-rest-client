//using System.Linq;
//using System.Net;
//using System.Threading.Tasks;
//using LG.Eloqua.Api.Rest.ClientLibrary.Exceptions;
//using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using RestSharp;

//namespace LG.Eloqua.Api.Rest.ClientLibrary.Tests.Unit
//{
//    [TestClass]
//    public class DataContactUnitTests
//    {

//        [TestMethod]
//        public async Task ContactGetSuccessUnitTest()
//        {
//            //Arrange
//            var restResponse = new Mock<IRestResponse<Contact>>();
//            restResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Completed);
//            restResponse.SetupGet(o => o.Data).Returns(new Contact { EmailAddress = "Test@test.com" });

//            var restClient = new Mock<IRestClient>();
//            restClient.Setup(o => o.ExecuteTaskAsync<Contact>(It.IsAny<IRestRequest>())).ReturnsAsync(restResponse.Object);

//            var client = new Client(new BaseClient(restClient.Object));

//            //Act
//            var contact = await client.Data.Contacts.GetAsync(1, Depth.Complete);

//            //Assert
//            Assert.AreEqual("Test@test.com", contact.EmailAddress);
//        }

//        [TestMethod]
//        [ExpectedException(typeof(ConnectionErrorException))]
//        public async Task ContactGetTimedOutUnitTest()
//        {
//            //Arrange
//            var restResponse = new Mock<IRestResponse<Contact>>();
//            restResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.TimedOut);
//            restResponse.SetupGet(o => o.Data).Returns(new Contact());

//            var restClient = new Mock<IRestClient>();
//            restClient.Setup(o => o.ExecuteTaskAsync<Contact>(It.IsAny<IRestRequest>())).ReturnsAsync(restResponse.Object);

//            var client = new Client(new BaseClient(restClient.Object));

//            //Act
//            await client.Data.Contacts.GetAsync(1, Depth.Complete);

//            //Assert -throws
//        }

//        [TestMethod]
//        [ExpectedException(typeof(ConnectionErrorException))]
//        public async Task ContactGetAbortedOutUnitTest()
//        {
//            //Arrange
//            var restResponse = new Mock<IRestResponse<Contact>>();
//            restResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Aborted);
//            restResponse.SetupGet(o => o.Data).Returns(new Contact());

//            var restClient = new Mock<IRestClient>();
//            restClient.Setup(o => o.ExecuteTaskAsync<Contact>(It.IsAny<IRestRequest>())).ReturnsAsync(restResponse.Object);

//            var client = new Client(new BaseClient(restClient.Object));

//            //Act
//            await client.Data.Contacts.GetAsync(1, Depth.Complete);

//            //Assert -throws
//        }

//        [TestMethod]
//        public async Task ContactGetConflictUnitTest()
//        {
//            //Arrange
//            var restResponse = new Mock<IRestResponse<Contact>>();
//            restResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.None);
//            restResponse.SetupGet(o => o.StatusCode).Returns(HttpStatusCode.Conflict);
//            restResponse.SetupGet(o => o.Data).Returns(new Contact());
//            restResponse.SetupGet(o => o.Content).Returns(@"[
//    {
//        ""Container"": {
//            ""Container"": ""Test"",
//            ""ObjectId"": 1,
//            ""ObjectType"": ""string""
//        },
//        ""Property"": ""SomePropName"",
//        ""Requirement"": ""DuplicateId"",
//        ""Value"": ""22""
//    }
//]");

//            var restClient = new Mock<IRestClient>();
//            restClient.Setup(o => o.ExecuteTaskAsync<Contact>(It.IsAny<IRestRequest>())).ReturnsAsync(restResponse.Object);
//            var client = new Client(new BaseClient(restClient.Object));


//            try
//            {
//                //Act
//                await client.Data.Contacts.GetAsync(1, Depth.Complete);
//            }
//            catch (ValidationException ex)
//            {
//                //Assert 
//                Assert.AreEqual(1, ex.ValidationError.Count);
//                Assert.AreEqual("Test", ex.ValidationError.First().Container.Container);
//            }
//        }
//    }
//}
