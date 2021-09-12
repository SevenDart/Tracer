using System;
using System.IO;
using TracerLibrary.DataModels;
using TracerLibrary.Interfaces;

namespace TracerLibrary
{
    public class FilePrinter: IPrinter

    {
        public void Print(ISerializer serializer, TraceResult traceResult)
        {
            using var streamWriter = new StreamWriter("traceResults"+ DateTime.Now.ToFileTimeUtc() + ".txt");
            streamWriter.Write(serializer.Serialize(traceResult));
        }
    }
}