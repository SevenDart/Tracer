using System;
using System.Collections.Generic;

namespace TracerLibrary.Structs
{
    public class MethodInformation
    {
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public TimeSpan Time { get; set; }
        public List<MethodInformation> Methods { get; set; } = new List<MethodInformation>();
    }
}