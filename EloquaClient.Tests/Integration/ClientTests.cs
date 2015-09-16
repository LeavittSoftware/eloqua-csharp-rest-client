using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Tests.Integration
{
    [Ignore]
    [TestClass]
    public class ClientTests
    {
        private const string Username = "";
        private const string Password = "";

        [TestMethod]
        public async Task TestMethod1()
        {
            //Arrange
            var emailAddress = "";
            var client = new Client(new BaseClient("", Username, Password, new Uri("https://secure.eloqua.com/API/REST/1.0/")));

            //Act
            var existingContact = await client.Data.Contact.GetAsync(emailAddress, 1, 1);

            //Assert
            Assert.AreEqual(1, existingContact.Elements.Count);
        }
    }
}
