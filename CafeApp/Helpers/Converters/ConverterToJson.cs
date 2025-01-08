using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CafeApp.Helpers.Converters
{
    public static class ConverterToJson
    {
        static public string ConvertToJson(object value)
        {
            if (value is null) throw new ArgumentNullException();
            return JsonConvert.SerializeObject(value);
        }
        static public T ConvertFromJson<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
