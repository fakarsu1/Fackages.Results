using Fackages.Results.Attributes;
using System.Net;

namespace Samples.WebApi.Messages
{
    public enum ResultMessage
    {
        NoResource = -3,

        [Customize("Customize Attribute Without Resource")]
        OnlyDisplayName = -2,

        [Customize(typeof(ResultMessageResource))]
        Test1 = -1,

        [Customize("Test2WithDisplayName", typeof(ResultMessageResource))]
        Test2 = 0,

        [Customize(HttpStatusCode.Unauthorized, "Auth_Unauthorized", typeof(ResultMessageResource))]
        WithCustomStatusCode,

        [Customize(HttpStatusCode.Conflict, typeof(ResultMessageResource))]
        RecordAlreadyExists,
    }
}