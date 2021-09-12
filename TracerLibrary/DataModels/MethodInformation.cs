using System;
using System.Collections.Generic;

namespace TracerLibrary.DataModels
{
    public class MethodInformation : ICloneable
    {
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public TimeSpan Time { get; set; }
        public List<MethodInformation> Methods { get; set; } = new List<MethodInformation>();
        public object Clone()
        {
            var copy = (MethodInformation)MemberwiseClone();
            copy.Methods = new List<MethodInformation>();
            foreach (var methodInformation in Methods)
            {
                copy.Methods.Add((MethodInformation)methodInformation.Clone());
            }

            return copy;
        }
    }
}