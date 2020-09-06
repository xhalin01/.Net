using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using iwSubjects.BL;
using iwSubjects.BL.Mappers;
using iwSubjects.BL.Messages;
using iwSubjects.BL.Models;
using iwSubjects.BL.Repositories;
using iwSubjects.WPF.Commands;

namespace iwSubjects.WPF.ViewModel
{
    public class StudentDetailViewModel : ViewModelBase
    {
        private StudentRepository _studentRepository;
        private Messenger _messenger;
        private StudentDetailModel _detail;

        public ObservableCollection<TaskEvaluationListModel> Tasks
        {
            get { return (ObservableCollection<TaskEvaluationListModel>)_detail.TaskList; }
        }
        public ICommand DeleteCommand { get; }

        public ICommand SaveCommand { get; }

        public ICommand CreateStudentCommand { get; }

        public StudentDetailViewModel(StudentRepository studentRepository, Messenger messenger)
        {
            _studentRepository = studentRepository;
            _messenger = messenger;

            DeleteCommand = new RelayCommand(Delete);
            SaveCommand = new SaveStudent(studentRepository, this, messenger);
            CreateStudentCommand = new RelayCommand(() => _messenger.Send(new NewStudentMessage()));

            _messenger.Register<SelectStudentMessage>(SelectStudent);
            _messenger.Register<NewStudentMessage>(NewStudentMessageReceived);
            _messenger.Register<DeleteTaskMessage>(DeletedTaskMessageRecieved);
            //_messenger.Register<NewTaskMessage>(NewTaskMessageRecieved);

        }

        /*private void NewTaskMessageRecieved(NewTaskMessage obj)
        {
            Detail = _studentRepository.GetStudentById(this.Detail.Id);
            _messenger.Send(new SelectStudentMessage() { Id = this.Detail.Id });
        }*/

        private void DeletedTaskMessageRecieved(DeleteTaskMessage obj)
        {
            Detail = _studentRepository.GetStudentById(this.Detail.Id);
            _messenger.Send(new SelectStudentMessage() { Id = this.Detail.Id });
        }

        public StudentDetailModel Detail
        {
            get { return _detail; }
            set
            {
                _detail = value;
                OnPropertyChanged();
            }
        }

        private void NewStudentMessageReceived(NewStudentMessage obj)
        {
            Detail = new StudentDetailModel();
        }

        private void SelectStudent(SelectStudentMessage obj)
        {
            Detail = _studentRepository.GetStudentById(obj.Id);
        }

        private bool IsSavedStudent()
        {
            if (Detail == null) return false;
            return Detail.Id != Guid.Empty;
        }

        public void Delete()
        {
            if (IsSavedStudent())
            {
                _studentRepository.Remove(Detail.Id);
                _messenger.Send(new DeleteStudentMessage(Detail.Id));
            }

            Detail = null;
        }

    }
}