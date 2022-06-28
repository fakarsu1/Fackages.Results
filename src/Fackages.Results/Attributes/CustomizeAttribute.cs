using System.ComponentModel;
using System.Net;
using System.Reflection;

namespace Fackages.Results.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CustomizeAttribute : DisplayNameAttribute
    {
        private readonly Type? _resourceType;

        public CustomizeAttribute(Type? resourceType) : this(string.Empty, resourceType)
        {
        }

        public CustomizeAttribute(string displayName, Type? resourceType = null) : base(displayName)
        {
            _resourceType = resourceType;
        }

        public CustomizeAttribute(HttpStatusCode httpStatusCode, Type? resourceType = null) : this(string.Empty, resourceType)
        {
            StatusCode = httpStatusCode;
        }

        public CustomizeAttribute(HttpStatusCode httpStatusCode, string displayName, Type? resourceType = null) : this(displayName, resourceType)
        {
            StatusCode = httpStatusCode;
        }

        public HttpStatusCode StatusCode { get; }

        public string GetLocalizedDisplayName(Enum resultMessage)
        {
            if (string.IsNullOrEmpty(DisplayName))
            {
                if (_resourceType != null)
                {
                    var propertyInfo = _resourceType.GetProperty(resultMessage.ToString(), BindingFlags.Static | BindingFlags.Public);
                    var localizedValue = Convert.ToString(propertyInfo?.GetValue(propertyInfo.DeclaringType, null));
                    return string.IsNullOrEmpty(localizedValue) ? resultMessage.ToString() : localizedValue;
                }
                return resultMessage.ToString();
            }
            return GetLocalizedDisplayName();
        }

        private string GetLocalizedDisplayName()
        {
            if (_resourceType != null)
            {
                var propertyInfo = _resourceType.GetProperty(DisplayName, BindingFlags.Static | BindingFlags.Public);
                var localizedValue = Convert.ToString(propertyInfo?.GetValue(propertyInfo.DeclaringType, null));
                return string.IsNullOrEmpty(localizedValue) ? DisplayName : localizedValue;
            }
            return DisplayName;
        }
    }
}