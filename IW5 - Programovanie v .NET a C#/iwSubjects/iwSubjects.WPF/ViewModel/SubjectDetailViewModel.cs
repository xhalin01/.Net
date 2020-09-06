using System;
using System.Windows.Input;
using iwSubjects.BL;
using iwSubjects.BL.Messages;
using iwSubjects.BL.Models;
using iwSubjects.BL.Repositories;
using iwSubjects.WPF.Commands;

namespace iwSubjects.WPF.ViewModel
{
    public class SubjectDetailViewModel : ViewModelBase
    {
        private SubjectRepository _subjectRepository;
        private Messenger _messenger;
        private SubjectDetailModel _detail;

        public ICommand DeleteCommand { get; }

        public ICommand SaveCommand { get; }


        public SubjectDetailViewModel(SubjectRepository subjectRepository, Messenger messenger)
        {
            _subjectRepository = subjectRepository;
            _messenger = messenger;

            DeleteCommand = new RelayCommand(Delete);
            SaveCommand = new SaveSubject(subjectRepository, this, messenger);
           
            
            _messenger.Register<SelectSubjectMessage>(SelectSubject);
            _messenger.Register<NewSubjectMessage>(NewSubjectMessageReceived);
        }

        private void NewSubjectMessageReceived(NewSubjectMessage obj)
        {
            Detail = new SubjectDetailModel();
        }

        private void SelectSubject(SelectSubjectMessage obj)
        {
            Detail = _subjectRepository.GetSubjectById(obj.Id);
        }

        public SubjectDetailModel Detail
        {
            get { return _detail; }
            set
            {
                _detail = value;
                OnPropertyChanged();
            }
        }

        public void Delete()
        {
            if (IsSavedSubject())
            {
                _subjectRepository.Remove(Detail.Id);
                _messenger.Send(new DeletedSubjectMessage(Detail.Id));
            }

            Detail = null;
        }
        

        private bool IsSavedSubject()
        {
            return Detail.Id != Guid.Empty;
        }
    }
}