using Client.Model;
using LearnCSharp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LearnCSharp.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private RelayCommand _closeCommand;
        private RelayCommand _logOutCommand;


        #region Functions
        private void GetLoginWindow()
        {
            var login = new LoginWindow();
            var window = Application.Current.Windows[0];

            if(window != null)
            {
                login.Show();
                window.Close();
            }
        }
        #endregion

        #region Commands
        public RelayCommand CloseCommand
            => _closeCommand ?? (_closeCommand = new RelayCommand(() =>
            {
                Application.Current.Shutdown();
            }));

        public RelayCommand LogOutCommand
            => _logOutCommand ?? (_logOutCommand = new RelayCommand(() =>
            {
                // Need add func for logout person // 
                GetLoginWindow();
            }));
        #endregion
    }
}
