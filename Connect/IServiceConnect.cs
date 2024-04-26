using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Connection
{
    [ServiceContract]
    public interface IServiceConnect
    {
        [OperationContract]
        bool CheckUser(string name, string password);
    }
}
