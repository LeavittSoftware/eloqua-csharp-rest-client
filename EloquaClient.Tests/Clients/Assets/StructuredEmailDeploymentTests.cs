using System;
using System.Collections.Generic;
using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Assets
{
    public class StructuredEmailDeploymentTest
    {
        private readonly Client _client;

        public StructuredEmailDeploymentTest()
        {
             _client = new Client(new BaseClient("sites", "user", "password", Constants.BaseUrl));
        }

        [Fact]
        public void ListEmailDeployments()
        {
            var deployments = _client.Assets.EmailDeployment.Get("*", 1, 100);
            Assert.True(0 > deployments.Total);
        }

        [Fact]
        public void CreateInlineEmailDeployment()
        {
            var contact = new Models.Assets.Emails.Deployment.Contact()
            {
                Id = 1,
                EmailAddress = "fred.sakr@eloqua.com"
            };

            var contacts = new List<Models.Assets.Emails.Deployment.Contact>
            {
                contact
            };

            var email = _client.Assets.StructuredEmail.Get(5219);

            var name = $"unit-test_{Guid.NewGuid()}";
            var inlineDeployment = new Models.Assets.Emails.Deployment.Structured.EmailInlineDeployment()
            {
                name = name,
                Contacts = contacts,
                Email = email,
                type = "EmailInlineDeployment"
            };

            var response = _client.Assets.StructuredEmailInlineDeployment.Post(inlineDeployment);
            Assert.Equal(name, response.name);
        }
    }
}
