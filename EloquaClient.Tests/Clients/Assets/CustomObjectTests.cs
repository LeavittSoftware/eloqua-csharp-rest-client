using System;
using System.Collections.Generic;
using Eloqua.Api.Rest.ClientLibrary.Models;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.CustomObjects;
using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Assets
{
    public class CustomObjectTests
    {
        private readonly Client _client;

        public CustomObjectTests()
        {
             _client = new Client(new BaseClient("sites", "user", "password", Constants.BaseUrl));
        }

        [Fact]
        public void GetCustomObjectTest()
        {
            const int id = 32;
            var customObject = _client.Assets.CustomObject.Get(id);
            Assert.Equal(id, customObject.Id);
        }

        [Fact]
        public void GetCustomObjectsTest()
        {
            var customObjects = _client.Assets.CustomObject.Get("*", 1, 50);
            Assert.True(customObjects.Total > 0);
        }

        [Fact]
        public void CreateCustomObject()
        {
            var customObject = new CustomObject
            {
                name = $"test-{Guid.NewGuid()}",
                Fields = new List<CustomObjectField>
                {
                    new CustomObjectField
                    {
                        Name = "text field",
                        DataType =
                            Enum.GetName(typeof (FieldDataType),
                                FieldDataType.Text),
                        DisplayType =
                            Enum.GetName(typeof (FieldDisplayType),
                                FieldDisplayType.Text),
                        Type = "CustomObjectField"
                    },
                    new CustomObjectField
                    {
                        Name = "numeric field",
                        DataType =
                            Enum.GetName(typeof (FieldDataType),
                                FieldDataType.Number),
                        DisplayType =
                            Enum.GetName(typeof (FieldDisplayType),
                                FieldDisplayType.Text),
                        Type = "CustomObjectField"
                    },

                    new CustomObjectField
                    {
                        Name = "date field",
                        DataType =
                            Enum.GetName(typeof (FieldDataType),
                                FieldDataType.Date),
                        DisplayType =
                            Enum.GetName(typeof (FieldDisplayType),
                                FieldDisplayType.Text),
                        Type = "CustomObjectField"
                    }
                }
            };

            var response = _client.Assets.CustomObject.Post(customObject);
            Assert.True(response.Id > 0);
        }

        [Fact]
        public void DeleteCustomObject()
        {
            const int id = 33;
            _client.Assets.CustomObject.Delete(id);
        }
    }
}