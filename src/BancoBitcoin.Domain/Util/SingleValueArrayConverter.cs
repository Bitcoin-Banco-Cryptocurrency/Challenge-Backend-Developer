using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace BancoBitcoin.Domain.Util
{
    public class SingleValueArrayConverter<T> : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);

            if (token.Type == JTokenType.Array)
            {
                return token.ToObject<List<T>>();
            }

            var item = token.ToObject<T>();

            return new List<T> { item };
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
