using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F18DDDDesign.Model4
{

    public class Rootobject1
    {
        public Class1[] Property1 { get; set; }
    }

    public class Class1
    {
        public string key { get; set; }
    }


    public class Rootobject2
    {
        public Array[] array { get; set; }
    }

    public class Array
    {
        public string key { get; set; }
    }



    public class PersonInfo
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public Address1 address { get; set; }
        public List<Phonenumber> phoneNumber { get; set; }
        public Gender gender { get; set; }
    }

    public class Address1
    {
        public string streetAddress { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
    }

    public class Gender
    {
        public string type { get; set; }
    }

    public class Phonenumber
    {
        public string type { get; set; }
        public string number { get; set; }
    }

    //Nedenstående klasser er genereret fra XMLFile1.xml /jrt
    //Arryas [] er erstattet med List<class>

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class person
    {

        private string firstNameField;

        private string lastNameField;

        private byte ageField;

        private personAddress addressField;

        private List<personPhoneNumber> phoneNumberField;

        private personGender genderField;

        /// <remarks/>
        public string firstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }

        /// <remarks/>
        public string lastName
        {
            get
            {
                return this.lastNameField;
            }
            set
            {
                this.lastNameField = value;
            }
        }

        /// <remarks/>
        public byte age
        {
            get
            {
                return this.ageField;
            }
            set
            {
                this.ageField = value;
            }
        }

        /// <remarks/>
        public personAddress address
        {
            get
            {
                return this.addressField;
            }
            set
            {
                this.addressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("phoneNumber")]
        public List<personPhoneNumber> phoneNumber
        {
            get
            {
                return this.phoneNumberField;
            }
            set
            {
                this.phoneNumberField = value;
            }
        }

        /// <remarks/>
        public personGender gender
        {
            get
            {
                return this.genderField;
            }
            set
            {
                this.genderField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class personAddress
    {

        private string streetAddressField;

        private string cityField;

        private string stateField;

        private ushort postalCodeField;

        /// <remarks/>
        public string streetAddress
        {
            get
            {
                return this.streetAddressField;
            }
            set
            {
                this.streetAddressField = value;
            }
        }

        /// <remarks/>
        public string city
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public string state
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }

        /// <remarks/>
        public ushort postalCode
        {
            get
            {
                return this.postalCodeField;
            }
            set
            {
                this.postalCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class personPhoneNumber
    {

        private string typeField;

        private string numberField;

        /// <remarks/>
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public string number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class personGender
    {

        private string typeField;

        /// <remarks/>
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }


}
