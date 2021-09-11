using System;
using System.Collections.Generic;

namespace TracerLibrary.Structs
{
    public struct MethodInfo
    {
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public TimeSpan Time { get; set; }
        public List<MethodInfo> Methods { get; set; }
    }
}