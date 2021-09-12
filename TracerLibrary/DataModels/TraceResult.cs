using System;
using System.Collections.Generic;

namespace TracerLibrary.DataModels
{
    public struct TraceResult : ICloneable
    {
        public Dictionary<int, ThreadInformation> Threads { get; set; }
        public object Clone()
        {
            var copy = (TraceResult)MemberwiseClone();
            copy.Threads = new Dictionary<int, ThreadInformation>();
            foreach (var (id, threadInformation) in Threads)
            {
                copy.Threads.Add(id, (ThreadInformation)threadInformation.Clone());
            }
            return copy;
        }
    }
}