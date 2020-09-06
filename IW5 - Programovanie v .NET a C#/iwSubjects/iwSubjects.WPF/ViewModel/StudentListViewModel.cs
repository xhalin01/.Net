using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using iwSubjects.BL;
using iwSubjects.BL.Messages;
using iwSubjects.BL.Models;
using iwSubjects.BL.Repositories;
using iwSubjects.WPF.Commands;
using iwSubjects.BL.Mappers;
using iwSubjects.BL.Messages.FilterGrades;

namespace iwSubjects.WPF.ViewModel
{
    public class StudentListViewModel : ViewModelBase
    {
        private StudentRepository _studentRepository;
        private Messenger _messenger;
        private ObservableCollection<StudentListModel> _students;
        private string _searchName;
        private string _searchSurame;
        private string _searchLogin;

        public String SearchName
        {
            get { return _searchName; }
            set { _searchName = value; OnPropertyChanged(); }
        }

        public String SearchSurame
        {
            get { return _searchSurame; }
            set { _searchSurame = value; OnPropertyChanged(); }
        }


        public String SearchLogin
        {
            get { return _searchLogin; }
            set { _searchLogin = value; OnPropertyChanged(); }
        }

        public ObservableCollection<StudentListModel> Students
        {
            get { return _students; }
            set
            {
                if (Equals(value, _students)) return;
                _students = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectStudentCommand { get; }

        public ICommand SortByNameCommand { get; }

        public ICommand SortBySurnameCommand { get; }

        public ICommand SortByPointsCommand { get; }

        public ICommand GetAllStudentsCommand { get; }

        public ICommand ShowOnlyACommand { get; }
        public ICommand ShowOnlyBCommand { get; }
        public ICommand ShowOnlyCCommand { get; }
        public ICommand ShowOnlyDCommand { get; }
        public ICommand ShowOnlyECommand { get; }
        public ICommand ShowOnlyFCommand { get; }
        public ICommand ShowFoundCommand { get; }
        public StudentListViewModel(StudentRepository studentRepository, Messenger messenger)
        {
            _studentRepository = studentRepository;
            _messenger = messenger;

            _messenger.Register<DeleteStudentMessage>(DeleteStudentMessageReceived);
            _messenger.Register<UpdateStudentMessage>((p) => OnLoad());
            _messenger.Register<SortByNameMessage>(SortByNameMessageRecieved);
            _messenger.Register<SortBySurnameMessage>(SortBySurnameMessageRecieved);
            _messenger.Register<SortByPointsMessage>(SortByPointsMessageRecieved);

            _messenger.Register<ShowOnlyAMessage>(ShowOnlyAMessageRecieved);
            _messenger.Register<ShowOnlyBMessage>(ShowOnlyBMessageRecieved);
            _messenger.Register<ShowOnlyCMessage>(ShowOnlyCMessageRecieved);
            _messenger.Register<ShowOnlyDMessage>(ShowOnlyDMessageRecieved);
            _messenger.Register<ShowOnlyEMessage>(ShowOnlyEMessageRecieved);
            _messenger.Register<ShowOnlyFMessage>(ShowOnlyFMessageRecieved);
            _messenger.Register<ShowFoundMessage>(ShowFoundMessageRecieved);
            _messenger.Register<GetAllStudentsMessage>(GetAllStudentsMessageRecieved);

            SelectStudentCommand = new RelayCommand(StudentSelectionChanged);
            SortByNameCommand = new RelayCommand(() => _messenger.Send(new SortByNameMessage()));
            SortBySurnameCommand = new RelayCommand(() => messenger.Send(new SortBySurnameMessage()));
            SortByPointsCommand = new RelayCommand(() => messenger.Send(new SortByPointsMessage()));
            ShowOnlyACommand = new RelayCommand(() => messenger.Send(new ShowOnlyAMessage()));
            ShowOnlyBCommand = new RelayCommand(() => messenger.Send(new ShowOnlyBMessage()));
            ShowOnlyCCommand = new RelayCommand(() => messenger.Send(new ShowOnlyCMessage()));
            ShowOnlyDCommand = new RelayCommand(() => messenger.Send(new ShowOnlyDMessage()));
            ShowOnlyECommand = new RelayCommand(() => messenger.Send(new ShowOnlyEMessage()));
            ShowOnlyFCommand = new RelayCommand(() => messenger.Send(new ShowOnlyFMessage()));
            ShowFoundCommand = new RelayCommand(() => messenger.Send(new ShowFoundMessage()));
            GetAllStudentsCommand = new RelayCommand(() => messenger.Send(new GetAllStudentsMessage()));
        }

        private void ShowOnlyFMessageRecieved(ShowOnlyFMessage obj)
        {
            Students = new ObservableCollection<StudentListModel>(_studentRepository.GetAllStudents());
            CalculateTotalPoints();
            Students = new ObservableCollection<StudentListModel>(new ObservableCollection<StudentListModel>(from i in Students where i.totalPoints < 50 orderby i.totalPoints select i).Reverse());
        }

        private void ShowOnlyEMessageRecieved(ShowOnlyEMessage obj)
        {
            Students = new ObservableCollection<StudentListModel>(_studentRepository.GetAllStudents());
            CalculateTotalPoints();
            Students = new ObservableCollection<StudentListModel>(new ObservableCollection<StudentListModel>(from i in Students where i.totalPoints >= 50 && i.totalPoints < 60 orderby i.totalPoints select i).Reverse());
        }

        private void ShowOnlyDMessageRecieved(ShowOnlyDMessage obj)
        {
            Students = new ObservableCollection<StudentListModel>(_studentRepository.GetAllStudents());
            CalculateTotalPoints();
            Students = new ObservableCollection<StudentListModel>(new ObservableCollection<StudentListModel>(from i in Students where i.totalPoints >= 60 && i.totalPoints < 70 orderby i.totalPoints select i).Reverse());
        }

        private void ShowFoundMessageRecieved(ShowFoundMessage obj)
        {
            Students = new ObservableCollection<StudentListModel>(_studentRepository.GetAllStudents());
            if (SearchName == null) SearchName = "";
            if (SearchSurame == null) SearchSurame = "";
            if (SearchLogin == null) SearchLogin  = "";
            Students = new ObservableCollection<StudentListModel>(new ObservableCollection<StudentListModel>(from i in Students where (i.Name.Contains(SearchName) && i.Surname.Contains(SearchSurame) && i.Login.Contains(SearchLogin)) orderby i.Name select i));
        }

        private void ShowOnlyCMessageRecieved(ShowOnlyCMessage obj)
        {
            Students = new ObservableCollection<StudentListModel>(_studentRepository.GetAllStudents());
            CalculateTotalPoints();
            Students = new ObservableCollection<StudentListModel>(new ObservableCollection<StudentListModel>(from i in Students where i.totalPoints >= 70 && i.totalPoints < 80 orderby i.totalPoints select i).Reverse());
        }

        private void ShowOnlyBMessageRecieved(ShowOnlyBMessage obj)
        {
            Students = new ObservableCollection<StudentListModel>(_studentRepository.GetAllStudents());
            CalculateTotalPoints();
            Students = new ObservableCollection<StudentListModel>(new ObservableCollection<StudentListModel>(from i in Students where i.totalPoints >= 80 && i.totalPoints < 90 orderby i.totalPoints select i).Reverse());
        }

        private void ShowOnlyAMessageRecieved(ShowOnlyAMessage obj)
        {
            Students = new ObservableCollection<StudentListModel>(_studentRepository.GetAllStudents());
            CalculateTotalPoints();
            Students = new ObservableCollection<StudentListModel>(new ObservableCollection<StudentListModel>(from i in Students where i.totalPoints >= 90 orderby i.totalPoints select i).Reverse());
        }

        private void SortByPointsMessageRecieved(SortByPointsMessage obj)
        {
            //  Students = new ObservableCollection<StudentListModel>(_studentRepository.GetAllStudents());
            CalculateTotalPoints();
            Students = new ObservableCollection<StudentListModel>(new ObservableCollection<StudentListModel>(from i in Students orderby i.totalPoints select i).Reverse());
        }

        private void SortBySurnameMessageRecieved(SortBySurnameMessage obj)
        {
            Students = new ObservableCollection<StudentListModel>(from i in Students orderby i.Surname select i);
            //OnPropertyChanged();
        }

        private void SortByNameMessageRecieved(SortByNameMessage obj)
        {
            Students = new ObservableCollection<StudentListModel>(from i in Students orderby i.Name select i);
        }

        private void GetAllStudentsMessageRecieved(GetAllStudentsMessage obj)
        {
            Students = new ObservableCollection<StudentListModel>(_studentRepository.GetAllStudents());
        }

        public void OnLoad()
        {
            Students = new ObservableCollection<StudentListModel>(_studentRepository.GetAllStudents());
        }


        public void StudentSelectionChanged(object parameter)
        {
            var studentId = (StudentListModel)parameter;

            if (studentId == null)
            {
                return;
            }

            _messenger.Send(new SelectStudentMessage() { Id = studentId.Id });
        }

        private void DeleteStudentMessageReceived(DeleteStudentMessage deleteStudentMessage)
        {
            var deleteStudent = Students.FirstOrDefault(r => r.Id == deleteStudentMessage.StudentId);
            if (deleteStudent != null)
            {
                Students.Remove(deleteStudent);
            }
        }

        private void CalculateTotalPoints()
        {
            foreach (var stud in Students)
            {
                var tempStud = _studentRepository.GetStudentById(stud.Id);
                foreach (var task in tempStud.TaskList)
                {
                    tempStud.TotalPoints += task.Points;
                }
                Students.First(s => s.Id == tempStud.Id).totalPoints = tempStud.TotalPoints;
            }
        }
    }

}