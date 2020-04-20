using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LG.Eloqua.Api.Rest.ClientLibrary.Exceptions;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Assets.Campaign;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Assets.Email;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Tests.Integration
{
    [Ignore]
    [TestClass]
    public class ClientTests
    {
        private const string Username = "Leavitt.Group";
        private const string Password = "7q7T8G^mN!3^";
        [TestMethod]
        public async Task GetTest()
        {
            //Arrange
            var client = new LgEloquaContext(EloquaContext.CreateClient("LeavittGroupAgencyAssociationLLC", Username, Password, new Uri("https://secure.eloqua.com")));

            //Act
            var existingContact = await client.Contacts.GetAsync(39919, Depth.Complete);

            //Assert
            Assert.IsNotNull(existingContact);
            Assert.IsNotNull(existingContact.Id);
            Assert.IsNotNull(existingContact.EmailAddress);
        }

        [TestMethod]
        public async Task GetEmailTest()
        {
            //Arrange
            var client = new LgEloquaContext(EloquaContext.CreateClient("LeavittGroupAgencyAssociationLLC", Username, Password, new Uri("https://secure.p01.eloqua.com")));

            //Act
            var existingContact = await client.Emails.GetAsync(509, Depth.Complete);

            //Assert
            Assert.IsNotNull(existingContact);
            Assert.IsNotNull(existingContact.Id);
            Assert.IsNotNull(existingContact.Subject);
            Assert.IsTrue(existingContact.Subject.Contains("Spring Cleaning for Your Car"));
        }

        [TestMethod]
        public async Task GetEmailsTest()
        {
            //Arrange
            var client = new LgEloquaContext(EloquaContext.CreateClient("LeavittGroupAgencyAssociationLLC", Username, Password, new Uri("https://secure.p01.eloqua.com")));

            //Act
            var existingContact = await client.Emails.GetListAsync("", "name='LL Seasonal*'", 1, 1, Depth.Complete);

            //Assert
            Assert.IsNotNull(existingContact);
            Assert.AreEqual(1000, existingContact.Count);
            Assert.IsInstanceOfType(existingContact.First(), typeof(Email));
        }

        [TestMethod]
        public async Task GetCampaignsTest()
        {
            //Arrange
            var client = new LgEloquaContext(EloquaContext.CreateClient("LeavittGroupAgencyAssociationLLC", Username, Password, new Uri("https://secure.p01.eloqua.com")));

            //Act
            var existingContact = await client.Campaigns.GetListAsync("", "name='Daniel*'", 1000, 1, Depth.Partial);

            //Assert
            Assert.IsNotNull(existingContact);
            Assert.AreEqual(1000, existingContact.Count);
            Assert.IsInstanceOfType(existingContact.First(), typeof(Campaign));
        }

        [TestMethod]
        public async Task GetEmailPreviewUrlTest()
        {
            //Arrange
            var client = new LgEloquaContext(EloquaContext.CreateClient("LeavittGroupAgencyAssociationLLC", Username, Password, new Uri("https://secure.p01.eloqua.com")));

            //Act
            var result = await client.GetEmailPreviewUrl(510, 39919, 448);

            //Assert
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.Value));
        }

        [TestMethod]
        public async Task GetUsersTest()
        {
            //Arrange
            var client = new LgEloquaContext(EloquaContext.CreateClient("LeavittGroupAgencyAssociationLLC", Username, Password, new Uri("https://secure.p01.eloqua.com")));

            //Act
            var existingUser = await client.Users.GetListAsync("", "emailAddress='test@test.com'", 1000, 1, Depth.Minimal);

            //Assert
            Assert.IsNotNull(existingUser);
            Assert.AreEqual(1, existingUser.Count);
            Assert.IsInstanceOfType(existingUser.First(), typeof(User));
        }

        [TestMethod]
        public async Task PostEmailDepolymentTest()
        {
            //Arrange
            var client = new LgEloquaContext(EloquaContext.CreateClient("LeavittGroupAgencyAssociationLLC", Username, Password, new Uri("https://secure.p01.eloqua.com")));

            var emailDeployment = new EmailDeployment
            {
                ContactIds = new List<string>
                {
                    "39919"
                },
                Email = new Email
                {
                    Id = 3772,
                    Name = "test"
                },
                Name = "Test Email deployment"

            };

            //Act
            var existingContact = await client.EmailDeployments.PostAsync(emailDeployment);

            //Assert
            Assert.IsNotNull(existingContact);
        }

        [TestMethod]
        public async Task GetNotFoundTest()
        {
            //Arrange
            var client = new LgEloquaContext(EloquaContext.CreateClient("LeavittGroupAgencyAssociationLLC", Username, Password, new Uri("https://secure.eloqua.com")));

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
            var client = new LgEloquaContext(EloquaContext.CreateClient("LeavittGroupAgencyAssociationLLC", Username, Password, new Uri("https://secure.eloqua.com")));

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
            var client = new LgEloquaContext(EloquaContext.CreateClient("LeavittGroupAgencyAssociationLLC", Username, Password, new Uri("https://secure.eloqua.com")));

            //Act
            var result = await client.Contacts.SearchAsync("*aaron*");


            //Assert
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod]
        public async Task PostTest()
        {

            var emailAddress = "test3343i@leavitt.com";

            //Arrange
            var client = new LgEloquaContext(EloquaContext.CreateClient("LeavittGroupAgencyAssociationLLC", Username, Password, new Uri("https://secure.eloqua.com")));

            //Act
            try
            {
                var result = await client.LgContacts.PostAsync(new LgContact
                {
                    EmailAddress = emailAddress,
                    FirstName = "Aaron",
                    LastName = "Drabeck",
                    BusinessPhone = "555-1212",
                    RefUrl = "testLink.com",
                    SmsText = "no",
                    MobilePhone = "555-1515",
                    ResidentialPhone = "55-1616",
                    ZipCode = "84720-555",
                    ContactId = "122",
                    LeadSource = "Google",
                    DateOfBirth = new DateTime(1983, 08, 31),
                    Employee = 1222222.23123123213213213213213123123123123123213213213213213123
                });


                //Assert
                Assert.AreEqual("testLink.com", result.RefUrl);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public async Task PostDuplicateTest()
        {

            var emailAddress = "aaron-drabeck14@leavitt.com";

            //Arrange
            var client = new LgEloquaContext(EloquaContext.CreateClient("LeavittGroupAgencyAssociationLLC", Username, Password, new Uri("https://secure.eloqua.com")));

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
            var client = new LgEloquaContext(EloquaContext.CreateClient("LeavittGroupAgencyAssociationLLC", Username, Password, new Uri("https://secure.eloqua.com")));

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
            var client = new LgEloquaContext(EloquaContext.CreateClient("LeavittGroupAgencyAssociationLLC", Username, Password, new Uri("https://secure.eloqua.com")));

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


        [TestMethod]
        public async Task PostCreateCustomCampaignObjectApiTest()
        {

            //Arrange
            var client = new EloquaContext(EloquaContext.CreateClient("LeavittGroupAgencyAssociationLLC", Username, Password, new Uri("https://secure.eloqua.com")));

            var application = new LgApplication
            {
                ContactId = "48708",
                ApplicationId = "testsAppId24",
                CurrentLiabilityLimits = "100/200/50",
                CurrentPolicyExpirationDate = DateTime.Now,
                InsuredInLast30 = "Yes",
                MonthsInsured = "50000",
                PolicyStartDate = DateTime.Now
            };



            //Act
            var result = await client.CreateCustomCampaignObjectsAsync("testthiswillwork3@thiswillworktest.com", 526906, 1, 2112);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task PostCustomObjectBulkApiTest()
        {

            //Arrange
            var client = new EloquaContext(EloquaContext.CreateClient("LeavittGroupAgencyAssociationLLC", Username, Password, new Uri("https://secure.eloqua.com")));

            var application = new LgApplication
            {
                ContactId = "48708",
                ApplicationId = "testsAppId24",
                CurrentLiabilityLimits = "100/200/50",
                CurrentPolicyExpirationDate = DateTime.Now,
                InsuredInLast30 = "Yes",
                MonthsInsured = "50000",
                PolicyStartDate = DateTime.Now
            };



            //Act
            var result = await client.Bulk.CreateCustomObjectDataAsync(3326, application);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task DisableCustomCampaignObjectsAsyncTest()
        {

            //Arrange
            var client = new LgEloquaContext(EloquaContext.CreateClient("LeavittGroupAgencyAssociationLLC", Username, Password, new Uri("https://secure.eloqua.com")));

            //Act
            var result = await client.DisableCustomCampaignObjectsAsync(7792181, 2110);

            //Assert
            Assert.IsFalse(result.HasError);
        }

        [TestMethod]
        public async Task UpdateCustomCampaignObjectsAsyncTest()
        {

            //Arrange
            var client = new LgEloquaContext(EloquaContext.CreateClient("LeavittGroupAgencyAssociationLLC", Username, Password, new Uri("https://secure.eloqua.com")));

            //Act
            var result = await client.UpdateCustomCampaignObjectsAsync(0, 7792181, 2110);

            //Assert
            Assert.IsFalse(result.HasError);
        }

        [TestMethod]
        public async Task SearchCustomCampaignObjectsAsyncTest()
        {

            //Arrange
            var client = new LgEloquaContext(EloquaContext.CreateClient("LeavittGroupAgencyAssociationLLC", Username, Password, new Uri("https://secure.eloqua.com")));

            //Act
            var result = await client.SearchCustomCampaignObjectsAsync("uniqueCode=testpledge@test.com");

            //Assert
            Assert.IsFalse(result.Value.Count > 1);
        }
    }
}
