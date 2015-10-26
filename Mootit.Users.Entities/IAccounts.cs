using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Mootit.Users.Entities
{
    [ServiceContract]
    public interface IAccounts : IDisposable
    {
        [OperationContract]
        void Sync();
        [OperationContract]
        Customer GetCustomer(long id);
        [OperationContract]
        Customer GetCustomerByPhone(int phoneNumer);
        [OperationContract]
        Customer InsertCustomer(Customer customer);
    }
}
