using Eloqua.Api.Rest.ClientLibrary.Models.Assets.ContentSections;

namespace Eloqua.Api.Rest.ClientLibrary.Models.Assets.DynamicContents
{
    public class DynamicContentRule : RestObject
    {
        public ContentSection ContentSection { get; set; }
        public string Statement { get; set; }
    }
}
