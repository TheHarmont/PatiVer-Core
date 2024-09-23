using CoreWCF;
using PatiVerCore.Domain.Entities.Response;

namespace PatiVerCore.WebApi.WCFService
{
    [ServiceContract]
    public interface IWcfService
    {
        [OperationContract]
        public PersonResponse GetPersonInfo_FIO(string moId, string surname, string firstname, string patronymic, string birthday, string username, string password, bool isIPRAfirst, int MIS);

        [OperationContract]
        public PersonResponse GetPersonInfo_SNILS(string moId, string snils, string username, string password, bool isIPRAfirst, int MIS);

        [OperationContract]
        public PersonResponse GetPersonInfo_Polis(string moId, string polis, string username, string password, bool isIPRAfirst, int MIS);
    }
}
