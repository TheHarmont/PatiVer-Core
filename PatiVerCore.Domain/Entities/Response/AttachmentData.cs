using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatiVerCore.Domain.Entities.Response
{
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "AttachmentData", Namespace = "http://khfoms.ru/bdz")]
    public partial class AttachmentData : object
    {

        private string CodeMOField;

        private string RegionField;

        private string RegionNameField;

        private string RegionTypeField;

        private string AttachTypeField;

        private string AttachBeginDateField;

        private string AttachEndDateField;

        private string AttachReasonField;

        private string DetachReasonField;

        private string DoctorSnilsField;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CodeMO
        {
            get
            {
                return this.CodeMOField;
            }
            set
            {
                this.CodeMOField = value;
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
        public string RegionName
        {
            get
            {
                return this.RegionNameField;
            }
            set
            {
                this.RegionNameField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RegionType
        {
            get
            {
                return this.RegionTypeField;
            }
            set
            {
                this.RegionTypeField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 4)]
        public string AttachType
        {
            get
            {
                return this.AttachTypeField;
            }
            set
            {
                this.AttachTypeField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 5)]
        public string AttachBeginDate
        {
            get
            {
                return this.AttachBeginDateField;
            }
            set
            {
                this.AttachBeginDateField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 6)]
        public string AttachEndDate
        {
            get
            {
                return this.AttachEndDateField;
            }
            set
            {
                this.AttachEndDateField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 7)]
        public string AttachReason
        {
            get
            {
                return this.AttachReasonField;
            }
            set
            {
                this.AttachReasonField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 8)]
        public string DetachReason
        {
            get
            {
                return this.DetachReasonField;
            }
            set
            {
                this.DetachReasonField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 9)]
        public string DoctorSnils
        {
            get
            {
                return this.DoctorSnilsField;
            }
            set
            {
                this.DoctorSnilsField = value;
            }
        }
    }
}
