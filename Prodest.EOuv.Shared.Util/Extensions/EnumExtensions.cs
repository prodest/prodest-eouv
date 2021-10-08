using System;
using System.ComponentModel;

namespace Prodest.EOuv.Shared.Util
{
    public static class EnumExtensions
    {
        public static string GetEnumDescription(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }

            return value.ToString();
        }

        public static string GetEnumName(this Enum value)
        {
            return value.ToString();
        }

        public static int GetEnumValue(this Enum value)
        {
            return Convert.ToInt32(value);
        }
    }
}