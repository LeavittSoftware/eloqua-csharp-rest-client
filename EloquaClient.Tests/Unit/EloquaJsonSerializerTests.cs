using System;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Tests.Unit
{
    [TestClass]
    public class EloquaJsonSerializerTests
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
                      ""id"": ""201"",
                      ""value"": ""1442855798""
                    },
{
                      ""id"": ""203"",
                      ""value"": ""1442855798""
                    },
{
                      ""id"": ""202"",
                      ""value"": ""double""
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

        [TestMethod]
        public void SerializerTest()
        {
            //Arange

            //Act
            var contact = EloquaJsonSerializer.Deserializer<MockSerializerContact>(Content);

            //Assert
            Assert.AreEqual(48620, contact.ContactId);
            Assert.AreEqual(10002, contact.Id);
            Assert.AreEqual("Bob Tester", contact.Name);
            Assert.AreEqual("transxId12321321321321", contact.CustomField);
            Assert.AreEqual("/data/customObject", contact.Uri);
            Assert.AreEqual(DateTime.Parse("09/21/2015 10:16:38 AM"), contact.DateTime);
            Assert.AreEqual(0, contact.Double);
            Assert.IsNull(contact.CustomFieldNotInContent);
            Assert.AreEqual(DateTime.Parse("09/21/2015 10:16:38 AM"),contact.DateTimeNullable);
        }

        [TestMethod]
        public void SerializerEmptyJsonObjectContentTest()
        {
            //Arange

            //Act
            var contact = EloquaJsonSerializer.Deserializer<MockSerializerContact>("{}");

            //Assert
            Assert.AreEqual(0, contact.ContactId);
            Assert.IsNull(contact.Id);
            Assert.IsNull(contact.Name);
            Assert.IsNull(contact.CustomField);
            Assert.IsNull(contact.Uri);
            Assert.IsNull(contact.CustomFieldNotInContent);
            Assert.IsNull(contact.DateTimeNullable);
        }

        [TestMethod]
        public void SerializerEmptyContentTest()
        {
            //Arange

            //Act
            var contact = EloquaJsonSerializer.Deserializer<MockSerializerContact>("");

            //Assert
            Assert.IsNull(contact);
        }

        [TestMethod]
        public void SerializerNoCustomFieldsTest()
        {
            //Arange

            //Act
            var contact = EloquaJsonSerializer.Deserializer<MockSerializerNoCustomFieldsContact>(Content);

            //Assert
            Assert.AreEqual(48620, contact.ContactId);
            Assert.AreEqual(10002, contact.Id);
            Assert.AreEqual("Bob Tester", contact.Name);
            Assert.AreEqual("/data/customObject", contact.Uri);
        }

        [TestMethod]
        public void SerializeDateTimePropery()
        {
            //Arrange 
            var eloquaObject = new EloquaObject { DateTime = DateTime.Parse("08-31-2015 2:15:22PM") };
            var property = eloquaObject.GetType().GetProperty(nameof(EloquaObject.DateTime));

            //Act
            var result = EloquaJsonSerializer.SerializeProperty(property, eloquaObject);

            //Assert
            Assert.AreEqual("1441055722", result);
        }

        [TestMethod]
        public void SerializeDateTimeNullablePropery()
        {
            //Arrange 
            var eloquaObject = new EloquaObject { DateTimeNullable = DateTime.Parse("08-31-2015 2:15:22PM") };
            var property = eloquaObject.GetType().GetProperty(nameof(EloquaObject.DateTimeNullable));

            //Act
            var result = EloquaJsonSerializer.SerializeProperty(property, eloquaObject);

            //Assert
            Assert.AreEqual("1441055722", result);
        }

        //

        [TestMethod]
        public void SerializeDecimalPropery()
        {
            //Arrange 
            var eloquaObject = new EloquaObject { Decimal = decimal.Parse("1234.123456789123456789123") };
            var property = eloquaObject.GetType().GetProperty(nameof(EloquaObject.Decimal));

            //Act
            var result = EloquaJsonSerializer.SerializeProperty(property, eloquaObject);

            //Assert
            Assert.AreEqual("1234.1234567891234567891", result);
        }

        [TestMethod]
        public void SerializeStringPropery()
        {
            //Arrange 
            var eloquaObject = new EloquaObject { Text = "Alice" };
            var property = eloquaObject.GetType().GetProperty(nameof(EloquaObject.Text));

            //Act
            var result = EloquaJsonSerializer.SerializeProperty(property, eloquaObject);

            //Assert
            Assert.AreEqual("Alice", result);
        }

        [TestMethod]
        public void SerializeIntPropery()
        {
            //Arrange 
            var eloquaObject = new EloquaObject { Integer = 2333 };
            var property = eloquaObject.GetType().GetProperty(nameof(EloquaObject.Integer));

            //Act
            var result = EloquaJsonSerializer.SerializeProperty(property, eloquaObject);

            //Assert
            Assert.AreEqual("2333", result);
        }

        [TestMethod]
        public void SerializeEnumPropery()
        {
            //Arrange 
            var eloquaObject = new EloquaObject { Color = Color.Green };
            var property = eloquaObject.GetType().GetProperty(nameof(EloquaObject.Color));

            //Act
            var result = EloquaJsonSerializer.SerializeProperty(property, eloquaObject);

            //Assert
            Assert.AreEqual("Green", result);
        }

        [TestMethod]
        public void SerializeNullPropery()
        {
            //Arrange 
            var eloquaObject = new EloquaObject { Text = null };
            var property = eloquaObject.GetType().GetProperty(nameof(EloquaObject.Text));

            //Act
            var result = EloquaJsonSerializer.SerializeProperty(property, eloquaObject);

            //Assert
            Assert.IsNull(result);
        }


    }

    public class EloquaObject
    {
        public DateTime DateTime { get; set; }
        public decimal Decimal { get; set; }
        public string Text { get; set; }
        public int Integer { get; set; }
        public Color Color { get; set; }
        public DateTime? DateTimeNullable { get; set; }
    }

    public enum Color
    {
        Red,
        Green
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

        [EloquaCustomProperty(202)]
        public double Double { get; set; }

        [EloquaCustomProperty(201)]
        public DateTime DateTime { get; set; }

        [EloquaCustomProperty(203)]
        public DateTime? DateTimeNullable { get; set; }
    }
}