using System.Collections.Generic;

namespace Eloqua.Api.Rest.ClientLibrary.Models.Systems.Users
{
    [Resource("/system/user", "User")]
    public class User : RestObject, ISearchable
    {
        public List<string> BetaAccess { get; set; }
        public List<string> Capabilities { get; set; }
        public int? DefaultContactViewId { get; set; }
        public string EmailAddress { get; set; }
        public string LoginName { get; set; }
        public string Name { get; set; }
        public List<ProductPermission> ProductPermissions { get; set; }
        public List<TypePermissions> TypePermissions { get; set; } 

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }
    }
}
