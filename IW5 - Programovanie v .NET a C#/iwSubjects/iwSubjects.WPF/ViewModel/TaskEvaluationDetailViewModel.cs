using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using iwSubjects.BL;
using iwSubjects.BL.Messages;
using iwSubjects.BL.Models;
using iwSubjects.BL.Repositories;
using iwSubjects.WPF.Commands;

namespace iwSubjects.WPF.ViewModel
{
    public class TaskEvaluationDetailViewModel : ViewModelBase
    {
        private TaskEvaluationRepository _TaskEvaluationRepository;
        private Messenger _messenger;
        private TaskEvaluationDetailModel _detail;
        private StudentRepository _studentRepository;
        private Guid _selectedStudentId;

        public ICommand SaveCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand CreateTaskCommand { get; set; }

        public TaskEvaluationDetailViewModel(TaskEvaluationRepository taskEvaluationRepository, Messenger messenger,StudentRepository studentRepository)
        {
            _TaskEvaluationRepository = taskEvaluationRepository;
            _messenger = messenger;
            _studentRepository = studentRepository;
           

            DeleteCommand = new RelayCommand(Delete);
            SaveCommand = new SaveTaskEvaluation(_TaskEvaluationRepository, this, messenger,_studentRepository);
            CreateTaskCommand = new RelayCommand(() => _messenger.Send(new NewTaskMessage(_selectedStudentId)));

            _messenger.Register<SelectTaskMessage>(SelectTask);
            _messenger.Register<NewTaskMessage>(NewTaskMessageReceived);
            _messenger.Register<SelectStudentMessage>(NewStudentSelectedReceived);

        }



        private void NewStudentSelectedReceived(SelectStudentMessage obj)
        {
            Detail = null;
            _selectedStudentId = obj.Id;
        }

        public TaskEvaluationDetailModel Detail
        {
            get { return _detail; }
            set
            {
                _detail = value;
                OnPropertyChanged();
            }
        }

        private void NewTaskMessageReceived(NewTaskMessage obj)
        {
            Detail = new TaskEvaluationDetailModel();
            Detail.StudentFk = obj.studentFk;
        }

        private void SelectTask(SelectTaskMessage obj)
        {
            Detail = _TaskEvaluationRepository.FindById(obj.Id);
        }

        private bool IsSavedTask()
        {
            if (Detail == null) return false;
            return Detail.Id != Guid.Empty;
        }

        public void Delete()
        {
            if (IsSavedTask())
            {
                _TaskEvaluationRepository.Remove(Detail.Id);
                _messenger.Send(new DeleteTaskMessage(Detail.Id));
            }

            Detail = null;
        }
    }
}
