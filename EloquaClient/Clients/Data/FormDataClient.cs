using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Forms;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Clients.Data
{
    public class FormDataClient
    {
        readonly BaseClient _baseClient;

        public FormDataClient(BaseClient baseClient)
        {
            _baseClient = baseClient;
        }

        public FormData FormPost(int? formId, FormData data)
        {
            var request = Request.Get(Request.Type.Post, data);
            request.Resource += "/" + formId;

            return _baseClient.Execute<FormData>(request);
        }
    }
}
