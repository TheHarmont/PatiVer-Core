using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatiVerCore.Domain.Entities.Response
{
    [System.Diagnostics.DebuggerStepThrough()]
    [System.CodeDom.Compiler.GeneratedCode("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContract(Name = "PolisData", Namespace = "http://khfoms.ru/bdz")]
    public partial class PolisData : object
    {

        private string PolisNumField;

        private string PolisTypeField;

        private string PolisBeginDateField;

        private string PolisEndDateField;

        private string PolisCloseDateField;

        private string PolisSMOField;

        private string PolisCloseReasonField;

        [System.Runtime.Serialization.DataMember()]
        public string PolisNum
        {
            get
            {
                return PolisNumField;
            }
            set
            {
                PolisNumField = value;
            }
        }

        [System.Runtime.Serialization.DataMember()]
        public string PolisType
        {
            get
            {
                return PolisTypeField;
            }
            set
            {
                PolisTypeField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 2)]
        public string PolisBeginDate
        {
            get
            {
                return PolisBeginDateField;
            }
            set
            {
                PolisBeginDateField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 3)]
        public string PolisEndDate
        {
            get
            {
                return PolisEndDateField;
            }
            set
            {
                PolisEndDateField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 4)]
        public string PolisCloseDate
        {
            get
            {
                return PolisCloseDateField;
            }
            set
            {
                PolisCloseDateField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 5)]
        public string PolisSMO
        {
            get
            {
                return PolisSMOField;
            }
            set
            {
                PolisSMOField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 6)]
        public string PolisCloseReason
        {
            get
            {
                return PolisCloseReasonField;
            }
            set
            {
                PolisCloseReasonField = value;
            }
        }
    }
}
