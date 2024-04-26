using Client.Model;
using LearnCSharp.Model;
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
                    break;
                case true:
                    MessageBox.Show("This user exists! Try another name.");
                    break;
                default:
                    MessageBox.Show("Error!");
                    break;
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
