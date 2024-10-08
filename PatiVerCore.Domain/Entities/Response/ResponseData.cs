using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatiVerCore.Domain.Entities.Response
{
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "ResponseData", Namespace = "http://khfoms.ru/bdz")]
    public partial class ResponseData : object
    {

        private string ResultField;

        private string MessageField;

        private PersonData personDataField;

        private AttachmentData attachmentDataField;

        private PolisData polisDataField;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Result
        {
            get
            {
                return this.ResultField;
            }
            set
            {
                this.ResultField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 1)]
        public string Message
        {
            get
            {
                return this.MessageField;
            }
            set
            {
                this.MessageField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 2)]
        public PersonData personData
        {
            get
            {
                return this.personDataField;
            }
            set
            {
                this.personDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 3)]
        public AttachmentData attachmentData
        {
            get
            {
                return this.attachmentDataField;
            }
            set
            {
                this.attachmentDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(Order = 4)]
        public PolisData polisData
        {
            get
            {
                return this.polisDataField;
            }
            set
            {
                this.polisDataField = value;
            }
        }
    }
}
