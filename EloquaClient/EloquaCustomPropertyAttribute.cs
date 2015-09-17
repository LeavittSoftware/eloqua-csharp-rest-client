using System;

namespace LG.Eloqua.Api.Rest.ClientLibrary
{
    public class EloquaCustomPropertyAttribute : Attribute
    {
        public EloquaCustomPropertyAttribute(int eloquaCustomFieldId)
        {
            EloquaCustomFieldId = eloquaCustomFieldId;
        }
        public int EloquaCustomFieldId { get; set; }
    }
}