using System.Linq;
using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Assets
{
    public class FormTests
    {
        private readonly Client client;

        public FormTests()
        {
            client = new Client("site", "user", "pass", Constants.BaseUrl);
        }

        [Fact]
        public void GetFormListTest()
        {
            var result = client.Assets.Form.Get("*", 1, 100);
            Assert.NotEqual(0, result.elements.Count);
        }

        [Fact]
        public void GetFormByIdTest()
        {
            var form = client.Assets.Form.Get(550, Depth.complete);

            var validFormElements = form.elements
                .Where(element => element.optionListId.HasValue)
                .Select(element => client.Assets.OptionList.Get(element.optionListId.Value, Depth.complete));

            foreach (var optionList in validFormElements)
            {
                Assert.NotNull(optionList);
            }

            Assert.NotNull(form);
        }
    }
}
