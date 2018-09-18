using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace F18DDDDesign
{
    public class Person
    {
        public Person()
        {
        }

        public Adresse1 FolkeregisrerAdresse { get; set; }
        public List<AAPersonType> AlternativeAdresser { get; set; }
    }
}