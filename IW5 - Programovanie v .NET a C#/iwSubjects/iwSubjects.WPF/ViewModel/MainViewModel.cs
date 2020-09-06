using System.Windows.Input;
using iwSubjects.WPF.Commands;
using iwSubjects.BL;
using iwSubjects.BL.Messages;
using iwSubjects.WPF.ViewModel;

namespace iwSubjects.WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;

        public ICommand CreateSubjectCommand { get; }

        public MainViewModel(IMessenger messenger)
        {
            _messenger = messenger;

            CreateSubjectCommand = new RelayCommand(() => _messenger.Send(new NewSubjectMessage()));
        }
    }
}