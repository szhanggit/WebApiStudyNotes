using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace MPSClient.Infrastructure
{
    public static class CommonHelper
    {
        public static int GetDate(this DateTime dateTime)
        {
            return int.Parse(dateTime.ToString("yyyyMMdd"));
        }

        public static string Append(params object[] objs)
        {
            var stringBuilder = new StringBuilder();

            foreach (var obj in objs)
            {
                stringBuilder.Append(obj);
            }

            return stringBuilder.ToString();
        }

        public static DateTime ParseToDateTime(this string dateTime, DateTime defaultDateTime)
        {
            DateTime result = defaultDateTime;
            DateTime.TryParse(dateTime, out result);

            return result;
        }

        public static DateTime ParseToEndDateTime(this string dateTime, DateTime defaultDateTime)
        {
            DateTime result = defaultDateTime.Date;
            if (DateTime.TryParse(dateTime, out result))
            {
                result = result.AddDays(1).AddSeconds(-1);
            }

            return result;
        }

        public static int ParseToInt(this string value)
        {
            int parsedInt = 0;

            int.TryParse(value, out parsedInt);

            return parsedInt;
        }

        public static void AddClone<T>(this List<T> paramList, IEnumerable<T> collection) where T : new()
        {
            foreach (var item in collection)
            {
                T t = new T();

                foreach (var property in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanWrite))
                {
                    property.SetValue(t, property.GetValue(item));
                }

                paramList.Add(t);
            }
        }

        public static string ConvertToBase36String(int n, int length)
        {
            if (n < 0)
                return null;

            var sb = new StringBuilder();

            string t = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            while (n > 0)
            {
                sb.Append(t[n % 36]);
                n /= 36;
            }

            t = sb.ToString();
            n = t.Length;
            sb.Length = 0;

            while (--n >= 0) sb.Append(t[n]);

            t = sb.ToString().PadLeft(length, '0');

            return t.Substring(0, length);
        }

        public static string HashLoginInfo(string userName, string password)
        {
            string source = userName + "=" + password;
            return source.MD5String();
        }

        public static string GenerateRandomPassword(int length)
        {
            var password = "";
            while (password.Length < length)
            {
                password += string.Concat(System.Web.Security.Membership.GeneratePassword(1, 0).Where(char.IsLetterOrDigit));
            }
            return password;
        }

        public static int ToIn32(this string input, int defaultValue = default(int))
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                int.TryParse(input, out defaultValue);
            }
            return defaultValue;
        }

        public static int? ToIn32Nullable(this string input)
        {
            int? temp = null;
            if (!string.IsNullOrWhiteSpace(input))
            {
                int value;
                if (int.TryParse(input, out value))
                {
                    temp = value;
                }
            }
            return temp;
        }

        public static long ToIn64(this string input, long defaultValue = default(long))
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                long.TryParse(input, out defaultValue);
            }
            return defaultValue;
        }

        public static long? ToIn64Nullable(this string input)
        {
            long? temp = null;
            if (!string.IsNullOrWhiteSpace(input))
            {
                long value;
                if (long.TryParse(input, out value))
                {
                    temp = value;
                }
            }
            return temp;
        }

        public static decimal ToDecimal(this string input, decimal defaultValue = default(decimal))
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                decimal.TryParse(input, out defaultValue);
            }
            return defaultValue;
        }

        public static decimal? ToDecimalNullable(this string input)
        {
            decimal? temp = null;
            if (!string.IsNullOrWhiteSpace(input))
            {
                decimal value;
                if (decimal.TryParse(input, out value))
                {
                    temp = value;
                }
            }
            return temp;
        }

        public static float ToFloat(this string input, float defaultValue = default(float))
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                float.TryParse(input, out defaultValue);
            }
            return defaultValue;
        }

        public static void SetKey(this object obj, string key, string value)
        {
            PropertyInfo property = obj.GetType().GetProperty(key);

            property.SetValue(obj, value);
        }

        public static object GetKey(this object obj, string key)
        {
            PropertyInfo property = obj.GetType().GetProperty(key);

            return property.GetValue(obj);
        }

        public static List<T> ToEntityList<T>(this string xml) where T : new()
        {
            List<T> list = new List<T>();
            if (!string.IsNullOrWhiteSpace(xml))
            {
                Type type = typeof(T);
                var Properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                XDocument xdoc = XDocument.Parse(xml);
                IEnumerable<XElement> elements = xdoc.Root.Elements();

                foreach (XElement element in elements)
                {
                    if (element.Name != type.Name)
                    {
                        continue;
                    }

                    T obj = new T();

                    foreach (PropertyInfo propertyInfo in Properties)
                    {
                        XElement ele = element.Element(propertyInfo.Name);
                        if (ele != null && propertyInfo.CanWrite)
                        {
                            string value = ele.Value;
                            if (!string.IsNullOrWhiteSpace(value))
                            {
                                if (propertyInfo.PropertyType.IsEnum)
                                {
                                    propertyInfo.SetValue(obj, Convert.ToInt32(value));
                                }
                                else
                                {
                                    propertyInfo.SetValue(obj, Convert.ChangeType(value, Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType));
                                }

                            }
                        }
                    }

                    list.Add(obj);
                }
            }
            return list;
        }

        public static string ToNullString(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;//将空字符转成null
            }
            return str;
        }

        public static string ToSplitString(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            char[] charArray = str.ToCharArray();
            StringBuilder sb = new StringBuilder(charArray.Length);
            for (int i = 0; i < charArray.Length; i++)
            {
                char item = charArray[i];
                if (item >= 65 && item <= 90)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(' ');
                    }
                }

                sb.Append(item);
            }
            return sb.ToString();
        }

        public static void SetDataRow(this DataRow dataRow, string key, object value)
        {
            if (dataRow.Table.Columns.Contains(key))
            {
                dataRow[key] = value;
            }
        }

        public static void AddEFColumn(string filePath, string tableName, params SqlParameter[] sqlParameterList)
        {
            //执行后需要运行edmx文件 生成class

            XDocument document = XDocument.Load(filePath);

            XElement element = document.Root.Elements().FirstOrDefault(e => e.Name.LocalName == "Runtime");

            foreach (var item in element.Elements())
            {
                if (item.Name.LocalName == "StorageModels")
                {
                    var ele = item.Elements().FirstOrDefault().Elements().FirstOrDefault(e => e.Name.LocalName == "EntityType" && e.FirstAttribute.Value == tableName);

                    foreach (var sqlParameter in sqlParameterList)
                    {
                        var child = new XElement((XElement)ele.LastNode);
                        child.RemoveAttributes();

                        child.Add(new XAttribute("Name", sqlParameter.ParameterName));
                        child.Add(new XAttribute("Type", sqlParameter.SqlDbType.ToString().ToLower()));
                        if (!sqlParameter.IsNullable)
                        {
                            child.Add(new XAttribute("Nullable", "false"));
                        }
                        if (sqlParameter.Size > 0)
                        {
                            child.Add(new XAttribute("MaxLength", sqlParameter.Size.ToString()));
                        }

                        ele.Add(child);
                    }
                }
                else if (item.Name.LocalName == "ConceptualModels")
                {
                    var ele = item.Elements().FirstOrDefault().Elements().FirstOrDefault(e => e.Name.LocalName == "EntityType" && e.FirstAttribute.Value == tableName);

                    foreach (var sqlParameter in sqlParameterList)
                    {
                        var lastNode = ele.Elements().Where(e => e.Name.LocalName == "Property").LastOrDefault();
                        var child = new XElement(lastNode);
                        child.RemoveAttributes();

                        child.Add(new XAttribute("Name", sqlParameter.ParameterName));
                        if (sqlParameter.DbType == DbType.AnsiString)
                        {
                            child.Add(new XAttribute("Type", DbType.String.ToString()));
                        }
                        else
                        {
                            child.Add(new XAttribute("Type", sqlParameter.DbType.ToString()));
                        }

                        if (!sqlParameter.IsNullable)
                        {
                            child.Add(new XAttribute("Nullable", "false"));
                        }
                        if (sqlParameter.Size > 0)
                        {
                            child.Add(new XAttribute("MaxLength", sqlParameter.Size.ToString()));

                            var sqlType = sqlParameter.SqlDbType.ToString().ToLower();
                            //varchar or char
                            if (sqlType.Contains("var"))
                            {
                                child.Add(new XAttribute("FixedLength", "false"));
                            }
                            else
                            {
                                child.Add(new XAttribute("FixedLength", "true"));
                            }

                            //nchar or char
                            if (sqlType.StartsWith("n"))
                            {
                                child.Add(new XAttribute("Unicode", "true"));
                            }
                            else
                            {
                                child.Add(new XAttribute("Unicode", "false"));
                            }
                        }

                        lastNode.AddAfterSelf(child);
                    }
                }
                else if (item.Name.LocalName == "Mappings")
                {
                    var ele = ((item.FirstNode as XElement).FirstNode as XElement).Elements().Where(e => e.Name.LocalName == "EntitySetMapping" && e.FirstAttribute.Value == tableName + "s").FirstOrDefault();
                    if (ele == null)
                    {
                        //元音复数+es
                        ele = ((item.FirstNode as XElement).FirstNode as XElement).Elements().Where(e => e.Name.LocalName == "EntitySetMapping" && e.FirstAttribute.Value == tableName + "es").FirstOrDefault();
                    }

                    ele = ((ele.FirstNode as XElement).FirstNode as XElement);

                    foreach (var sqlParameter in sqlParameterList)
                    {
                        var child = new XElement((XElement)ele.FirstNode);
                        child.RemoveAttributes();

                        child.Add(new XAttribute("Name", sqlParameter.ParameterName));
                        child.Add(new XAttribute("ColumnName", sqlParameter.ParameterName));

                        ele.AddFirst(child);
                    }
                }
            }

            document.Save(filePath);
        }

        private static MD5 MD5Provider = MD5.Create();// 真实类型为 MD5CryptoServiceProvider

        public static string MD5String(this string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                return bytes.MD5String();
            }

            return null;
        }

        public static string MD5String(this byte[] input)
        {
            StringBuilder sb = new StringBuilder(32);
            byte[] computeBytes = MD5Provider.ComputeHash(input);

            for (int i = 0; i < computeBytes.Length; i++)
            {
                sb.Append(computeBytes[i].ToString("x2"));//x -> 小写 X -> 大写 x2 -> 补0保证是32位
            }

            return sb.ToString();
        }

        public static string MD5String(this Stream stream)
        {
            StringBuilder sb = new StringBuilder(32);
            byte[] computeBytes = MD5Provider.ComputeHash(stream);

            for (int i = 0; i < computeBytes.Length; i++)
            {
                sb.Append(computeBytes[i].ToString("x2"));//x -> 小写 X -> 大写 x2 -> 补0保证是32位
            }

            return sb.ToString();
        }

        public static async Task<HttpResponseMessage> PostAsJsonAsync<TModel>(this HttpClient client, string requestUrl, TModel model)
        {
            var json = SerializeToJson(model);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            return await client.PostAsync(requestUrl, stringContent);
        }

        public static string SerializeToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T DeserializeFromJson<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}