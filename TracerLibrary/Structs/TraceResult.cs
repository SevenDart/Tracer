using System.Collections.Generic;

namespace TracerLibrary.Structs
{
    public struct TraceResult
    {
        public List<ThreadInfo> Threads { get; set; }
    }
}