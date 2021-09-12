using System.IO;
using System.Collections.Generic;
using System.Linq;
using TracerLibrary.DataModels;
using TracerLibrary.Interfaces;

namespace TracerLibrary
{
    public class XmlSerializer : ISerializer
    {
        public string Serialize(TraceResult traceResult)
        {
            var list = traceResult.Threads.Values.ToList();

            var extraTypes = new[] {
                typeof(ThreadInformation),
                typeof(MethodInformation)
            };
            
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<ThreadInformation>), extraTypes);

            using var stream = new MemoryStream();
            serializer.Serialize(stream, list);
            stream.Position = 0;

            var streamReader = new StreamReader(stream);
            return streamReader.ReadToEnd();
        }
    }
}