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
        private readonly Client _client;

        public EmailDeploymentTest()
        {
             _client = new Client(new EloquaRestClient("sites", "user", "password", Constants.BaseUrl));
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
            var contact = new Models.Assets.Emails.Deployment.Contact
            {
                Id = 1,
                EmailAddress = "fred.sakr@eloqua.com"
            };

            var contacts = new List<Models.Assets.Emails.Deployment.Contact>
            {
                contact
            };

            var email = new Email
            {
                Name = "sample email",
                Subject = "sample subject",
                HtmlContent = new RawHtmlContent
                {
                    Html = "<html><head></head><body>test</body></html>",
                    Type = "RawHtmlContent"
                },
            };

            var name = string.Format("unit-test_{0}", Guid.NewGuid());
            var inlineDeployment = new EmailInlineDeployment
            {
                name = name,
                Contacts = contacts,
                Email = email,
                type = "EmailInlineDeployment"
            };

            var response = _client.Assets.EmailInlineDeployment.Post(inlineDeployment);
            Assert.Equal(name, response.name);
        }
    }
}