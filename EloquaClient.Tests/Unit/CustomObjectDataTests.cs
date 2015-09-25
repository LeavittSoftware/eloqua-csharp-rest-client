using LG.Eloqua.Api.Rest.ClientLibrary.Models;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.CustomObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Tests.Unit
{
    [TestClass]
    public class CustomObjectDataTests
    {
        [TestMethod]
        public void GenerateImportFieldMappingTest()
        {
            //Arrange
            var cdo = new TestCustomObject();

            //Act
            var result = CustomObjectData.GenerateImportFieldMapping(cdo);

            //Assert

            Assert.AreEqual(@"""CustomProp1"": ""{{CustomObject[30].Field[122]}}"",", result);
        }

        [EloquaCustomObject(30)]
        private class TestCustomObject : IEloquaDataObject
        {

            public int? Id { get; set; }

            [EloquaCustomProperty(122)]
            public string CustomProp1 { get; set; }
        }
    }
}
