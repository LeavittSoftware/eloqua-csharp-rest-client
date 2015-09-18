using Microsoft.VisualStudio.TestTools.UnitTesting;
using LG.Eloqua.Api.Rest.ClientLibrary;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts;
using LG.Eloqua.Api.Rest.ClientLibrary.Tests.Unit;
using Moq;
using RestSharp;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Tests
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