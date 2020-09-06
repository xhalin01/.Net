using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using iwSubjects.BL;
using iwSubjects.BL.Mappers;
using iwSubjects.BL.Messages;
using iwSubjects.BL.Models;
using iwSubjects.BL.Repositories;
using iwSubjects.WPF.Commands;

namespace iwSubjects.WPF.ViewModel
{
    public class TaskEvaluationListViewModel : ViewModelBase
    {
        private TaskEvaluationRepository _taskRepository;
        private StudentRepository _studentRepository;
        private Messenger _messenger;
        private ICollection<TaskEvaluationListModel> _detail;

        public ICommand SelectTaskEvaluationCommand { get; } 

        public TaskEvaluationListViewModel(TaskEvaluationRepository taskRepository, Messenger messenger,StudentRepository studentRepository)
        {
            _taskRepository = taskRepository;
            _messenger = messenger;
            _studentRepository = studentRepository;

           

            _messenger.Register<DeleteTaskMessage>(DeleteTaskMessageReceived);
            _messenger.Register<UpdateTaskMessage>(p => OnLoad());
            _messenger.Register<SelectStudentMessage>(SelectTaskMessageRecieved);
            SelectTaskEvaluationCommand = new RelayCommand(TaskSelectChanged);
        }

        

        private void SelectTaskMessageRecieved(SelectStudentMessage obj)
        {
            Tasks = _studentRepository.GetStudentById(obj.Id).TaskList;
        }

        public ICollection<TaskEvaluationListModel> Tasks
        {
            get { return _detail; }
            set
            {
                if (Equals(value, _detail)) return;
                _detail = value;
                OnPropertyChanged();
            }
        }

        private void TaskSelectChanged(Object obj)
        {
            var taskId = (TaskEvaluationListModel)obj;
            if (taskId == null)
                return;
            _messenger.Send(new SelectTaskMessage { Id = taskId.Id });
        }

        private void OnLoad()
        {
            //Tasks = new ObservableCollection<TaskEvaluationListModel>(_taskRepository.GetAll());
        }

        private void DeleteTaskMessageReceived(DeleteTaskMessage obj)
        {
            var task = Tasks.FirstOrDefault(r => r.Id == obj.TaskId);
            if (task != null)
                Tasks.Remove(task);
        }
    }
}
