using System.Text.Json;
using TracerLibrary.CustomConverters;
using TracerLibrary.DataModels;
using TracerLibrary.Interfaces;


namespace TracerLibrary
{
    public class JsonSerializer: ISerializer
    {
        public string Serialize(TraceResult traceResult)
        {
            var options = new JsonSerializerOptions {WriteIndented = true};
            options.Converters.Add(new TimeSpanConverter(options));
            return System.Text.Json.JsonSerializer.Serialize(traceResult, options);
        }
    }
}