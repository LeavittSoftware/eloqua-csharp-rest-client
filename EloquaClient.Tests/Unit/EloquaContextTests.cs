using System;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Tests.Unit
{
    [TestClass()]
    public class EloquaContextTests
    {
        [TestMethod()]
        public void EloquaContextTest()
        {
            //Arrange
            var mockRestClient = new Mock<IRestClient>();

            //Act
            var eloquaContext = new EloquaContext(mockRestClient.Object);

            //Assert
            Assert.IsNotNull(eloquaContext.Contacts);
            Assert.IsInstanceOfType(eloquaContext.Contacts, typeof(IDbSet<Contact>));
        }

        [TestMethod()]
        public void CreateClientTest()
        {
            //Arrange

            //Act
            var restClient = EloquaContext.CreateClient("", "", "", new Uri("http://home.com"));

            //
            Assert.IsInstanceOfType(restClient, typeof(IRestClient));
        }

    }
}