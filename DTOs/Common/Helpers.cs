using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DTOs.Common
{
    public static class Helpers
    {
        public static string SerializeMethod<T>(this T obj)
        {
            var config = new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = false,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            string serializedData = System.Text.Json.JsonSerializer.Serialize(obj, config);

            return serializedData;
        }

        public static T DeserializeMethod<T>(this string myJson)
        {
            var config = new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var myDTO = System.Text.Json.JsonSerializer.Deserialize<T>(myJson, config);

            return myDTO;
        }
    }
}
