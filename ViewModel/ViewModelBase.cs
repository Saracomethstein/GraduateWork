using Connection;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ServiceModel;

namespace LearnCSharp.ViewModel
{
    internal class ViewModelBase : INotifyPropertyChanged
    {
        public static IServiceConnection Service;

        public ViewModelBase()
        {
            var serviceAddress = "localhost:8301";
            var serviceName = "MyService";

            Uri tcpUri = new Uri($"net.tcp://{serviceAddress}/{serviceName}");
            EndpointAddress address = new EndpointAddress(tcpUri);
            NetTcpBinding clientBinding = new NetTcpBinding();
            ChannelFactory<IServiceConnection> factory = new ChannelFactory<IServiceConnection>(clientBinding, address);
            Service = factory.CreateChannel();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            NotifyPropertyChanged(propertyName);
            return true;
        }

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
