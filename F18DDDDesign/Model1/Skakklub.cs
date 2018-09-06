using System.Collections.Generic;

namespace F18DDDDesign.Model1
{

    public class Skakklub
    {
        public string id { get; set; }
        public string Klubnavn { get; set; }
        public List<Tilforordnede> Tilforordnede { get; set; }
        public List<Turneringer> Turneringer { get; set; }
    }

    public class Tilforordnede
    {
        public string TilfordnedesNavn { get; set; }
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
        public List<Turneringenstilforordnede> TurneringensTilforordnede { get; set; }
    }

    public class Turneringenstilforordnede
    {
        public string Navn { get; set; }
        public string Klubid { get; set; }
    }

}
