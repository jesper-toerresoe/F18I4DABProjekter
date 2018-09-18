using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace F18DDDDesign
{
    public class Adresse1
    {
        public Adresse1()
        {
        }

        public List<Person> FRAPersoner { get; set; }
        public List<AAPersonType> PersonerPaaAlternativeAdressen { get; set; }
    }
}