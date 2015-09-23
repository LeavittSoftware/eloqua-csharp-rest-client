using System;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.CustomObjects
{
    public class EloquaCustomObjectAttribute : Attribute
    {
        public EloquaCustomObjectAttribute(int customObjectId)
        {
            CustomObjectId = customObjectId;
        }

        public int CustomObjectId { get; set; }
    }
}