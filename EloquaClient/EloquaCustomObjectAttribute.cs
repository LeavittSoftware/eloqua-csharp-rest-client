using System;

namespace LG.Eloqua.Api.Rest.ClientLibrary
{
    public class EloquaCustomObjectAttribute : Attribute
    {
        public EloquaCustomObjectAttribute(int eloquaCustomObjectId)
        {
            EloquaCustomObjectId = eloquaCustomObjectId;
        }
        public int EloquaCustomObjectId { get; set; }
    }
}