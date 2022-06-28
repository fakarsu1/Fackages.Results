using Fackages.Results.Attributes;

namespace Fackages.Results.Extensions
{
    public static class EnumExtensions
    {
        public static CustomizeAttribute? GetCustomizeAttribute(this Enum resultMessage)
        {
            var type = resultMessage.GetType();
            var memberInfos = type.GetMember(resultMessage.ToString());
            var attributes = memberInfos[0].GetCustomAttributes(typeof(CustomizeAttribute), false);
            return attributes.Length > 0 ? (CustomizeAttribute)attributes[0] : null;
        }
    }
}