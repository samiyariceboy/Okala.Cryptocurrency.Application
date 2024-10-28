using AngleSharp.Common;
using System.Collections.Generic;
using System.Reflection;

namespace Okala.Cryptocurrency.Domain.Common.Utilities
{
    public static class PropertyInfoExtentions
    {
        public static Dictionary<string, object> GetObjectProperties(this object obj)
        {
            try
            {
                var a = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Select(prop => prop.GetValue(obj, null)).ToList();
                var result = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .ToDictionary(prop => prop.Name, prop => prop.GetValue(obj, null));
                return result;
            }
            catch (Exception)
            {

                return new Dictionary<string, object>();
            }

        }

        public static Dictionary<string, object> ToDictionary(this object obj)
        {
            var dictionary = new Dictionary<string, object>();
            foreach (PropertyInfo property in obj.GetType().GetProperties())
            {
                try
                {
                    var value = property.GetValue(obj);
                    if (value != null && (property.PropertyType.IsClass && property.PropertyType != typeof(string)))
                    {
                        dictionary.Add(property.Name, value.ToDictionary());
                    }
                    else
                    {
                        dictionary.Add(property.Name, value);
                    }
                }
                catch (Exception e)
                {

                }
            }
            return dictionary;
        }
    }
}
