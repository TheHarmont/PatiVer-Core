using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatiVerCore.Domain.Entities.Response
{
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "PersonAddress", Namespace = "http://khfoms.ru/bdz")]
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

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Address
        {
            get
            {
                return this.AddressField;
            }
            set
            {
                this.AddressField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Region
        {
            get
            {
                return this.RegionField;
            }
            set
            {
                this.RegionField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SubRegion
        {
            get
            {
                return this.SubRegionField;
            }
            set
            {
                this.SubRegionField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 3)]
        public string City
        {
            get
            {
                return this.CityField;
            }
            set
            {
                this.CityField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 4)]
        public string Street
        {
            get
            {
                return this.StreetField;
            }
            set
            {
                this.StreetField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 5)]
        public string House
        {
            get
            {
                return this.HouseField;
            }
            set
            {
                this.HouseField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 6)]
        public string Corpus
        {
            get
            {
                return this.CorpusField;
            }
            set
            {
                this.CorpusField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 7)]
        public string Flat
        {
            get
            {
                return this.FlatField;
            }
            set
            {
                this.FlatField = value;
            }
        }
    }
}
