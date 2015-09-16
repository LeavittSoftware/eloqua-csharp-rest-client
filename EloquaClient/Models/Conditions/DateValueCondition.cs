namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Conditions
{
    public class DateValueCondition : ValueCondition
    {
        public string Operator { get; set; }
        public RelativeDate Value { get; set; }
    }
}
