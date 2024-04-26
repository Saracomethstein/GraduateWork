using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Connection
{
    public class ServiceConnection : IServiceConnection
    {
        public void AddNewUserInDB(string name, string password)
        {
            throw new NotImplementedException();
        }

        public bool CheckUser(string name, string password)
        {
            throw new NotImplementedException();
        }

        public bool CheckUserExists(string name)
        {
            throw new NotImplementedException();
        }
    }
}
