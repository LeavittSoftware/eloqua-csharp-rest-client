using System.Linq;
using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Assets
{
    public class FormTests
    {
        private readonly Client _client;

        public FormTests()
        {
             _client = new Client(new BaseClient("sites", "user", "password", Constants.BaseUrl));
        }

        [Fact]
        public void GetFormListTest()
        {
            var result = _client.Assets.Form.Get("*", 1, 100);
            Assert.NotEqual(0, result.Elements.Count);
        }

        [Fact]
        public void GetFormByIdTest()
        {
            var form = _client.Assets.Form.Get(550, Depth.Complete);

            var validFormElements = form.Elements
                .Where(element => element.OptionListId.HasValue)
                .Select(element => _client.Assets.OptionList.Get(element.OptionListId.Value, Depth.Complete));

            foreach (var optionList in validFormElements)
            {
                Assert.NotNull(optionList);
            }

            Assert.NotNull(form);
        }
    }
}
