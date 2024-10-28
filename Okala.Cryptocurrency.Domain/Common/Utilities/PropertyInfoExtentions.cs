using System.Reflection;

namespace Okala.Cryptocurrency.Domain.Common.Utilities
{
    public static class PropertyInfoExtentions
    {

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
