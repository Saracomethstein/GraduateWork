using Client.Model;
using LearnCSharp.Model;
using LearnCSharp.View;
using System.Data.Entity;
using System.Windows;

namespace LearnCSharp.ViewModel
{
    internal class RegistrationWindowViewModel : ViewModelBase
    {
        private RelayCommand _closeCommand;
        private RelayCommand _registrationCommand;


        public string NewUser { get; set; }
        public string NewPassword { get; set; }

        #region Functions
        private void RegistationNewUser()
        {
            var newUser = new UserInfo
            {
                Name = NewUser,
                Password = NewPassword
            };

            switch (Service.CheckUserExists(newUser.Name))
            {
                case false:
                    Service.AddNewUserInDB(newUser.Name, newUser.Password);
                    GetLoginWindow();
                    break;
                case true:
                    MessageBox.Show("This user exists! Try another name.");
                    break;
                default:
                    MessageBox.Show("Error!");
                    break;
            }
        }
        private void GetLoginWindow()
        {
            var login = new LoginWindow();
            var window = Application.Current.Windows[0];

            if (window != null)
            {
                login.Show();
                window.Close();
            }
        }

        #endregion

        #region Commands
        public RelayCommand RegintationRegistrationCommand
            => _registrationCommand ?? (_registrationCommand = new RelayCommand(() =>
            {
                RegistationNewUser();
            }));

        public RelayCommand CloseCommand
            => _closeCommand ?? (_closeCommand = new RelayCommand(() =>
            {
                Application.Current.Shutdown();
            }));
        #endregion
    }
}
