using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatiVerCore.Domain.Entities.Response
{
    [System.Diagnostics.DebuggerStepThrough()]
    [System.CodeDom.Compiler.GeneratedCode("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContract(Name = "AttachmentData", Namespace = "http://khfoms.ru/bdz")]
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

        [System.Runtime.Serialization.DataMember()]
        public string CodeMO
        {
            get
            {
                return CodeMOField;
            }
            set
            {
                CodeMOField = value;
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
        public string RegionName
        {
            get
            {
                return RegionNameField;
            }
            set
            {
                RegionNameField = value;
            }
        }

        [System.Runtime.Serialization.DataMember()]
        public string RegionType
        {
            get
            {
                return RegionTypeField;
            }
            set
            {
                RegionTypeField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 4)]
        public string AttachType
        {
            get
            {
                return AttachTypeField;
            }
            set
            {
                AttachTypeField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 5)]
        public string AttachBeginDate
        {
            get
            {
                return AttachBeginDateField;
            }
            set
            {
                AttachBeginDateField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 6)]
        public string AttachEndDate
        {
            get
            {
                return AttachEndDateField;
            }
            set
            {
                AttachEndDateField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 7)]
        public string AttachReason
        {
            get
            {
                return AttachReasonField;
            }
            set
            {
                AttachReasonField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 8)]
        public string DetachReason
        {
            get
            {
                return DetachReasonField;
            }
            set
            {
                DetachReasonField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 9)]
        public string DoctorSnils
        {
            get
            {
                return DoctorSnilsField;
            }
            set
            {
                DoctorSnilsField = value;
            }
        }
    }
}
