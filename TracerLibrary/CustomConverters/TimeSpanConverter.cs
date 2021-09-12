using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TracerLibrary.CustomConverters
{
    public class TimeSpanConverter : JsonConverter<TimeSpan>
    {
        private readonly JsonSerializerOptions _converterOptions;
        public TimeSpanConverter(JsonSerializerOptions converterOptions)
        {
            _converterOptions = converterOptions;
        }
        
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            var translatedValue = value.TotalMilliseconds + "ms";
            System.Text.Json.JsonSerializer.Serialize<string>(writer, translatedValue, _converterOptions);
        }
    }
}