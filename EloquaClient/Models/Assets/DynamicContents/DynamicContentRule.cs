using LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.ContentSections;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.DynamicContents
{
    public class DynamicContentRule : EloquaDto
    {
        public ContentSection ContentSection { get; set; }
        public string Statement { get; set; }
    }
}
