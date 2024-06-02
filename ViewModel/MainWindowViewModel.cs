using Client.Model;
using LearnCSharp.View;
using LearnCSharp.View.Pages;
using System.Windows;
using System.Windows.Controls;

namespace LearnCSharp.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private RelayCommand _closeCommand;
        private RelayCommand _logOutCommand;
        private Page _currentPage;

        #region Pages
        private Page Lecture1;
        private Page Lecture2;
        private Page Lecture3;

        private Page Prac1;
        private Page Prac2;
        private Page Prac3;

        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                NotifyPropertyChanged(nameof(CurrentPage));
            }
        }
        #endregion

        public MainWindowViewModel()
        {
            Lecture1 = new Lectures1();
            Lecture2 = new Lecture2();
            Lecture3 = new Lecture3();
            Prac1 = new Prac1();
            Prac2 = new Prac2();
            Prac3 = new Prac3();
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

        public RelayCommand LogOutCommand
            => _logOutCommand ?? (_logOutCommand = new RelayCommand(() =>
            {
                // Need add func for logout person // 
                GetLoginWindow();
            }));
        #endregion

        #region PageCommands
        public RelayCommand OpenLect1
        {
            get
            {
                return new RelayCommand(() => CurrentPage = Lecture1);
            }
        }

        public RelayCommand OpenLect2
        {
            get
            {
                return new RelayCommand(() => CurrentPage = Lecture2);
            }
        }

        public RelayCommand OpenLect3
        {
            get
            {
                return new RelayCommand(() => CurrentPage = Lecture3);
            }
        }

        public RelayCommand OpenPrac1
        {
            get
            {
                return new RelayCommand(() => CurrentPage = Prac1);
            }
        }

        public RelayCommand OpenPrac2
        {
            get
            {
                return new RelayCommand(() => CurrentPage = Prac2);
            }
        }

        public RelayCommand OpenPeac3
        {
            get
            {
                return new RelayCommand(() => CurrentPage = Prac3);
            }
        }
        #endregion
    }
}
