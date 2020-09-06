using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using iwSubjects.BL;
using iwSubjects.BL.Messages;
using iwSubjects.BL.Models;
using iwSubjects.BL.Repositories;
using iwSubjects.WPF.ViewModel;

namespace iwSubjects.WPF.Commands
{
    public class DeleteTaskEvaluation : ICommand
    {
        private readonly TaskEvaluationRepository _taskEvaluationRepository;
        private readonly TaskEvaluationDetailViewModel _viewModel;
        private readonly IMessenger _messenger;

        public DeleteTaskEvaluation(TaskEvaluationRepository repository, TaskEvaluationDetailViewModel viewModel, IMessenger messenger)
        {
            _taskEvaluationRepository = repository;
            _viewModel = viewModel;
            _messenger = messenger;
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

            if (detail == null)
            {
                return;
            }

            if (detail.Id != Guid.Empty)
            {
                _taskEvaluationRepository.Remove(detail.Id);
            }
            else
            {
                return;
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
