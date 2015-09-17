namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Errors
{
    public class ObjectValidationError 
    {
        public ObjectKey Container { get; set; }
        public string Property { get; set; }
        public Requirement Requirement { get; set; }
        public string Value { get; set; }
    }

    public class Requirement
    {
        public string Type { get; set; }
    }

    public class ObjectKey
    {
        public string Container { get; set; }
        public int? ObjectId { get; set; }
        public string ObjectType { get; set; }
    }
}
