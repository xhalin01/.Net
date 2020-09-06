using System;
using System.Windows.Input;
using iwSubjects.BL;
using iwSubjects.BL.Messages;
using iwSubjects.BL.Models;
using iwSubjects.BL.Repositories;
using iwSubjects.WPF.ViewModel;

namespace iwSubjects.WPF.Commands
{
    public class DeleteSubject : ICommand
    {
        private readonly SubjectRepository _subjectRepository;
        private readonly SubjectDetailViewModel _viewModel;
        private readonly IMessenger _messenger;

        public DeleteSubject(SubjectRepository repository, SubjectDetailViewModel viewModel, IMessenger messenger)
        {
            _subjectRepository = repository;
            _viewModel = viewModel;
            _messenger = messenger;
        }

        public bool CanExecute(object parameter)
        {
            var detail = parameter as SubjectDetailModel;

            if (detail != null)
            {
                return true;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            var detail = parameter as SubjectDetailModel;

            if (detail == null)
            {
                return;
            }

            if (detail.Id != Guid.Empty)
            {
                _subjectRepository.Remove(detail.Id);
            }
            else
            {
                return;
            }

            _messenger.Send(new UpdatedSubjectMessage(detail));
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}