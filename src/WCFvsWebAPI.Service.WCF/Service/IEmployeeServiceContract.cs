using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCFvsWebAPI.Service.WCF.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmployeeServiceContract" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeServiceContract
    {
        [OperationContract]
        EmployeeDataContract Add(EmployeeDataContract employeeDataContract);
        [OperationContract]
        EmployeeDataContract Update(EmployeeDataContract employeeDataContract);
        [OperationContract]
        EmployeeDataContract GetById(string id);
        [OperationContract]
        IEnumerable<EmployeeDataContract> GetAll();
    }

    [DataContract]
    public class EmployeeDataContract
    {
        [DataMember]
        public int EmployeeId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string Gender { get; set; }
    }
}
