using System.Collections.ObjectModel;
using System.Windows.Input;
using iwSubjects.BL.Models;
using iwSubjects.BL.Repositories;
using System.Collections.Concurrent;
using System.Linq;
using iwSubjects.BL;
using iwSubjects.BL.Messages;
using iwSubjects.WPF.Commands;

namespace iwSubjects.WPF.ViewModel
{
    public class SubjectListViewModel:ViewModelBase
    {
        private SubjectRepository _subjectRepository;
        private Messenger _messenger;
        private ObservableCollection<SubjectListModel> _subjects;

        public ObservableCollection<SubjectListModel> Subjects
        {
            get { return _subjects; }
            set
            {
                if (Equals(value, _subjects)) return;
                _subjects = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectSubjectCommand { get; }

        public SubjectListViewModel(SubjectRepository subjectRepository, Messenger messenger)
        {
            _subjectRepository = subjectRepository;
            _messenger = messenger;

            _messenger.Register<DeletedSubjectMessage>(DeletedSubjectMessageReceived);
            _messenger.Register<UpdatedSubjectMessage>((p) => OnLoad());
            SelectSubjectCommand = new RelayCommand(SubjectSelectionChanged);
        }

        public void OnLoad()
        {
            Subjects = new ObservableCollection<SubjectListModel>(_subjectRepository.GetAllSubjects());
        }

        public void SubjectSelectionChanged(object parameter)
        {
            var subjectId = (SubjectListModel)parameter;

            if (subjectId == null)
            {
                return;
            }

            _messenger.Send(new SelectSubjectMessage() { Id = subjectId.Id });
        }

        private void DeletedSubjectMessageReceived(DeletedSubjectMessage message)
        {
            var deleteSubject = Subjects.FirstOrDefault(r => r.Id == message.SubjectId);
            if (deleteSubject != null)
            {
                Subjects.Remove(deleteSubject); 
            }
        }
    }



}
