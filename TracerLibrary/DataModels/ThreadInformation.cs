using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TracerLibrary.DataModels
{
    public class ThreadInformation : ICloneable
    {
        [XmlAttribute]
        public int Id { get; set; }
        
        [XmlAttribute]
        public TimeSpan Time { get; set; }
        
        [XmlArray]
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