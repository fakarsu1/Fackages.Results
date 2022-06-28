using Fackages.Results.Attributes;
using Fackages.Results.Resources;
using System.Net;

namespace Fackages.Results.Messages
{
    public enum DefaultResultMessage
    {
        [Customize(HttpStatusCode.OK, "Success", typeof(MessageResource))]
        Success = 200,

        [Customize(HttpStatusCode.BadRequest, "BadRequest", typeof(MessageResource))]
        BadRequest = 400,
    }
}