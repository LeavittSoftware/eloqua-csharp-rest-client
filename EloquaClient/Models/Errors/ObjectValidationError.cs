namespace Eloqua.Api.Rest.ClientLibrary.Models.Errors
{
    public class ObjectValidationError : ValidationError
    {
        public ObjectKey Container { get; set; }
        public string Property { get; set; }
        public string Requirement { get; set; }
        public string Value { get; set; }
    }
}
