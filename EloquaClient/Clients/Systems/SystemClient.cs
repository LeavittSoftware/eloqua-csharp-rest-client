using Eloqua.Api.Rest.ClientLibrary.Models.Systems.Cloud;
using Eloqua.Api.Rest.ClientLibrary.Models.Systems.Users;

namespace Eloqua.Api.Rest.ClientLibrary.Clients.Systems
{
    public class SystemClient
    {
        #region constructor 

        public SystemClient(EloquaRestClient eloquaRestClient)
        {
            EloquaRestClient = eloquaRestClient;
        }

        #endregion

        #region properties

        protected EloquaRestClient EloquaRestClient;

        #endregion

        #region Users

        public GenericClient<User> User
        {
            get { return _userClient ?? (_userClient = new GenericClient<User>(EloquaRestClient)); }
        }
        private GenericClient<User> _userClient;

        #endregion

        #region Cloud Data

        public GenericClient<CloudDataInstance> CloudData
        {
            get { return _cloudDataClient ?? (_cloudDataClient = new GenericClient<CloudDataInstance>(EloquaRestClient)); }
        }
        private GenericClient<CloudDataInstance> _cloudDataClient;

        #endregion
    }
}
