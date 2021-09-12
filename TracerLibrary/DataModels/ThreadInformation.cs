using System;
using System.Collections.Generic;

namespace TracerLibrary.Structs
{
    public class ThreadInformation
    {
        public int Id { get; set; }
        public TimeSpan Time { get; set; }
        public List<MethodInformation> Methods { get; set; }
    }
}