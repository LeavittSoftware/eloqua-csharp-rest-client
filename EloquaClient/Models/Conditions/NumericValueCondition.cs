namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Conditions
{
    public class NumericValueCondition : ValueCondition
    {
        public string Operator { get; set; }
        public int? Value { get; set; }
    }
}
