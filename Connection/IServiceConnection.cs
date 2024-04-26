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
        bool CheckUser(string name, string password);

        [OperationContract]
        bool CheckUserExists(string name);

        [OperationContract]
        void AddNewUserInDB(string name, string password);
    }
}
