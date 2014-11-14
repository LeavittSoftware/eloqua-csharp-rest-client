namespace Eloqua.Api.Rest.ClientLibrary.Models.Assets.Forms
{
    public class FormElement : IdentifiableObject
    {
        public string dataType {get; set;}  
        public string displayType {get; set;}
        public int? optionListId {get; set;}
        public int fieldMergeId {get; set;}
        public string htmlName {get; set;}

    }
}
