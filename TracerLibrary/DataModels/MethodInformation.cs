using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace TracerLibrary.DataModels
{
    public class MethodInformation : ICloneable
    {
        [XmlAttribute]
        public string ClassName { get; set; }
        
        [XmlAttribute]
        public string MethodName { get; set; }
        
        [XmlAttribute]
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