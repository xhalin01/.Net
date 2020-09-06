using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using iwSubjects.BL;
using iwSubjects.BL.Mappers;
using iwSubjects.BL.Messages;
using iwSubjects.BL.Models;
using iwSubjects.BL.Repositories;
using iwSubjects.WPF.ViewModel;

namespace iwSubjects.WPF.Commands
{
    public class SaveTaskEvaluation : ICommand
    {
        private readonly TaskEvaluationRepository _taskEvaluationRepository;
        private readonly TaskEvaluationDetailViewModel _viewModel;
        private readonly IMessenger _messenger;
        private readonly StudentRepository _studentRepository;

        public SaveTaskEvaluation(TaskEvaluationRepository repository, TaskEvaluationDetailViewModel viewModel, IMessenger messenger,StudentRepository studentRepository)
        {
            _taskEvaluationRepository = repository;
            _viewModel = viewModel;
            _messenger = messenger;
            _studentRepository = studentRepository;
        }

        public bool CanExecute(object parameter)
        {
            var detail = parameter as TaskEvaluationDetailModel;

            if (detail != null)
            {
                return true;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            var detail = parameter as TaskEvaluationDetailModel;

            if (detail == null || (detail.Lector == ""))
            {
                return;
            }

            if (detail.Id != Guid.Empty)
            {
                _taskEvaluationRepository.Update(detail);
            }
            else
            {
                var student = _studentRepository.GetStudentById(detail.StudentFk);
                detail.Id = Guid.NewGuid();
                _studentRepository.Update(student,true,detail);
                _messenger.Send(new SelectStudentMessage{Id = student.Id});
            }

            _messenger.Send(new UpdateTaskMessage(detail));
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
