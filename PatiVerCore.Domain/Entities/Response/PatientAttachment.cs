using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PatiVerCore.Domain.Entities.Response
{
    [Serializable]
    public class PatientAttachment
    {

        [XmlElement(IsNullable = false)]
        public string CodeMO;

        [XmlElement(IsNullable = true)]
        public string Sector;

        [XmlElement(IsNullable = true)]
        public string SectorName;

        [XmlElement(IsNullable = true)]
        public string SectorType;

        [XmlElement(IsNullable = false)]
        public string Type;

        [XmlElement(IsNullable = false)]
        public DateTime? BeginDate;

        [XmlElement(IsNullable = true)]
        public DateTime? EndDate;

        [XmlElement(IsNullable = false)]
        public string Reason;

        [XmlElement(IsNullable = true)]
        public string DetachReason;

        [XmlElement(IsNullable = true)]
        public string DoctorSnils;

        public PatientAttachment()
        {
        }

        public PatientAttachment(Foms.AttachmentData data)
        {
            CodeMO = data.CodeMO;
            Sector = data.Region;
            SectorName = data.RegionName;
            SectorType = data.RegionType;
            Type = data.AttachType;
            Reason = data.AttachReason;
            DetachReason = data.DetachReason;
            DoctorSnils = data.DoctorSnils;

            DateTime date;

            if (DateTime.TryParse(data.AttachBeginDate, out date))
                BeginDate = date;
            if (DateTime.TryParse(data.AttachEndDate, out date))
                EndDate = date;
        }

        static public PatientAttachment FromFomsData(Foms.AttachmentData data)
        {
            return null == data ? null : new PatientAttachment(data);
        }
    }
}
