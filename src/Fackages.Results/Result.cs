using Fackages.Results.Attributes;
using Fackages.Results.Base;
using Fackages.Results.Extensions;
using Fackages.Results.Messages;
using System.Net;

namespace Fackages.Results
{
    public static class Result
    {
        public static IResult Success()
        {
            return Create(true, DefaultResultMessage.Success);
        }

        public static IResult Success(Enum resultMessage, params object[] messageArgs)
        {
            return Create(true, resultMessage, messageArgs);
        }

        public static IDataResult<T> SuccessData<T>()
        {
            return CreateData<T>(default, true, DefaultResultMessage.Success);
        }

        public static IDataResult<T> SuccessData<T>(T data)
        {
            return CreateData(data, true, DefaultResultMessage.Success);
        }

        public static IDataResult<T> SuccessData<T>(Enum resultMessage, params object[] messageArgs)
        {
            return CreateData<T>(default, true, resultMessage, messageArgs);
        }

        public static IDataResult<T> SuccessData<T>(T data, Enum resultMessage, params object[] messageArgs)
        {
            return CreateData(data, true, resultMessage, messageArgs);
        }

        public static IResult Error()
        {
            return Create(false, DefaultResultMessage.BadRequest);
        }

        public static IResult Error(Enum resultMessage, params object[] messageArgs)
        {
            return Create(false, resultMessage, messageArgs);
        }

        public static IDataResult<T> ErrorData<T>()
        {
            return CreateData<T>(default, false, DefaultResultMessage.BadRequest);
        }

        public static IDataResult<T> ErrorData<T>(T data)
        {
            return CreateData(data, false, DefaultResultMessage.BadRequest);
        }

        public static IDataResult<T> ErrorData<T>(Enum resultMessage, params object[] messageArgs)
        {
            return CreateData<T>(default, false, resultMessage, messageArgs);
        }

        public static IDataResult<T> ErrorData<T>(T data, Enum resultMessage, params object[] messageArgs)
        {
            return CreateData(data, false, resultMessage, messageArgs);
        }

        private static IResult Create(bool isSuccess, Enum resultMessage, params object[] messageArgs)
        {
            var customizeAttribute = resultMessage.GetCustomizeAttribute() ?? new CustomizeAttribute(isSuccess ? HttpStatusCode.OK : HttpStatusCode.BadRequest);

            var message = customizeAttribute.GetLocalizedDisplayName(resultMessage);
            if (messageArgs?.Length > 0)
            {
                message = string.Format(message, messageArgs);
            }

            var httpStatusCode = customizeAttribute.StatusCode;
            if (customizeAttribute.StatusCode == default)
            {
                httpStatusCode = isSuccess ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            }

            return new ResultBase(isSuccess, Convert.ToInt32(resultMessage), message, (int)httpStatusCode);
        }

        private static IDataResult<T> CreateData<T>(T data, bool isSuccess, Enum resultMessage, params object[] messageArgs)
        {
            var customizeAttribute = resultMessage.GetCustomizeAttribute() ?? new CustomizeAttribute(isSuccess ? HttpStatusCode.OK : HttpStatusCode.BadRequest);

            var message = customizeAttribute.GetLocalizedDisplayName(resultMessage);
            if (messageArgs?.Length > 0)
            {
                message = string.Format(message, messageArgs);
            }

            var httpStatusCode = customizeAttribute.StatusCode;
            if (customizeAttribute.StatusCode == default)
            {
                httpStatusCode = isSuccess ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            }

            return new DataResultBase<T>(data, isSuccess, Convert.ToInt32(resultMessage), message, (int)httpStatusCode);
        }
    }
}