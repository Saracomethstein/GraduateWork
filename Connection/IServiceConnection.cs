using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Connection
{
    [ServiceContract]
    public interface IServiceConnection
    {
        [OperationContract]
        bool CheckUser(string username, string password);

        [OperationContract]
        bool CheckUserExists(string username);

        [OperationContract]
        void AddNewUserInDB(string username, string password);
    }
}
