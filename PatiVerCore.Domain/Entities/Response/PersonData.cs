using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatiVerCore.Domain.Entities.Response
{
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "PersonData", Namespace = "http://khfoms.ru/bdz")]
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

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PersonId
        {
            get
            {
                return this.PersonIdField;
            }
            set
            {
                this.PersonIdField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 1)]
        public string PersonENP
        {
            get
            {
                return this.PersonENPField;
            }
            set
            {
                this.PersonENPField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 2)]
        public string PersonSurname
        {
            get
            {
                return this.PersonSurnameField;
            }
            set
            {
                this.PersonSurnameField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 3)]
        public string PersonFirstname
        {
            get
            {
                return this.PersonFirstnameField;
            }
            set
            {
                this.PersonFirstnameField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 4)]
        public string PersonSecname
        {
            get
            {
                return this.PersonSecnameField;
            }
            set
            {
                this.PersonSecnameField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 5)]
        public string PersonBirthday
        {
            get
            {
                return this.PersonBirthdayField;
            }
            set
            {
                this.PersonBirthdayField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 6)]
        public string PersonSex
        {
            get
            {
                return this.PersonSexField;
            }
            set
            {
                this.PersonSexField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 7)]
        public string PersonBirthplace
        {
            get
            {
                return this.PersonBirthplaceField;
            }
            set
            {
                this.PersonBirthplaceField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 8)]
        public string PersonSNILS
        {
            get
            {
                return this.PersonSNILSField;
            }
            set
            {
                this.PersonSNILSField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 9)]
        public PersonAddress personAddress
        {
            get
            {
                return this.personAddressField;
            }
            set
            {
                this.personAddressField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 10)]
        public string PersonCitizenship
        {
            get
            {
                return this.PersonCitizenshipField;
            }
            set
            {
                this.PersonCitizenshipField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 11)]
        public string DocumentType
        {
            get
            {
                return this.DocumentTypeField;
            }
            set
            {
                this.DocumentTypeField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 12)]
        public string DocumentSer
        {
            get
            {
                return this.DocumentSerField;
            }
            set
            {
                this.DocumentSerField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 13)]
        public string DocumentNum
        {
            get
            {
                return this.DocumentNumField;
            }
            set
            {
                this.DocumentNumField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 14)]
        public string DocumentDate
        {
            get
            {
                return this.DocumentDateField;
            }
            set
            {
                this.DocumentDateField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 15)]
        public string DocumentOrg
        {
            get
            {
                return this.DocumentOrgField;
            }
            set
            {
                this.DocumentOrgField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 16)]
        public string PersonSocStatus
        {
            get
            {
                return this.PersonSocStatusField;
            }
            set
            {
                this.PersonSocStatusField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 17)]
        public string PersonCategory
        {
            get
            {
                return this.PersonCategoryField;
            }
            set
            {
                this.PersonCategoryField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 18)]
        public string PersonDeathDate
        {
            get
            {
                return this.PersonDeathDateField;
            }
            set
            {
                this.PersonDeathDateField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 19)]
        public string PersonPhone
        {
            get
            {
                return this.PersonPhoneField;
            }
            set
            {
                this.PersonPhoneField = value;
            }
        }
    }
}
