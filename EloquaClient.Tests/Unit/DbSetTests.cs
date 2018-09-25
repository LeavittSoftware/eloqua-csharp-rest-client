using System.Net;
using System.Threading.Tasks;
using LG.Eloqua.Api.Rest.ClientLibrary.Exceptions;
using LG.Eloqua.Api.Rest.ClientLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Tests.Unit
{
    [TestClass]
    public class DbSetTests
    {
        #region GET
        [ExpectedException(typeof(DbSetException))]
        [TestMethod]
        public async Task DbSetGetAsyncResourceAttributeNullTest()
        {
            //Arrange
            var mockRestClient = new Mock<IRestClient>();

            var dbSet = new DbSet<MockDbsetContact>(mockRestClient.Object);

            //Act
            await dbSet.GetAsync(1, Depth.Complete);

            //Assert - throws
        }

        [TestMethod]
        public async Task DbSetGetAsyncTest()
        {
            //Arrange
            var mockRestResponse = new Mock<IRestResponse>();
            mockRestResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Completed);
            mockRestResponse.SetupGet(o => o.StatusCode).Returns(HttpStatusCode.OK);
            mockRestResponse.SetupGet(o => o.Content).Returns(@"{
                  ""contactId"": ""48620"",
                  ""id"": ""10002"",
                  ""fieldValues"": [
                    {
                      ""id"": ""824"",
                      ""value"": ""transxId12321321321321""
                    }
                  ],
                  ""name"": ""Test Name WHAT IS THIS"",
                  ""uri"": ""/data/customObject""
                }
            ");


            var mockRestClient = new Mock<IRestClient>();
            mockRestClient.Setup(o => o.ExecuteTaskAsync(It.IsAny<IRestRequest>())).ReturnsAsync(mockRestResponse.Object);

            var dbSet = new DbSet<MockDbsetWithDataContact>(mockRestClient.Object);

            //Act
            var contact = await dbSet.GetAsync(1, Depth.Complete);

            //Assert
            Assert.AreEqual(10002, contact.Id);
        }

        #endregion

        #region POST
        [ExpectedException(typeof(DbSetException))]
        [TestMethod]
        public async Task DbSetPostAsyncResourceAttributeNull()
        {
            //Arrange
            var mockRestClient = new Mock<IRestClient>();

            var dbSet = new DbSet<MockDbsetContact>(mockRestClient.Object);

            //Act
            await dbSet.PostAsync(new MockDbsetContact());

            //Assert - throws
        }

        [TestMethod]
        public async Task DbSetPostAsyncTest()
        {
            //Arrange
            var mockRestResponse = new Mock<IRestResponse>();
            mockRestResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Completed);
            mockRestResponse.SetupGet(o => o.StatusCode).Returns(HttpStatusCode.OK);
            mockRestResponse.SetupGet(o => o.Content).Returns(@"{
                  ""contactId"": ""48620"",
                  ""id"": ""10002"",
                  ""fieldValues"": [
                    {
                      ""id"": ""824"",
                      ""value"": ""transxId12321321321321""
                    }
                  ],
                  ""name"": ""Bob Tester"",
                  ""uri"": ""/data/customObject""
                }
            ");

            var mockRestClient = new Mock<IRestClient>();
            mockRestClient.Setup(o => o.ExecuteTaskAsync(It.IsAny<IRestRequest>())).ReturnsAsync(mockRestResponse.Object);

            var dbSet = new DbSet<MockDbsetWithDataContact>(mockRestClient.Object);

            var mockContact = new MockDbsetWithDataContact
            {
                Name = "Bob Tester",
                ContactId = 48620,
                CustomField = "Custuom Rims",
                Uri = "/contact/id"
            };


            //Act
            var contact = await dbSet.PostAsync(mockContact);

            //Assert
            Assert.AreEqual(48620, contact.ContactId);
        }

        #endregion

        #region PUT
        [ExpectedException(typeof(DbSetException))]
        [TestMethod]
        public async Task DbSetPutAsyncResourceAttributeNullTest()
        {
            //Arrange
            var mockRestClient = new Mock<IRestClient>();

            var dbSet = new DbSet<MockDbsetContact>(mockRestClient.Object);

            //Act
            await dbSet.PutAsync(new MockDbsetContact());

            //Assert - throws
        }

        [TestMethod]
        public async Task DbSetPutAsyncTest()
        {
            //Arrange
            var mockRestResponse = new Mock<IRestResponse>();
            mockRestResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Completed);
            mockRestResponse.SetupGet(o => o.StatusCode).Returns(HttpStatusCode.OK);
            mockRestResponse.SetupGet(o => o.Content).Returns(@"{
                  ""contactId"": ""48620"",
                  ""id"": ""10002"",
                  ""fieldValues"": [
                    {
                      ""id"": ""824"",
                      ""value"": ""transxId12321321321321""
                    }
                  ],
                  ""name"": ""Bob Tester"",
                  ""uri"": ""/data/customObject""
                }
            ");

            var mockRestClient = new Mock<IRestClient>();
            mockRestClient.Setup(o => o.ExecuteTaskAsync(It.IsAny<IRestRequest>())).ReturnsAsync(mockRestResponse.Object);

            var dbSet = new DbSet<MockDbsetWithDataContact>(mockRestClient.Object);

            var mockContact = new MockDbsetWithDataContact
            {
                Name = "Bob Tester",
                ContactId = 48620,
                CustomField = "Custuom Rims",
                Uri = "/contact/id"
            };


            //Act
            var contact = await dbSet.PutAsync(mockContact);

            //Assert
            Assert.AreEqual(48620, contact.ContactId);
        }

        #endregion

        #region Search
        [ExpectedException(typeof(DbSetException))]
        [TestMethod]
        public async Task DbSetSearchAsyncResourceAttributeNullTest()
        {
            //Arrange
            var mockRestClient = new Mock<IRestClient>();

            var dbSet = new DbSet<MockDbsetContact>(mockRestClient.Object);

            //Act
            await dbSet.SearchAsync("test");

            //Assert - throws
        }

        [TestMethod]
        public async Task DbSetSearchAsyncTest()
        {
            //Arrange
            var mockRestResponse = new Mock<IRestResponse>();
            mockRestResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Completed);
            mockRestResponse.SetupGet(o => o.StatusCode).Returns(HttpStatusCode.OK);
            mockRestResponse.SetupGet(o => o.Content).Returns(@"{""elements"":[{
                  ""contactId"": ""48620"",
                  ""id"": ""10002"",
                  ""fieldValues"": [
                    {
                      ""id"": ""824"",
                      ""value"": ""transxId12321321321321""
                    }
                  ],
                  ""name"": ""Bob Tester"",
                  ""uri"": ""/data/customObject""
                }]}
            ");

            var mockRestClient = new Mock<IRestClient>();
            mockRestClient.Setup(o => o.ExecuteTaskAsync(It.IsAny<IRestRequest>())).ReturnsAsync(mockRestResponse.Object);

            var dbSet = new DbSet<MockDbsetWithDataContact>(mockRestClient.Object);

            //Act
            var contact = await dbSet.SearchAsync("Bob tester");

            //Assert
            Assert.AreEqual(1, contact.Elements.Count);
        }

        #endregion

        #region GetList
        [ExpectedException(typeof(DbSetException))]
        [TestMethod]
        public async Task DbSetGetListAsyncResourceAttributeNullTest()
        {
            //Arrange
            var mockRestClient = new Mock<IRestClient>();

            var dbSet = new DbSet<MockDbsetContact>(mockRestClient.Object);

            //Act
            await dbSet.GetListAsync();

            //Assert - throws
        }

        [TestMethod]
        public async Task DbSetGetListAsyncTest()
        {
            //Arrange
            var mockRestResponse = new Mock<IRestResponse>();
            mockRestResponse.SetupGet(o => o.ResponseStatus).Returns(ResponseStatus.Completed);
            mockRestResponse.SetupGet(o => o.StatusCode).Returns(HttpStatusCode.OK);
            mockRestResponse.SetupGet(o => o.Content).Returns(@"{
                    ""elements"": [
                        {
                            ""type"": ""Contact"",
                            ""currentStatus"": ""Awaiting action"",
                            ""id"": ""39919"",
                            ""createdAt"": ""1435697288"",
                            ""depth"": ""complete"",
                            ""name"": ""shawn-johnson@leavitt.com"",
                            ""updatedAt"": ""1534778241"",
                            ""accountName"": ""Leavitt Software Solutions"",
                            ""city"": ""Cedar City"",
                            ""emailAddress"": ""shawn-johnson@leavitt.com"",
                            ""emailFormatPreference"": ""unspecified"",
                            ""firstName"": ""Shawn"",
                            ""isBounceback"": ""false"",
                            ""isSubscribed"": ""true"",
                            ""lastName"": ""Johnson"",
                            ""postalCode"": ""84720"",
                            ""province"": ""UT"",
                            ""subscriptionDate"": ""1435697285""
                        }
                    ],
                    ""page"": 1,
                    ""pageSize"": 1000,
                    ""total"": 1
                }
            ");


            var mockRestClient = new Mock<IRestClient>();
            mockRestClient.Setup(o => o.ExecuteTaskAsync(It.IsAny<IRestRequest>())).ReturnsAsync(mockRestResponse.Object);

            var dbSet = new DbSet<MockDbsetWithDataContact>(mockRestClient.Object);

            //Act
            var contact = await dbSet.GetListAsync("FieldName", "name='shawn-johnson*'");

            //Assert
            Assert.AreEqual(1, contact.Elements.Count);
        }
        #endregion

    }

    public class MockDbsetContact : IEloquaDataObject
    {
        public int? Id { get; set; }
    }

    [Resource("/data/contact", "Contact")]
    public class MockDbsetWithDataContact : IEloquaDataObject
    {
        public int? Id { get; set; }
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }

        [EloquaCustomProperty(824)]
        public string CustomField { get; set; }

        [EloquaCustomProperty(100)]
        public string CustomFieldEmpty { get; set; }
    }

}
