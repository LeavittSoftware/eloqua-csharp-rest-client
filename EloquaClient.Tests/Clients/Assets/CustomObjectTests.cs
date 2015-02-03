using System;
using System.Collections.Generic;
using Eloqua.Api.Rest.ClientLibrary.Models;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.CustomObjects;
using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Assets
{
    public class CustomObjectTests
    {
        private readonly Client client;

        public CustomObjectTests()
        {
            client = new Client("site", "user", "password", Constants.BaseUrl);
        }

        [Fact]
        public void GetCustomObjectTest()
        {
            const int id = 32;
            var customObject = client.Assets.CustomObject.Get(id);
            Assert.Equal(id, customObject.id);
        }

        [Fact]
        public void GetCustomObjectsTest()
        {
            var customObjects = client.Assets.CustomObject.Get("*", 1, 50);
            Assert.True(customObjects.total > 0);
        }

        [Fact]
        public void CreateCustomObject()
        {
            var customObject = new CustomObject
            {
                name = string.Format("test-{0}", Guid.NewGuid()),
                fields = new List<CustomObjectField>
                {
                    new CustomObjectField
                    {
                        name = "text field",
                        dataType =
                            Enum.GetName(typeof (FieldDataType),
                                FieldDataType.text),
                        displayType =
                            Enum.GetName(typeof (FieldDisplayType),
                                FieldDisplayType.text),
                        type = "CustomObjectField"
                    },
                    new CustomObjectField
                    {
                        name = "numeric field",
                        dataType =
                            Enum.GetName(typeof (FieldDataType),
                                FieldDataType.number),
                        displayType =
                            Enum.GetName(typeof (FieldDisplayType),
                                FieldDisplayType.text),
                        type = "CustomObjectField"
                    },

                    new CustomObjectField
                    {
                        name = "date field",
                        dataType =
                            Enum.GetName(typeof (FieldDataType),
                                FieldDataType.date),
                        displayType =
                            Enum.GetName(typeof (FieldDisplayType),
                                FieldDisplayType.text),
                        type = "CustomObjectField"
                    }
                }
            };

            var response = client.Assets.CustomObject.Post(customObject);
            Assert.True(response.id > 0);
        }

        [Fact]
        public void DeleteCustomObject()
        {
            const int id = 33;
            client.Assets.CustomObject.Delete(id);
        }
    }
}