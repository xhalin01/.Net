using iwSubjects.BL;
using iwSubjects.BL.Repositories;
using iwSubjects.WPF.ViewModel;

namespace iwSubjects.WPF
{
    public class ViewModelLocator
    {
        private readonly Messenger _messenger = new Messenger();
        private readonly SubjectRepository _subjectRepository = new SubjectRepository();
        private readonly StudentRepository _studentRepository = new StudentRepository();
        private readonly TaskEvaluationRepository _taskEvaluationRepository = new TaskEvaluationRepository();

        public MainViewModel MainViewModel => CreateMainViewModel();

        public SubjectListViewModel SubjectListViewModel => CreateSubjectListViewModel();

        public SubjectDetailViewModel SubjectDetailViewModel => CreateSubjectDetailViewModel();

        public StudentListViewModel StudentListViewModel => CreateStudentListViewModel();

        public StudentDetailViewModel StudentDetailViewModel => CreateStudentDetailViewModel();

        public TaskEvaluationDetailViewModel TaskEvaluationDetailViewModel => CreateTaskEvaluationDetailViewModel();

        public TaskEvaluationListViewModel TaskEvaluationListViewModel => CreateTaskEvaluationListViewModel();


        private MainViewModel CreateMainViewModel()
        {
            return new MainViewModel(_messenger);
        }

        private SubjectDetailViewModel CreateSubjectDetailViewModel()
        {
            return new SubjectDetailViewModel (_subjectRepository, _messenger);
        }

        private SubjectListViewModel CreateSubjectListViewModel()
        {

            return new SubjectListViewModel(_subjectRepository, _messenger);
        }

        private StudentListViewModel CreateStudentListViewModel()
        {
            return new StudentListViewModel(_studentRepository, _messenger);
        }

        private StudentDetailViewModel CreateStudentDetailViewModel()
        {
            return new StudentDetailViewModel(_studentRepository, _messenger);
        }

        private TaskEvaluationDetailViewModel CreateTaskEvaluationDetailViewModel()
        {
            return new TaskEvaluationDetailViewModel(_taskEvaluationRepository, _messenger,_studentRepository);
        }

        private TaskEvaluationListViewModel CreateTaskEvaluationListViewModel()
        {
            return new TaskEvaluationListViewModel(_taskEvaluationRepository, _messenger,_studentRepository);
        }

    }
}