using Eloqua.Api.Rest.ClientLibrary.Models.Assets.Accounts.Views;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.Campaigns;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.Contacts.Lists;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.Contacts.Segments;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.Contacts.Views;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.ContentSections;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.CustomObjects;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.DynamicContents;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.Emails;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.Emails.Groups;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.External;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.LandingPages;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.Microsites;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.OptionLists;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.Forms;

namespace Eloqua.Api.Rest.ClientLibrary.Clients.Assets
{
    public class AssetClient
    {
        #region constructor 

        public AssetClient(EloquaRestClient eloquaRestClient)
        {
            EloquaRestClient = eloquaRestClient;
        }

        #endregion

        #region properties

        protected EloquaRestClient EloquaRestClient;

        #endregion

        #region Contact Assets

        public GenericClient<ContactSegment> ContactSegment => _contactSegment ?? (_contactSegment = new GenericClient<ContactSegment>(EloquaRestClient));
        private GenericClient<ContactSegment> _contactSegment;

        public GenericClient<ContactList> ContactList => _contactList ?? (_contactList = new GenericClient<ContactList>(EloquaRestClient));
        private GenericClient<ContactList> _contactList;

        public GenericClient<ContactView> ContactView => _contactView ?? (_contactView = new GenericClient<ContactView>(EloquaRestClient));
        private GenericClient<ContactView> _contactView;

        public GenericClient<ContactField> ContactFields => _contactFields ?? (_contactFields= new GenericClient<ContactField>(EloquaRestClient));
        private GenericClient<ContactField> _contactFields;
        

        #endregion

        #region Account Assets

        public GenericClient<AccountView> AccountView => _accountView ?? (_accountView = new GenericClient<AccountView>(EloquaRestClient));
        private GenericClient<AccountView> _accountView;

        #endregion

        #region Email

        public GenericClient<Email> Email => _emailClient ?? (_emailClient = new GenericClient<Email>(EloquaRestClient));
        private GenericClient<Email> _emailClient;

        public GenericClient<Models.Assets.Emails.Structured.Email> StructuredEmail => _structuredEmailClient ?? ( _structuredEmailClient = new GenericClient<Models.Assets.Emails.Structured.Email>(EloquaRestClient));
        private GenericClient<Models.Assets.Emails.Structured.Email> _structuredEmailClient;

        public GenericClient<EmailGroup> EmailGroup => _emailGroupClient ?? (_emailGroupClient = new GenericClient<EmailGroup>(EloquaRestClient));
        private GenericClient<EmailGroup> _emailGroupClient; 

        #endregion

        #region EmailDeployment

        public SearchClient<EmailDeployment> EmailDeployment => _emailDeployment ?? (_emailDeployment = new SearchClient<EmailDeployment>(EloquaRestClient));
        private SearchClient<EmailDeployment> _emailDeployment; 

        public GenericClient<EmailInlineDeployment> EmailInlineDeployment => _emailInlineDeployment ?? (_emailInlineDeployment = new GenericClient<EmailInlineDeployment>(EloquaRestClient));
        private GenericClient<EmailInlineDeployment> _emailInlineDeployment;

        public GenericClient<Models.Assets.Emails.Deployment.Structured.EmailInlineDeployment> StructuredEmailInlineDeployment => _structuredEmailInlineDeployment ?? (_structuredEmailInlineDeployment = new GenericClient<Models.Assets.Emails.Deployment.Structured.EmailInlineDeployment>(EloquaRestClient));
        private GenericClient<Models.Assets.Emails.Deployment.Structured.EmailInlineDeployment> _structuredEmailInlineDeployment;

        public GenericClient<EmailTestDeployment> EmailTestDeployment => _emailTestDeployment ?? (_emailTestDeployment = new GenericClient<EmailTestDeployment>(EloquaRestClient));
        private GenericClient<EmailTestDeployment> _emailTestDeployment;

        #endregion

        #region LandingPages

        public GenericClient<LandingPage> LandingPage => _landingPage ?? (_landingPage = new GenericClient<LandingPage>(EloquaRestClient));
        private GenericClient<LandingPage> _landingPage;

        public GenericClient<Models.Assets.LandingPages.Structured.LandingPage> StructuredLandingPage => _structuredLandingPage ?? (_structuredLandingPage = new GenericClient<Models.Assets.LandingPages.Structured.LandingPage>(EloquaRestClient));
        private GenericClient<Models.Assets.LandingPages.Structured.LandingPage> _structuredLandingPage;

        #endregion

        #region Campaigns

        public GenericClient<Campaign> Campaign => _campaign ?? (_campaign = new GenericClient<Campaign>(EloquaRestClient));
        private GenericClient<Campaign> _campaign;

        #endregion

        #region CustomObjects

        public GenericClient<CustomObject> CustomObject => _customObjectClient ?? (_customObjectClient = new GenericClient<CustomObject>(EloquaRestClient));
        private GenericClient<CustomObject> _customObjectClient;

        #endregion

        #region Microsites

        public GenericClient<Microsite> Microsite => _micrositeClient ?? (_micrositeClient = new GenericClient<Microsite>(EloquaRestClient));
        private GenericClient<Microsite> _micrositeClient;

        #endregion

        #region OptionLists

        public GenericClient<OptionList> OptionList => _optionList ?? (_optionList = new GenericClient<OptionList>(EloquaRestClient));
        private GenericClient<OptionList> _optionList;

        #endregion

        #region Content 

        public GenericClient<DynamicContent> DynamicContent => _dynamicContent ?? (_dynamicContent = new GenericClient<DynamicContent>(EloquaRestClient));
        private GenericClient<DynamicContent> _dynamicContent;

        public GenericClient<ContentSection> ContentSection => _contentSection ?? (_contentSection = new GenericClient<ContentSection>(EloquaRestClient));
        private GenericClient<ContentSection> _contentSection;

        #endregion

        #region External Assets

        public GenericClient<ExternalAsset> ExternalAsset => _externalAsset ?? (_externalAsset = new GenericClient<ExternalAsset>(EloquaRestClient));
        private GenericClient<ExternalAsset> _externalAsset;

        #endregion

        #region Forms

        public GenericClient<Form> Form => _form ?? (_form = new GenericClient<Form>(EloquaRestClient));
        private GenericClient<Form> _form;
        
        #endregion

    }
}
