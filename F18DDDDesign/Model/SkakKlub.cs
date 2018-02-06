using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F18DDDDesign.Model
{
    class SkakKlub
    {
    }

    //public class Rootobject
    public class TurneringsSkakKlub
    {
        public string id { get; set; }
        public string Klubnavn { get; set; }
        //public Tilforordnede[] Tilforordnede { get; set; }
        public List<Tilforordnede> Tilforordnede { get; set; }
        //public Turneringer[] Turneringer { get; set; }
        public List<Turneringer> Turneringer { get; set; }
    }

    public class Tilforordnede
    {
        public string TilfordnedesNavn { get; set; }
        //public Turneringsdeltagelse[] TurneringsDeltagelse { get; set; }
        public List<Turneringsdeltagelse> TurneringsDeltagelse { get; set; }
    }

    public class Turneringsdeltagelse
    {
        public string TurneringsNavn { get; set; }
    }

    public class Turneringer
    {
        public string TurneringsNavn { get; set; }
        public string TurneringsStatus { get; set; }
        //public Turneringenstilforordnede[] TurneringensTilforordnede { get; set; }
        public List<Turneringenstilforordnede> TurneringensTilforordnede { get; set; }
    }

    public class Turneringenstilforordnede
    {
        public string Navn { get; set; }
        public string Klubid { get; set; }
    }

}
