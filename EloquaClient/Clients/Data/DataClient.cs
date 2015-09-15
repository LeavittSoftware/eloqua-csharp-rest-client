using Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts;
using Eloqua.Api.Rest.ClientLibrary.Models.Data.CustomObjects;
using Eloqua.Api.Rest.ClientLibrary.Models.Data.Account;
using Eloqua.Api.Rest.ClientLibrary.Models.Data.Forms;

namespace Eloqua.Api.Rest.ClientLibrary.Clients.Data
{
    public class DataClient
    {
        #region constructor 

        public DataClient(BaseClient baseClient)
        {
            BaseClient = baseClient;
        }

        #endregion

        #region properties

        protected BaseClient BaseClient;

        #endregion

        #region Contacts

        public GenericClient<Contact> Contact => _contactClient ?? (_contactClient = new GenericClient<Contact>(BaseClient));
        private GenericClient<Contact> _contactClient;

        public SearchMembersClient<ContactListMember> ContactListMember => _contactListMemberClient ?? (_contactListMemberClient = new SearchMembersClient<ContactListMember>(BaseClient));

        private SearchMembersClient<ContactListMember> _contactListMemberClient;

        public ActivityClient Activity => _activity ?? (_activity = new ActivityClient(BaseClient));

        private ActivityClient _activity;

        public SubscriptionClient ContactEmailSubscription => _subscription ?? (_subscription = new SubscriptionClient(BaseClient));

        private SubscriptionClient _subscription;

        public GenericClient<FormData> FormData => _formData ?? (_formData = new GenericClient<FormData>(BaseClient));

        private GenericClient<FormData> _formData;


        #endregion

        #region Accounts

        public GenericClient<Account> Account => _accountClient ?? (_accountClient = new GenericClient<Account>(BaseClient));
        private GenericClient<Account> _accountClient;

        #endregion

        #region CustomObjects

        public GenericClient<CustomObject> CustomObject => _customObjectDataClient ?? (_customObjectDataClient = new GenericClient<CustomObject>(BaseClient));
        private GenericClient<CustomObject> _customObjectDataClient;

        #endregion

        #region External Activities

        public ExternalActivityClient ExternalActivity => _externalActivity ?? (_externalActivity = new ExternalActivityClient(BaseClient));

        private ExternalActivityClient _externalActivity;

        #endregion
    }
}
