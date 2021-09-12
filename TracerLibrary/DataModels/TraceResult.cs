using System.Collections.Generic;

namespace TracerLibrary.Structs
{
    public struct TraceResult
    {
        public Dictionary<int, ThreadInformation> Threads { get; set; }
    }
}