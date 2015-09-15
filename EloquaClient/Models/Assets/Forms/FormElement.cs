namespace Eloqua.Api.Rest.ClientLibrary.Models.Assets.Forms
{
    public class FormElement : IdentifiableObject
    {
        public string DataType {get; set;}  
        public string DisplayType {get; set;}
        public int? OptionListId {get; set;}
        public int FieldMergeId {get; set;}
        public string HtmlName {get; set;}

    }
}
