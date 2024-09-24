using PatiVerCore.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PatiVerCore.Application.DTOs
{
    [Serializable]
    public class Polis
    {
        [XmlElement(IsNullable = false)]
        public string Num;

        [XmlElement(IsNullable = false)]
        public string Type;

        [XmlElement(IsNullable = false)]
        public DateTime BeginDate;

        [XmlElement(IsNullable = true)]
        public DateTime? EndDate;

        [XmlElement(IsNullable = true)]
        public DateTime? CloseDate;

        [XmlElement(IsNullable = false)]
        public string SMO;

        [XmlElement(IsNullable = true)]
        public string CloseReason;

        public Polis()
        {
        }

        public Polis(PolisData data)
        {
            Num = data.PolisNum;
            Type = data.PolisType;
            SMO = data.PolisSMO;
            CloseReason = data.PolisCloseReason;

            DateTime date;

            if (DateTime.TryParse(data.PolisBeginDate, out date))
                BeginDate = date;
            if (DateTime.TryParse(data.PolisEndDate, out date))
                EndDate = date;
            if (DateTime.TryParse(data.PolisCloseDate, out date))
                CloseDate = date;
        }

        static public Polis FromFomsData(PolisData data)
        {
            return null == data ? null : new Polis(data);
        }
    }
}
