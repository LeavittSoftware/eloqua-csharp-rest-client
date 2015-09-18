using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Tests.Unit
{
    [TestClass()]
    public class EloquaSerializerTests
    {
        const string Content = @"{
                  ""contactId"": ""48620"",
                  ""id"": ""10002"",
                  ""fieldValues"": [
                    {
                      ""id"": ""824"",
                      ""value"": ""transxId12321321321321""
                    },
                    {
                      ""id"": ""200"",
                      ""value"": ""NotInModel""
                    }
                  ],
                  ""name"": ""Bob Tester"",
                  ""uri"": ""/data/customObject""
                }
            ";

        [TestMethod()]
        public void SerializerTest()
        {
            //Arange

            //Act
            var contact = EloquaSerializer.Serializer<MockSerializerContact>(Content);
            
            //Assert
            Assert.AreEqual(48620, contact.ContactId);
            Assert.AreEqual(10002, contact.Id);
            Assert.AreEqual("Bob Tester", contact.Name);
            Assert.AreEqual("transxId12321321321321", contact.CustomField);
            Assert.AreEqual("/data/customObject", contact.Uri);
            Assert.IsNull(contact.CustomFieldNotInContent);
        }

        [TestMethod()]
        public void SerializerEmptyJsonObjectContentTest()
        {
            //Arange

            //Act
            var contact = EloquaSerializer.Serializer<MockSerializerContact>("{}");

            //Assert
            Assert.AreEqual(0, contact.ContactId);
            Assert.IsNull(contact.Id);
            Assert.IsNull(contact.Name);
            Assert.IsNull(contact.CustomField);
            Assert.IsNull(contact.Uri);
            Assert.IsNull(contact.CustomFieldNotInContent);
        }

        [TestMethod()]
        public void SerializerEmptyContentTest()
        {
            //Arange

            //Act
            var contact = EloquaSerializer.Serializer<MockSerializerContact>("");

            //Assert
            Assert.IsNull(contact);
        }

        [TestMethod()]
        public void SerializerNoCustomFieldsTest()
        {
            //Arange

            //Act
            var contact = EloquaSerializer.Serializer<MockSerializerNoCustomFieldsContact>(Content);

            //Assert
            Assert.AreEqual(48620, contact.ContactId);
            Assert.AreEqual(10002, contact.Id);
            Assert.AreEqual("Bob Tester", contact.Name);
            Assert.AreEqual("/data/customObject", contact.Uri);
        }

    }


    [Resource("/data/contact", "Contact")]
    public class MockSerializerNoCustomFieldsContact : IEloquaDataObject
    {
        public int? Id { get; set; }
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }
    }

    [Resource("/data/contact", "Contact")]
    public class MockSerializerBadCustomFieldsContact : IEloquaDataObject
    {
        public int? Id { get; set; }
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }

        [EloquaCustomProperty(824)]
        public string CustomField { get; set; }
    }

    [Resource("/data/contact", "Contact")]
    public class MockSerializerContact : IEloquaDataObject
    {
        public int? Id { get; set; }
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }

        [EloquaCustomProperty(824)]
        public string CustomField { get; set; }

        [EloquaCustomProperty(100)]
        public string CustomFieldNotInContent { get; set; }
    }
}