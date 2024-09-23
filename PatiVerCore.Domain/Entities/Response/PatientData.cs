using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PatiVerCore.Domain.Entities.Response
{
    [Serializable]
    public class PatientData
    {
        [XmlElement(IsNullable = false)]
        public string FomsId;

        [XmlElement(IsNullable = false)]
        public string ENP;

        [XmlElement(IsNullable = false)]
        public string Surname;

        [XmlElement(IsNullable = false)]
        public string Sex;

        [XmlElement(IsNullable = false)]
        public string Name;

        [XmlElement(IsNullable = true)]
        public string Patronymic;

        [XmlElement(IsNullable = true)]
        public DateTime? BirthDate;

        [XmlElement(IsNullable = true)]
        public string Snils;

        [XmlElement(IsNullable = true)]
        public string BirthPlace;

        [XmlElement(IsNullable = true)]
        public string Citizenship;

        [XmlElement(IsNullable = true)]
        public string DocumentType;

        [XmlElement(IsNullable = true)]
        public string DocumentSeries;

        [XmlElement(IsNullable = true)]
        public string DocumentNumber;

        [XmlElement(IsNullable = true)]
        public string DocumentOrg;

        [XmlElement(IsNullable = true)]
        public DateTime? DocumentDate;

        [XmlElement(IsNullable = true)]
        public Address RegAddress;

        [XmlElement(IsNullable = true)]
        public string Phone;




        public PatientData()
        {
        }

        public PatientData(Foms.PersonData data)
        {
            FomsId = data.PersonId;
            ENP = data.PersonENP;
            Surname = data.PersonSurname;
            Name = data.PersonFirstname;
            Patronymic = data.PersonSecname;
            Sex = data.PersonSex;

            DateTime date;
            if (DateTime.TryParse(data.PersonBirthday, out date))
                BirthDate = date;
            Snils = data.PersonSNILS;

            BirthPlace = data.PersonBirthplace;
            Citizenship = data.PersonCitizenship;

            DocumentType = data.DocumentType;
            DocumentSeries = data.DocumentSer;
            DocumentNumber = data.DocumentNum;
            if (DateTime.TryParse(data.DocumentDate, out date))
                DocumentDate = date;

            RegAddress = Address.FromFomsData(data.personAddress);
            DocumentOrg = data.DocumentOrg;

            Phone = data.PersonPhone;
        }

        static public PatientData FromFomsData(Foms.PersonData data)
        {
            return null == data ? null : new PatientData(data);
        }
    }
}
