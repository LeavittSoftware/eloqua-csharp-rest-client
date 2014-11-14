using System.Collections.Generic;

namespace Eloqua.Api.Rest.ClientLibrary.Models.Assets.Forms
{
    [Resource("/assets/form", "Form")]
    public class Form : RestObject, ISearchable
    {
        public int? createdAt { get; set; }
        public int? createdBy { get; set; }
        public int? folderId { get; set; }
        public int? updatedAt { get; set; }
        public int? updatedBy { get; set; }
        public List<FormElement> elements {get; set;}
        public string html { get; set; }
        public string htmlName { get; set; }

        #region ISearchable

        public int page { get; set; }
        public int pageSize { get; set; }
        public string searchTerm { get; set; }

        #endregion
    }
}
