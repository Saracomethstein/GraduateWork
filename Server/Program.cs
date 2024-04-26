using Connection;
using Server.DataBase;
using System;
using System.ServiceModel;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CheckConnection();
            Console.ReadLine();
        }

        private static bool CheckConnection()
        {
            Connect.Write("Connecting to the server...");
            try
            {
                var serviceAddress = "localhost:8301";
                var serviceName = "MyService";

                var host = new ServiceHost(typeof(ServiceConnect), new Uri($"net.tcp://{serviceAddress}/{serviceName}"));
                var serverBinding = new NetTcpBinding();
                host.AddServiceEndpoint(typeof(IServiceConnect), serverBinding, "");

                host.Open();
                Connect.Write("The host is connected.");
                Connect.GetDbConnection();
            }
            catch (Exception ex)
            {
                Connect.ErrorWrite("Failed to connect to host.");
                Connect.ErrorWrite($"{ex}");
            }
            return true;
        }
    }
}
