namespace F18DDDDesign.Model1
{


    public class PersonHobby
    {
        public string id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string dob { get; set; }
        public Hobby[] hobbies { get; set; }
    }

    public class Hobby
    {
        public string type { get; set; }
        public string description { get; set; }
        public Preference[] preferences { get; set; }
    }

    public class Preference
    {
        public string type { get; set; }
    }

}
