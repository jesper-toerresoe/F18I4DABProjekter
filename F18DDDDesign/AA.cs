using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace F18DDDDesign
{
    public class AAPersonType
    {
        public AAPersonType(Person tilknyttetPerson, Adresse1 tilknyttetAdresse, string adresseType)
        {
            TilknyttetPerson = tilknyttetPerson ?? throw new ArgumentNullException(nameof(tilknyttetPerson));
            TilknyttetAdresse = tilknyttetAdresse ?? throw new ArgumentNullException(nameof(tilknyttetAdresse));
            AdresseType = adresseType ?? throw new ArgumentNullException(nameof(adresseType));
        }

        public Person TilknyttetPerson { get; set; }
        public Adresse1 TilknyttetAdresse { get; set; }
        public string AdresseType { get; set; }
        
    }
}