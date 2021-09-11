using System;
using System.Collections.Generic;

namespace TracerLibrary.Structs
{
    public struct ThreadInfo
    {
        public int Id { get; set; }
        public TimeSpan Time { get; set; }
        public List<MethodInfo> Methods { get; set; }
    }
}