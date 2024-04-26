using Client.Model;
using LearnCSharp.Model;
using LearnCSharp.View;
using System.Windows;

namespace LearnCSharp.ViewModel
{
    internal class LoginWindowViewModel : ViewModelBase
    {
        private RelayCommand _loginCommand;
        private RelayCommand _closeCommand;
        private RelayCommand _registrCommand;

        public string Login { get; set; }
        public string Password { get; set; }

        #region Functions   
        private void CheckUserInDataBase()
        {
            var user = new UserInfo
            {
                Name = Login,
                Password = Password
            };

            switch (Service.CheckUser(user.Name, user.Password))
            {
                case true:
                    SuccessfulAuthorization();
                    break;
                default:
                    MessageBox.Show("User is not found.");
                    break;
            }
        }

        private void SuccessfulAuthorization()
        {
            var main = new MainWindow();
            var window = Application.Current.Windows[0];

            if (window != null)
            {
                main.Show();
                window.Close();
            }
        }

        private void GetRegistrationWindow()
        {
            var registr = new RegistrationWindow();
            var window = Application.Current.Windows[0];

            if (window != null)
            {
                registr.Show();
                window.Close();
            }
        }

        private void FailedAuthorization()
        {
            MessageBox.Show("failed authorization!");
        }
        #endregion

        #region Commands
        public RelayCommand LoginUsersCommand
            => _loginCommand ?? (_loginCommand = new RelayCommand(() =>
            {
                CheckUserInDataBase();
            }));

        public RelayCommand CloseCommand
            => _closeCommand ?? (_closeCommand = new RelayCommand(() =>
            {
                Application.Current.Shutdown();
            }));

        public RelayCommand RegistrationCommand
            => _registrCommand ?? (_registrCommand = new RelayCommand(() =>
            {
                GetRegistrationWindow();
            }));
        #endregion
    }
}
