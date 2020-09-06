using System.Data.Entity;

namespace iwSubjects
{
    public class IwSubjectsDbContext : DbContext
    {
        public DbSet<Student> Students {get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public DbSet<TaskEvaluation> TaskEvaluations { get; set; }

        public IwSubjectsDbContext(): base("TasksContext")
        {

        }
    }
}