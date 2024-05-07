using Client.Model;
using LearnCSharp.View;
using LearnCSharp.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LearnCSharp.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private RelayCommand _closeCommand;
        private RelayCommand _logOutCommand;
        private Page _currentPage;

        private Page List;
        private Page Lecture1;

        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                NotifyPropertyChanged(nameof(CurrentPage));
            }
        }

        public MainWindowViewModel()
        {
            List = new List();
            Lecture1 = new Lectures1();

            CurrentPage = List;
        }


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

        public RelayCommand OpenLect1
        {
            get
            {
                return new RelayCommand(() => CurrentPage = Lecture1);
            }
        }

        public RelayCommand LogOutCommand
            => _logOutCommand ?? (_logOutCommand = new RelayCommand(() =>
            {
                // Need add func for logout person // 
                GetLoginWindow();
            }));
        #endregion
    }
}
