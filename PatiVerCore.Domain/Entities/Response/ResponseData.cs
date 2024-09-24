using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatiVerCore.Domain.Entities.Response
{
    [System.Diagnostics.DebuggerStepThrough()]
    [System.CodeDom.Compiler.GeneratedCode("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContract(Name = "ResponseData", Namespace = "http://khfoms.ru/bdz")]
    public partial class ResponseData : object
    {

        private string ResultField;

        private string MessageField;

        private PersonData personDataField;

        private AttachmentData attachmentDataField;

        private PolisData polisDataField;

        [System.Runtime.Serialization.DataMember()]
        public string Result
        {
            get
            {
                return ResultField;
            }
            set
            {
                ResultField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 1)]
        public string Message
        {
            get
            {
                return MessageField;
            }
            set
            {
                MessageField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 2)]
        public FomsService.PersonData personData
        {
            get
            {
                return personDataField;
            }
            set
            {
                personDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 3)]
        public FomsService.AttachmentData attachmentData
        {
            get
            {
                return attachmentDataField;
            }
            set
            {
                attachmentDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMember(Order = 4)]
        public FomsService.PolisData polisData
        {
            get
            {
                return polisDataField;
            }
            set
            {
                polisDataField = value;
            }
        }
    }
}
