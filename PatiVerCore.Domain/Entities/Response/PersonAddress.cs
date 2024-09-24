using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatiVerCore.Domain.Entities.Response
{
    [System.Diagnostics.DebuggerStepThrough()]
    [System.CodeDom.Compiler.GeneratedCode("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContract(Name = "PersonAddress", Namespace = "http://khfoms.ru/bdz")]
    public partial class PersonAddress : object
    {

        private string AddressField;

        private string RegionField;

        private string SubRegionField;

        private string CityField;

        private string StreetField;

        private string HouseField;

        private string CorpusField;

        private string FlatField;

        [System.Runtime.Serialization.DataMember()]
        public string Address
        {
            get
            {
                return AddressField;
            }
            set
            {
                AddressField = value;
            }
        }

        [System.Runtime.Serialization.DataMember()]
        public string Region
        {
            get
            {
                return RegionField;
            }
            set
            {
                RegionField = value;
            }
        }

        [System.Runtime.Serialization.DataMember()]
        public string SubRegion
        {
            get
            {
                return SubRegionField;
            }
            set
            {
                SubRegionField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 3)]
        public string City
        {
            get
            {
                return CityField;
            }
            set
            {
                CityField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 4)]
        public string Street
        {
            get
            {
                return StreetField;
            }
            set
            {
                StreetField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 5)]
        public string House
        {
            get
            {
                return HouseField;
            }
            set
            {
                HouseField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 6)]
        public string Corpus
        {
            get
            {
                return CorpusField;
            }
            set
            {
                CorpusField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 7)]
        public string Flat
        {
            get
            {
                return FlatField;
            }
            set
            {
                FlatField = value;
            }
        }
    }
}
