using System;
using System.Collections.Generic;

namespace TracerLibrary.DataModels
{
    public class ThreadInformation : ICloneable
    {
        public int Id { get; init; }
        public TimeSpan Time { get; set; }
        public List<MethodInformation> Methods { get; set; }
        public object Clone()
        {
            var copy = (ThreadInformation)MemberwiseClone();
            copy.Methods = new List<MethodInformation>();
            foreach (var methodInformation in Methods)
            {
                copy.Methods.Add((MethodInformation)methodInformation.Clone());
            }

            return copy;
        }
    }
}