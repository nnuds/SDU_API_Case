using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDU_API_AFnc.DAL
{
    internal class Helper
    {
        public class ConvertDataFromDb
        {
            public static float? ToFloat(object dataDB, bool isNullable = true)
            {
                float? toReturn;
                if (isNullable == true)
                {
                    toReturn = null;
                }
                else
                {
                    toReturn = 0;
                }

                if (string.IsNullOrWhiteSpace(Convert.ToString(dataDB)) == false)
                {
                    toReturn = float.Parse(Convert.ToString(dataDB));
                }

                return toReturn;
            }
            public static int? ToInt(object dataDB, bool isNullable = true)
            {
                int? toReturn = null;
                if (isNullable == true)
                {
                    toReturn = null;
                }
                else
                {
                    toReturn = 0;
                }

                if (string.IsNullOrWhiteSpace(Convert.ToString(dataDB)) == false)
                {
                    toReturn = int.Parse(Convert.ToString(dataDB));
                }

                return toReturn;
            }
            public static int ToInt(object dataDB)
            {
                int? toReturn = ToInt(dataDB, false);
                return Convert.ToInt32(toReturn);
            }

            public static Int16? ToInt16(object dataDB, bool isNullable = true)
            {
                Int16? toReturn = null;
                if (isNullable == true)
                {
                    toReturn = null;
                }
                else
                {
                    toReturn = 0;
                }

                if (string.IsNullOrWhiteSpace(Convert.ToString(dataDB)) == false)
                {
                    toReturn = Int16.Parse(Convert.ToString(dataDB));
                }

                return toReturn;
            }
            public static Int16 ToInt16(object dataDB)
            {
                Int16? toReturn = ToInt16(dataDB, false);
                return Convert.ToInt16(toReturn);
            }
            public static double? ToDouble(object dataDB, bool isNullable = true)
            {
                double? toReturn = null;
                if (isNullable == true)
                {
                    toReturn = null;
                }
                else
                {
                    toReturn = 0;
                }

                if (string.IsNullOrWhiteSpace(Convert.ToString(dataDB)) == false)
                {
                    toReturn = double.Parse(Convert.ToString(dataDB));
                }

                return toReturn;
            }
            public static decimal? ToDecimal(object dataDB, bool isNullable = true)
            {
                decimal? toReturn = null;
                if (isNullable == true)
                {
                    toReturn = null;
                }
                else
                {
                    toReturn = 0;
                }

                if (string.IsNullOrWhiteSpace(Convert.ToString(dataDB)) == false)
                {
                    toReturn = decimal.Parse(Convert.ToString(dataDB));
                }

                return toReturn;
            }
            public static decimal ToDecimal(object dataDB)
            {
                decimal? toReturn = ToDecimal(dataDB, false);
                return Convert.ToDecimal(toReturn);
            }
            public static byte? ToByte(object dataDB, bool isNullable = true)
            {
                byte? toReturn = null;
                if (isNullable == true)
                {
                    toReturn = null;
                }
                else
                {
                    toReturn = 0;
                }

                if (string.IsNullOrWhiteSpace(Convert.ToString(dataDB)) == false)
                {
                    toReturn = byte.Parse(Convert.ToString(dataDB));
                }

                return toReturn;
            }
            public static byte ToByte(object dataDB)
            {
                byte? toReturn = ToByte(dataDB, false);
                return Convert.ToByte(toReturn);
            }
            public static string ToString(object dataDB, bool isNullable = true)
            {
                string toReturn = null;
                if (isNullable == true)
                {
                    toReturn = "NULL";
                }
                else
                {
                    toReturn = "";
                }

                if (string.IsNullOrWhiteSpace(Convert.ToString(dataDB)) == false)
                {
                    toReturn = Convert.ToString(dataDB);
                }

                return toReturn;
            }
            public static string ToString(object dataDB)
            {
                return ToString(dataDB, false);
            }
            public static DateTime? ToDateTime(object dataDB, bool isNullable = true)
            {
                DateTime? toReturn = null;
                if (isNullable == true)
                {
                    toReturn = null;
                }
                else
                {
                    toReturn = new DateTime(1900, 1, 1);
                }

                if (string.IsNullOrWhiteSpace(Convert.ToString(dataDB)) == false)
                {
                    toReturn = DateTime.Parse(Convert.ToString(dataDB));
                }

                return toReturn;
            }
            public static DateTime ToDateTime(object dataDB)
            {
                return Convert.ToDateTime(ToDateTime(dataDB, false));
            }

            public static DateTime DateTimeLocal(DateTime dt)
            {
                DateTime toReturn = TimeZoneInfo.ConvertTime(dt, TimeZoneInfo.Local);
                return toReturn;
            }
            public static DateTime? DateTimeLocal(DateTime? dt)
            {
                DateTime? toReturn = null;
                if (Convert.IsDBNull(dt) == false)
                {
                    toReturn = DateTimeLocal(dt);
                }
                return toReturn;
            }
            public static DateTime DateTimeLocalStandardStart(DateTime dt, int minusDays = 14)
            {
                DateTime toReturn = DateTimeLocal(dt).AddDays(-Math.Abs(minusDays));
                return toReturn;
            }
            public static DateTime? DateTimeLocalStandardStart(DateTime? dt, int minusDays = 14)
            {
                DateTime? toReturn = null;
                if (Convert.IsDBNull(dt) == false)
                {
                    toReturn = DateTimeLocalStandardStart(dt, minusDays);
                }
                return toReturn;
            }

            public static bool? ToBoolean(object dataDB, bool isNullable = true)
            {
                bool? toReturn = null;
                if (isNullable == true)
                {
                    toReturn = null;
                }
                else
                {
                    toReturn = new bool();
                }

                if (string.IsNullOrWhiteSpace(Convert.ToString(dataDB)) == false)
                {
                    toReturn = bool.Parse(Convert.ToString(dataDB));
                }

                return toReturn;
            }
            public static bool ToBoolean(object dataDB)
            {
                bool? toReturn = ToBoolean(dataDB, false);
                return Convert.ToBoolean(toReturn);
            }
            public static short? ToShort(object dataDB, bool isNullable = true)
            {
                short? toReturn = null;
                if (isNullable == true)
                {
                    toReturn = null;
                }
                else
                {
                    toReturn = new short();
                }

                if (string.IsNullOrWhiteSpace(Convert.ToString(dataDB)) == false)
                {
                    toReturn = short.Parse(Convert.ToString(dataDB));
                }

                return toReturn;
            }
            public static short ToShort(object dataDB)
            {
                short? toReturn = ToShort(dataDB, false);
                return (short)toReturn;
            }
            public static string GetFromQueryString(string param, string queryString)
            {
                int a = queryString.IndexOf(param + "=");
                if (a == -1)
                {
                    return "";
                }

                int b = queryString.IndexOf("&", a);
                if (b == -1)
                {
                    b = queryString.Length;
                }

                int c = a + param.Length + 1;
                string toReturn = queryString.Substring(c, b - c);
                return toReturn;
            }
        }

        public class ConvertDataToDb
        {
            public static object ToDb<T>(T val, bool isNullable = false)
            {
                if (val != null)
                {
                    return val;
                }
                else if (isNullable == true)
                {
                    return DBNull.Value;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
