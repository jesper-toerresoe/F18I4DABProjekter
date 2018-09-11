namespace F18DDDDesign
{

    public class Rootobject
    {
        public string id { get; set; }
        public string Navn { get; set; }
        public string Mellemnavn { get; set; }
        public string Efternavn { get; set; }
        public float Ancinnitet { get; set; }
        public string[] Fag { get; set; }
        public Kontor Kontor { get; set; }
    }

    public class Kontor
    {
        public Adresse Adresse { get; set; }
        public string Bygning { get; set; }
        public string Rumnr { get; set; }
    }

    public class Adresse
    {
        public string Vejnavn { get; set; }
        public string Postnummer { get; set; }
        public string By { get; set; }
    }

}
