namespace F18DDDDesign
{

    public class RootPerson
    {
        public string Person { get; set; }
        public string MellemNavn { get; set; }
        public string Efternavn { get; set; }
        public Folkeregisteadresse FolkeregisteAdresse { get; set; }
        public Altenativadresser[] Altenativadresser { get; set; }
    }

    public class Folkeregisteadresse
    {
        public string Vejnavn { get; set; }
        public By By { get; set; }
    }

    public class By
    {
        public string Bynavn { get; set; }
        public string Postnummer { get; set; }
        public string Land { get; set; }
    }

    public class Altenativadresser
    {
        public string Vejnavn { get; set; }
        public string AdresseType { get; set; }
        public By1 By { get; set; }
    }

    public class By1
    {
        public string Bynavn { get; set; }
        public string Postnummer { get; set; }
        public string Land { get; set; }
    }

}
