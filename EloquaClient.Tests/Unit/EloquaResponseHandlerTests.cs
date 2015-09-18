using System.Net;
using LG.Eloqua.Api.Rest.ClientLibrary.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Tests.Unit
{
    [TestClass()]
    public class EloquaResponseHandlerTests
    {
        [ExpectedException(typeof(ConnectionErrorException))]
        [TestMethod]
        public void ResponseStatusTimedOutTest()
        {
            //Arrange
            var mockRestResponse = new Mock<IRestResponse>();
            mockRestResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.TimedOut);

            //Act
            EloquaResponseHandler.ErrorCheck(mockRestResponse.Object);

            //Assert - throws
        }

        [ExpectedException(typeof(ConnectionErrorException))]
        [TestMethod]
        public void ResponseStatusAbortedTest()
        {
            //Arrange
            var mockRestResponse = new Mock<IRestResponse>();
            mockRestResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Aborted);

            //Act
            EloquaResponseHandler.ErrorCheck(mockRestResponse.Object);

            //Assert - throws
        }

        [ExpectedException(typeof(EloquaApiException))]
        [TestMethod]
        public void ResponseStatusNoneTest()
        {
            //Arrange
            var mockRestResponse = new Mock<IRestResponse>();
            mockRestResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.None);

            //Act
            EloquaResponseHandler.ErrorCheck(mockRestResponse.Object);

            //Assert - throws
        }

        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void ResponseStatusCompleted_StatusCodeBadRequestTest()
        {
            //Arrange
            var mockRestResponse = new Mock<IRestResponse>();
            mockRestResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Completed);
            mockRestResponse.SetupGet(o => o.StatusCode).Returns(HttpStatusCode.BadRequest);
            mockRestResponse.SetupGet(o => o.Content).Returns(@"[{
		            ""type"" : ""ObjectValidationError"",
		            ""container"" : {
			            ""type"" : ""ObjectKey"",
			            ""objectType"" : ""Contact""
		            },
		            ""property"" : ""emailAddress"",
		            ""requirement"" : {
			            ""type"" : ""EmailAddressRequirement""
		            },
		            ""value"" : ""<null>""
            }]
            ");

            //Act
            EloquaResponseHandler.ErrorCheck(mockRestResponse.Object);

            //Assert - throws
        }

        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void ResponseStatusCompleted_StatusCodeConflictTest()
        {
            //Arrange
            var mockRestResponse = new Mock<IRestResponse>();
            mockRestResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Completed);
            mockRestResponse.SetupGet(o => o.StatusCode).Returns(HttpStatusCode.Conflict);
            mockRestResponse.SetupGet(o => o.Content).Returns(@"[{
		            ""type"" : ""ObjectValidationError"",
		            ""container"" : {
			            ""type"" : ""ObjectKey"",
			            ""objectType"" : ""Contact""
		            },
		            ""property"" : ""emailAddress"",
		            ""requirement"" : {
			            ""type"" : ""EmailAddressRequirement""
		            },
		            ""value"" : ""<null>""
            }]
            ");
            //Act
            EloquaResponseHandler.ErrorCheck(mockRestResponse.Object);

            //Assert - throws
        }

        [ExpectedException(typeof(EloquaApiException))]
        [TestMethod]
        public void ResponseStatusCompleted_StatusCodeNotFound_NoContentTest()
        {
            //Arrange
            var mockRestResponse = new Mock<IRestResponse>();
            mockRestResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Completed);
            mockRestResponse.SetupGet(o => o.StatusCode).Returns(HttpStatusCode.NotFound);
            mockRestResponse.SetupGet(o => o.Content).Returns("Not Found");

            //Act
            EloquaResponseHandler.ErrorCheck(mockRestResponse.Object);

            //Assert - throws
        }

        [TestMethod]
        public void ResponseStatusCompleted_StatusCodeNotFoundTest()
        {
            //Arrange
            var mockRestResponse = new Mock<IRestResponse>();
            mockRestResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Completed);
            mockRestResponse.SetupGet(o => o.StatusCode).Returns(HttpStatusCode.NotFound);
            

            //Act
            var response = EloquaResponseHandler.ErrorCheck(mockRestResponse.Object);

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void ResponseStatusCompleted_StatusCodeOKTest()
        {
            //Arrange
            var mockRestResponse = new Mock<IRestResponse>();
            mockRestResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Completed);
            mockRestResponse.SetupGet(o => o.StatusCode).Returns(HttpStatusCode.OK);
            mockRestResponse.SetupGet(o => o.Content).Returns("Response Ok");

            //Act
            var response = EloquaResponseHandler.ErrorCheck(mockRestResponse.Object);

            //Assert
            Assert.AreEqual("Response Ok", response.Content);
        }

        [TestMethod]
        public void ResponseStatusCompleted_StatusCodeAcceptedTest()
        {
            //Arrange
            var mockRestResponse = new Mock<IRestResponse>();
            mockRestResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Completed);
            mockRestResponse.SetupGet(o => o.StatusCode).Returns(HttpStatusCode.Accepted);
            mockRestResponse.SetupGet(o => o.Content).Returns("Response Ok");

            //Act
            var response = EloquaResponseHandler.ErrorCheck(mockRestResponse.Object);

            //Assert 
            Assert.AreEqual("Response Ok", response.Content);
        }

        [TestMethod]
        public void ResponseStatusCompleted_StatusCodeCreatedTest()
        {
            //Arrange
            var mockRestResponse = new Mock<IRestResponse>();
            mockRestResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Completed);
            mockRestResponse.SetupGet(o => o.StatusCode).Returns(HttpStatusCode.Created);
            mockRestResponse.SetupGet(o => o.Content).Returns("Response Ok");

            //Act
            var response = EloquaResponseHandler.ErrorCheck(mockRestResponse.Object);

            //Assert
            Assert.AreEqual("Response Ok", response.Content);
        }

        [TestMethod]
        public void ResponseStatusCompleted_StatusCodeFoundTest()
        {
            //Arrange
            var mockRestResponse = new Mock<IRestResponse>();
            mockRestResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Completed);
            mockRestResponse.SetupGet(o => o.StatusCode).Returns(HttpStatusCode.Found);
            mockRestResponse.SetupGet(o => o.Content).Returns("Response Ok");

            //Act
            var response = EloquaResponseHandler.ErrorCheck(mockRestResponse.Object);

            //Assert
            Assert.AreEqual("Response Ok", response.Content);
        }

        [TestMethod]
        public void ResponseStatusCompleted_StatusCodeNoContentTest()
        {
            //Arrange
            var mockRestResponse = new Mock<IRestResponse>();
            mockRestResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Completed);
            mockRestResponse.SetupGet(o => o.StatusCode).Returns(HttpStatusCode.NoContent);
            mockRestResponse.SetupGet(o => o.Content).Returns("Response Ok");

            //Act
            var response = EloquaResponseHandler.ErrorCheck(mockRestResponse.Object);

            //Assert
            Assert.AreEqual("Response Ok", response.Content);
        }

        [ExpectedException(typeof(EloquaApiException))]
        [TestMethod]
        public void ResponseStatusCompleted_StatuscodeDefaultTest()
        {
            //Arrange
            var mockRestResponse = new Mock<IRestResponse>();
            mockRestResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Completed);
            mockRestResponse.SetupGet(o => o.StatusCode).Returns(HttpStatusCode.Continue);
            mockRestResponse.SetupGet(o => o.Content).Returns("Response Ok");

            //Act
            EloquaResponseHandler.ErrorCheck(mockRestResponse.Object);

            //Assert - throws
        }

    }
}