using System;
using System.Collections.Generic;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.Emails;
using Eloqua.Api.Rest.ClientLibrary.Models.Content;
using Xunit;
using Email = Eloqua.Api.Rest.ClientLibrary.Models.Assets.Emails.Deployment.Email;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Assets
{
    public class EmailDeploymentTest
    {
        private readonly Client client;

        public EmailDeploymentTest()
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
            var contact = new Models.Assets.Emails.Deployment.Contact
            {
                id = 1,
                emailAddress = "fred.sakr@eloqua.com"
            };

            var contacts = new List<Models.Assets.Emails.Deployment.Contact>
            {
                contact
            };

            var email = new Email
            {
                name = "sample email",
                subject = "sample subject",
                htmlContent = new RawHtmlContent
                {
                    html = "<html><head></head><body>test</body></html>",
                    type = "RawHtmlContent"
                },
            };

            var name = string.Format("unit-test_{0}", Guid.NewGuid());
            var inlineDeployment = new EmailInlineDeployment
            {
                name = name,
                contacts = contacts,
                email = email,
                type = "EmailInlineDeployment"
            };

            var response = client.Assets.EmailInlineDeployment.Post(inlineDeployment);
            Assert.Equal(name, response.name);
        }
    }
}