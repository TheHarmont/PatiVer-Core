using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PatiVerCore.Domain.Entities.Response
{
    [Serializable]
    //[DataContract(Namespace = Constants.Namespace)]
    public class Address
    {
        [XmlElement(IsNullable = true)]
        public string Kladr;

        [XmlElement(IsNullable = true)]
        public string Region;

        [XmlElement(IsNullable = true)]
        public string SubRegion;

        [XmlElement(IsNullable = true)]
        public string City;

        [XmlElement(IsNullable = true)]
        public string Street;

        [XmlElement(IsNullable = true)]
        public string House;

        [XmlElement(IsNullable = true)]
        public string Corpus;

        [XmlElement(IsNullable = true)]
        public string Flat;

        public Address()
        {
        }


        public Address(Foms.PersonAddress data)
        {
            Kladr = data.Address;
            Region = data.Region;
            SubRegion = data.SubRegion;
            City = data.City;
            Street = data.Street;
            House = data.House;
            Corpus = data.Corpus;
            Flat = data.Flat;
        }

        static public Address FromFomsData(Foms.PersonAddress data)
        {
            return null == data ? null : new Address(data);
        }
    }
}
