using System;
using System.Windows.Forms;
using System.Windows.Input;
using iwSubjects.BL;
using iwSubjects.BL.Messages;
using iwSubjects.BL.Models;
using iwSubjects.BL.Repositories;

namespace iwSubjects.WPF.ViewModel
{
    internal class DeleteStudent : ICommand
    {
        private StudentRepository _studentRepository;
        private StudentDetailViewModel _studentDetailViewModel;
        private Messenger _messenger;

        public DeleteStudent(StudentRepository studentRepository, StudentDetailViewModel studentDetailViewModel, Messenger messenger)
        {
            this._studentRepository = studentRepository;
            this._studentDetailViewModel = studentDetailViewModel;
            this._messenger = messenger;
        }

        public bool CanExecute(object parameter)
        {
            var detail = parameter as StudentDetailModel;

            if (detail != null)
            {
                return true;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            var detail = parameter as StudentDetailModel;

            if (detail == null)
            {
                return;
            }

            if (detail.Id != Guid.Empty)
            {
                _studentRepository.Remove(detail.Id);
            }
            else
            {
                return;
            }

            _messenger.Send(new UpdateStudentMessage(detail));
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}