using Eloqua.Api.Rest.ClientLibrary.Models;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Assets
{
    [TestClass]
    public class FormTests
    {
        private Client _client;

        [TestInitialize]
        public void Init()
        {
            _client = new Client("site", "user", "pass", Constants.BaseUrl);
        }

        [TestMethod]
        public void GetFormListTest()
        {
            var result = _client.Assets.Form.Get("*", 1, 100);
            Assert.AreNotEqual(0, result.elements.Count);
        }

        [TestMethod]
        public void GetFormByIdTest()
        {
            var form = _client.Assets.Form.Get(550, Depth.complete);

            foreach (FormElement element in form.elements)
            {
                if (element.optionListId.HasValue)
                {
                    var optionList = _client.Assets.OptionList.Get(element.optionListId.Value, Depth.complete);
                }
            }

            Assert.IsNotNull(form);
        }

    }
}
