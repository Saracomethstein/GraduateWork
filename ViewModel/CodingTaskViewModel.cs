using Client.Model;
using LearnCSharp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LearnCSharp.ViewModel
{
    internal class CodingTaskViewModel : ViewModelBase
    {
        private readonly CodeTestingService _codeTestingService;
        private CodingTask _currentTask;

        public CodingTask CurrentTask
        {
            get => _currentTask;
            set
            {
                _currentTask = value;
                OnPropertyChanged();
            }
        }

        public ICommand TestCodeCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public CodingTaskViewModel()
        {
            _codeTestingService = new CodeTestingService();
            TestCodeCommand = new RelayCommand(async () => await TestCodeAsync());
        }

        private async Task TestCodeAsync()
        {
            var (isCorrect, output) = await _codeTestingService.TestCodeAsync(CurrentTask.UserCode, CurrentTask.ExpectedOutput);
            CurrentTask.IsCorrect = isCorrect;
            CurrentTask.Output = output;
            OnPropertyChanged(nameof(CurrentTask));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
