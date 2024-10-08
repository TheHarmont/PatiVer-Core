using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatiVerCore.Domain.Entities.Response
{
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "PolisData", Namespace = "http://khfoms.ru/bdz")]
    public partial class PolisData : object
    {

        private string PolisNumField;

        private string PolisTypeField;

        private string PolisBeginDateField;

        private string PolisEndDateField;

        private string PolisCloseDateField;

        private string PolisSMOField;

        private string PolisCloseReasonField;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PolisNum
        {
            get
            {
                return this.PolisNumField;
            }
            set
            {
                this.PolisNumField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PolisType
        {
            get
            {
                return this.PolisTypeField;
            }
            set
            {
                this.PolisTypeField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 2)]
        public string PolisBeginDate
        {
            get
            {
                return this.PolisBeginDateField;
            }
            set
            {
                this.PolisBeginDateField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 3)]
        public string PolisEndDate
        {
            get
            {
                return this.PolisEndDateField;
            }
            set
            {
                this.PolisEndDateField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 4)]
        public string PolisCloseDate
        {
            get
            {
                return this.PolisCloseDateField;
            }
            set
            {
                this.PolisCloseDateField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 5)]
        public string PolisSMO
        {
            get
            {
                return this.PolisSMOField;
            }
            set
            {
                this.PolisSMOField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 6)]
        public string PolisCloseReason
        {
            get
            {
                return this.PolisCloseReasonField;
            }
            set
            {
                this.PolisCloseReasonField = value;
            }
        }
    }
}
