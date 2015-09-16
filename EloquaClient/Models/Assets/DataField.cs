namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets
{
    public class DataField : IdentifiableObject
    {
        public string CheckedValue { get; set; }
        public string DataType { get; set; }
        public string DefaultValue { get; set; }
        public string DisplayType { get; set; }
        public string InternalName { get; set; }
        public string IsReadOnly { get; set; }
        public string IsRequired { get; set; }
        public string IsStandard { get; set; }
        public int? OptionListId { get; set; }
        public string UncheckedValue { get; set; }
    }
}
