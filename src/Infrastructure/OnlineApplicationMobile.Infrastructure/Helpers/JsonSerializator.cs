using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace OnlineApplicationMobile.Infrastructure.Helpers
{
    /// <summary>
    /// Статический класс для сериализации/десириализации объектов
    /// </summary>
    public static class JsonSerializator
    {
        /// <summary>
        /// Настройка для сериализации.
        /// </summary>
        private static JsonSerializerOptions optionsSerializeDefault = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        private static JsonSerializerOptions optionsSerializeFormat = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        public static string Serialize<T>(T obj, JsonSerializerOptions options)
        {
            return JsonSerializer.Serialize(obj);
        }

        public static string SerializeByDefaultOptions<T>(T obj)
        {
            return Serialize<T>(obj, optionsSerializeDefault);
        }

        public static string SerializeByFormatOptions<T>(T obj)
        {
            return Serialize<T>(obj, optionsSerializeFormat);
        }

        public static T Desirialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, optionsSerializeDefault);
        }
    }
}
