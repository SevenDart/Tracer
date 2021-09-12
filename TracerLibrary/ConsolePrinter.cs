
using System;
using TracerLibrary.DataModels;
using TracerLibrary.Interfaces;

namespace TracerLibrary
{
    public class ConsolePrinter: IPrinter
    {
        public void Print(ISerializer serializer, TraceResult traceResult)
        {
            Console.WriteLine(serializer.Serialize(traceResult));
        }
    }
}