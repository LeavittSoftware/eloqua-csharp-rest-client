using System;
using System.Collections.Generic;
using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Assets
{
    public class StructuredEmailDeploymentTest
    {
        private readonly Client client;

        public StructuredEmailDeploymentTest()
        {
            client = new Client("site", "user", "password", Constants.BaseUrl);
        }

        [Fact]
        public void ListEmailDeployments()
        {
            var deployments = client.Assets.EmailDeployment.Get("*", 1, 100);
            Assert.True(0 > deployments.total);
        }

        [Fact]
        public void CreateInlineEmailDeployment()
        {
            var contact = new Models.Assets.Emails.Deployment.Contact()
            {
                id = 1,
                emailAddress = "fred.sakr@eloqua.com"
            };

            var contacts = new List<Models.Assets.Emails.Deployment.Contact>
            {
                contact
            };

            var email = client.Assets.StructuredEmail.Get(5219);

            var name = string.Format("unit-test_{0}", Guid.NewGuid());
            var inlineDeployment = new Models.Assets.Emails.Deployment.Structured.EmailInlineDeployment()
            {
                name = name,
                contacts = contacts,
                email = email,
                type = "EmailInlineDeployment"
            };

            var response = client.Assets.StructuredEmailInlineDeployment.Post(inlineDeployment);
            Assert.Equal(name, response.name);
        }
    }
}
