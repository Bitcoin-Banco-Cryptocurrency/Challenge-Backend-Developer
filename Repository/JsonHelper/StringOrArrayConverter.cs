using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Repository.Entities;

namespace Repository.JsonHelper
{
    internal class StringOrArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(StringOrArray) || t == typeof(StringOrArray?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new StringOrArray { String = stringValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<List<string>>(reader);
                    return new StringOrArray { StringArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type StringOrArray");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (StringOrArray)untypedValue;
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.StringArray != null)
            {
                serializer.Serialize(writer, value.StringArray);
                return;
            }
            throw new Exception("Cannot marshal type Genres");
        }

        public static readonly StringOrArrayConverter Singleton = new StringOrArrayConverter();
    }
}