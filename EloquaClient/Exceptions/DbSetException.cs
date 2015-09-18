using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Exceptions
{
    public class DbSetException : Exception
    {
        private const string DefaultMessage = "Could not determine REST endpoint. Check if Resource attribute has been set on POCO.";
        public DbSetException(string message = DefaultMessage) : base(message)
        {
        }
    }
}
