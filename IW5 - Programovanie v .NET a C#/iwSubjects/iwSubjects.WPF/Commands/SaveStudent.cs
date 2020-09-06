using System;
using System.Windows.Controls.Primitives;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using iwSubjects.BL;
using iwSubjects.BL.Messages;
using iwSubjects.BL.Models;
using iwSubjects.BL.Repositories;

namespace iwSubjects.WPF.ViewModel
{
    internal class SaveStudent : ICommand
    {
        private StudentRepository _studentRepository;
        private StudentDetailViewModel _studentDetailViewModel;
        private Messenger _messenger;

        public SaveStudent(StudentRepository studentRepository, StudentDetailViewModel studentDetailViewModel, Messenger messenger)
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

            if (detail.Login.Equals(String.Empty) || detail.Name.Equals(String.Empty) || detail.Surname.Equals(String.Empty))
            {
                return;
            }

            if (detail.Id != Guid.Empty)
            {
                
                _studentRepository.Update(detail,false,null);
            }
            else
            {
                _studentDetailViewModel.Detail = _studentRepository.Insert(detail);
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