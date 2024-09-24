using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatiVerCore.Domain.Entities.Response
{
    [System.Diagnostics.DebuggerStepThrough()]
    [System.CodeDom.Compiler.GeneratedCode("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContract(Name = "PersonData", Namespace = "http://khfoms.ru/bdz")]
    public partial class PersonData : object
    {

        private string PersonIdField;

        private string PersonENPField;

        private string PersonSurnameField;

        private string PersonFirstnameField;

        private string PersonSecnameField;

        private string PersonBirthdayField;

        private string PersonSexField;

        private string PersonBirthplaceField;

        private string PersonSNILSField;

        private PersonAddress personAddressField;

        private string PersonCitizenshipField;

        private string DocumentTypeField;

        private string DocumentSerField;

        private string DocumentNumField;

        private string DocumentDateField;

        private string DocumentOrgField;

        private string PersonSocStatusField;

        private string PersonCategoryField;

        private string PersonDeathDateField;

        private string PersonPhoneField;

        [System.Runtime.Serialization.DataMember()]
        public string PersonId
        {
            get
            {
                return PersonIdField;
            }
            set
            {
                PersonIdField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 1)]
        public string PersonENP
        {
            get
            {
                return PersonENPField;
            }
            set
            {
                PersonENPField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 2)]
        public string PersonSurname
        {
            get
            {
                return PersonSurnameField;
            }
            set
            {
                PersonSurnameField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 3)]
        public string PersonFirstname
        {
            get
            {
                return PersonFirstnameField;
            }
            set
            {
                PersonFirstnameField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 4)]
        public string PersonSecname
        {
            get
            {
                return PersonSecnameField;
            }
            set
            {
                PersonSecnameField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 5)]
        public string PersonBirthday
        {
            get
            {
                return PersonBirthdayField;
            }
            set
            {
                PersonBirthdayField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 6)]
        public string PersonSex
        {
            get
            {
                return PersonSexField;
            }
            set
            {
                PersonSexField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 7)]
        public string PersonBirthplace
        {
            get
            {
                return PersonBirthplaceField;
            }
            set
            {
                PersonBirthplaceField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 8)]
        public string PersonSNILS
        {
            get
            {
                return PersonSNILSField;
            }
            set
            {
                PersonSNILSField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 9)]
        public PersonAddress personAddress
        {
            get
            {
                return personAddressField;
            }
            set
            {
                personAddressField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 10)]
        public string PersonCitizenship
        {
            get
            {
                return PersonCitizenshipField;
            }
            set
            {
                PersonCitizenshipField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 11)]
        public string DocumentType
        {
            get
            {
                return DocumentTypeField;
            }
            set
            {
                DocumentTypeField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 12)]
        public string DocumentSer
        {
            get
            {
                return DocumentSerField;
            }
            set
            {
                DocumentSerField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 13)]
        public string DocumentNum
        {
            get
            {
                return DocumentNumField;
            }
            set
            {
                DocumentNumField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 14)]
        public string DocumentDate
        {
            get
            {
                return DocumentDateField;
            }
            set
            {
                DocumentDateField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 15)]
        public string DocumentOrg
        {
            get
            {
                return DocumentOrgField;
            }
            set
            {
                DocumentOrgField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 16)]
        public string PersonSocStatus
        {
            get
            {
                return PersonSocStatusField;
            }
            set
            {
                PersonSocStatusField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 17)]
        public string PersonCategory
        {
            get
            {
                return PersonCategoryField;
            }
            set
            {
                PersonCategoryField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 18)]
        public string PersonDeathDate
        {
            get
            {
                return PersonDeathDateField;
            }
            set
            {
                PersonDeathDateField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 19)]
        public string PersonPhone
        {
            get
            {
                return PersonPhoneField;
            }
            set
            {
                PersonPhoneField = value;
            }
        }
    }
}
