using System;

namespace Cudo.Common
{
    public class ConvertTypes<T>
    {
        public ConvertTypes()
        { }

        public static T ConvertType<T>(object value, T defaultValue)
        {
            return (T)ConvertToT<T>(value, defaultValue);
        }


        private static object ConvertToT<T>(object myvalue, T defaultValue)
        {
            TypeCode typeCode = System.Type.GetTypeCode(typeof(T));
            if (myvalue == null)
                return defaultValue;
            string value = myvalue.ToString();
            switch (typeCode)
            {
                case TypeCode.Boolean:
                    bool flag = false;
                    if (bool.TryParse(value, out flag))
                        return flag;
                    return defaultValue;
                case TypeCode.Char:
                    char c;
                    if (Char.TryParse(value, out c))
                        return c;
                    return defaultValue;
                case TypeCode.SByte:
                    sbyte s = 0;
                    if (SByte.TryParse(value, out s))
                        return s;
                    return defaultValue;
                case TypeCode.Byte:
                    byte b = 0;
                    if (Byte.TryParse(value, out b))
                        return b;
                    return defaultValue;
                case TypeCode.Int16:
                    Int16 i16 = 0;
                    if (Int16.TryParse(value, out i16))
                        return i16;
                    return defaultValue;
                case TypeCode.UInt16:
                    UInt16 ui16 = 0;
                    if (UInt16.TryParse(value, out ui16))
                        return ui16;
                    return defaultValue;
                case TypeCode.Int32:
                    int i = 0;
                    if (Int32.TryParse(value, out i))
                        return i;
                    return defaultValue;
                case TypeCode.UInt32:
                    UInt32 ui32 = 0;
                    if (UInt32.TryParse(value, out ui32))
                        return ui32;
                    return defaultValue;
                case TypeCode.Int64:
                    Int64 i64 = 0;
                    if (Int64.TryParse(value, out i64))
                        return i64;
                    return defaultValue;
                case TypeCode.UInt64:
                    UInt64 ui64 = 0;
                    if (UInt64.TryParse(value, out ui64))
                        return ui64;
                    return defaultValue;
                case TypeCode.Single:
                    Single single = 0;
                    if (Single.TryParse(value, out single))
                        return single;
                    return defaultValue;
                case TypeCode.Double:
                    double d = 0;
                    if (Double.TryParse(value, out d))
                        return d;
                    return defaultValue;
                case TypeCode.Decimal:
                    decimal de = 0;
                    if (Decimal.TryParse(value, out de))
                        return de;
                    return defaultValue;
                case TypeCode.DateTime:
                    DateTime dt;
                    if (DateTime.TryParse(value, out dt))
                        return dt;
                    return defaultValue;
                case TypeCode.String:
                    if (value.Length == 0)
                        return "";
                    return value.ToString();
            }
            throw new ArgumentNullException("defaultValue", "不能为Empty,Object,DBNull");
        }

    }
}

