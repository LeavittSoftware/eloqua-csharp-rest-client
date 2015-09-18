using System;
using System.Threading.Tasks;
using LG.Eloqua.Api.Rest.ClientLibrary.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Tests.Integration
{
    [Ignore]
    [TestClass]
    public class ClientTests
    {
        private string Username = "";
        private string Password = "";

        [TestMethod]
        public async Task GetTest()
        {
            //Arrange
            var client = new LgEloquaContext(EloquaContext.CreateClient("LeavittGroupAgencyAssociationLLC", Username, Password, new Uri("https://secure.eloqua.com/API/REST/1.0/")));

            //Act
            var existingContact = await client.Contacts.GetAsync(48620, Depth.Complete);

            //Assert
            Assert.IsNotNull(existingContact);
            Assert.IsNotNull(existingContact.Id);
            Assert.IsNotNull(existingContact.EmailAddress);
        }

        [TestMethod]
        public async Task GetNotFoundTest()
        {
            //Arrange
            var client = new LgEloquaContext(EloquaContext.CreateClient("LeavittGroupAgencyAssociationLLC", Username, Password, new Uri("https://secure.eloqua.com/API/REST/1.0/")));

            //Act
            var existingContact = await client.Contacts.GetAsync(486201111, Depth.Complete);

            //Assert
            Assert.IsNull(existingContact);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task GetBadUrlTest()
        {
            //Arrange
            var client = new LgEloquaContext(EloquaContext.CreateClient("LeavittGroupAgencyAssociationLLC", Username, Password, new Uri("https://secure.eloqua.com/API/REST/1.0/")));

            //Act
            var existingContact = await client.BadContacts.GetAsync(486201, Depth.Complete);

            //Assert
            Assert.IsNull(existingContact);
        }

        [TestMethod]
        public async Task SearchTest()
        {

            var emailAddress = "aaron-drabeck12@leavitt.com";

            //Arrange
            var client = new LgEloquaContext(EloquaContext.CreateClient("LeavittGroupAgencyAssociationLLC", Username, Password, new Uri("https://secure.eloqua.com/API/REST/1.0/")));

            //Act
            var result = await client.Contacts.SearchAsync("*aaron*");


            //Assert
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod]
        public async Task PostTest()
        {

            var emailAddress = "aaron-drabeck15@leavitt.com";

            //Arrange
            var client = new LgEloquaContext(EloquaContext.CreateClient("LeavittGroupAgencyAssociationLLC", Username, Password, new Uri("https://secure.eloqua.com/API/REST/1.0/")));

            //Act
            var result = await client.LgContacts.PostAsync(new LgContact
            {
                EmailAddress = emailAddress,
                Name = emailAddress,
                Address1 = "Test home number 1",
                RefUrl = "testLink.com"
            });

            //Assert
            Assert.AreEqual("testLink.com", result.RefUrl);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public async Task PostDuplicateTest()
        {

            var emailAddress = "aaron-drabeck14@leavitt.com";

            //Arrange
            var client = new LgEloquaContext(EloquaContext.CreateClient("LeavittGroupAgencyAssociationLLC", Username, Password, new Uri("https://secure.eloqua.com/API/REST/1.0/")));

            //Act
            var result = await client.LgContacts.PostAsync(new LgContact
            {
                EmailAddress = emailAddress,
                Name = emailAddress,
                Address1 = "Test home number 1",
                RefUrl = "testLink.com"
            });

            //Assert - throws
        }

        [TestMethod]
        public async Task PostInvalidCustomPropTest()
        {

            var emailAddress = "aaron-drabeck18@leavitt.com";

            //Arrange
            var client = new LgEloquaContext(EloquaContext.CreateClient("LeavittGroupAgencyAssociationLLC", Username, Password, new Uri("https://secure.eloqua.com/API/REST/1.0/")));

            //Act
            var result = await client.ExtendedContacts.PostAsync(new ExtendedContact
            {
                EmailAddress = emailAddress,
                Name = emailAddress,
                Address1 = "Test home number 1",
                Test = "testLink.com"
            });

            //Assert
            Assert.IsNull(result.Test);
        }

        [TestMethod]
        public async Task PutTest()
        {

            var emailAddress = "aaron-drabeck13@leavitt.com";

            //Arrange
            var client = new LgEloquaContext(EloquaContext.CreateClient("LeavittGroupAgencyAssociationLLC", Username, Password, new Uri("https://secure.eloqua.com/API/REST/1.0/")));

            //Act
            var result = await client.LgContacts.PutAsync(new LgContact
            {
                Id = 48658,
                EmailAddress = emailAddress,
                // Name = emailAddress,
                //Address1 = "Test home number 1",
                // RefUrl = "testLink.com",
                // County = "Iron",
                HomeOwner = "YES"

            });

            //Assert
            Assert.AreEqual("testLink.com", result.RefUrl);
        }

    }
}
