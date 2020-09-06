using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iwSubjects.BL.Mappers;
using iwSubjects.BL.Models;

namespace iwSubjects.BL.Repositories
{
    public class StudentRepository
    {
        public List<StudentListModel> GetAllStudents()
        {
            using (var iwSubjectsDbContext = new IwSubjectsDbContext())
            {
                return iwSubjectsDbContext.Students.Select(StudentMapper.MapEntityToListModel).ToList();
            }
        }

        public StudentDetailModel GetStudentById(Guid id)
        {
            using (var iwSubjectsDbContext = new IwSubjectsDbContext())
            {
                var students = iwSubjectsDbContext.Students
                    .Include(s => s.TaskList)
                    .FirstOrDefault(r => r.Id == id);

                return StudentMapper.MapEntityToDetailModel(students);
            }
        }

        public List<Student> FindByName(string name)
        {
            using (var iwSubjectsDbContext = new IwSubjectsDbContext())
            {
                var student = iwSubjectsDbContext.Students.Where(s => s.Name == name).ToList();
                return student.Count == 0 ? null : student;
            }
        }

        public StudentDetailModel Insert(StudentDetailModel student)
        {
            using (var iwSubjectsDbContext = new IwSubjectsDbContext())
            {
                var studentEntity = StudentMapper.MapDetailModelToEntity(student);
                studentEntity.Id = Guid.NewGuid();

                iwSubjectsDbContext.Students.Add(studentEntity);
                iwSubjectsDbContext.SaveChanges();

                return StudentMapper.MapEntityToDetailModel(studentEntity); 
            }
        }

        public void Update(StudentDetailModel studentDetail,bool updateTasks,TaskEvaluationDetailModel task)
        {
            using (var iwSubjectsDbContext = new IwSubjectsDbContext())
            {
                var student = iwSubjectsDbContext.Students
                    .Include(s => s.TaskList)
                    .First(r => r.Id == studentDetail.Id);

                student.Name = studentDetail.Name;
                student.Surname = studentDetail.Surname; 
                student.Login = studentDetail.Name;
                student.PhotoLink = studentDetail.PhotoLink;
                if(updateTasks)
                  student.TaskList.Add(TaskMapper.MapDetailModelToEntity(task));


               


                try
                {
                    iwSubjectsDbContext.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (var failure in ex.EntityValidationErrors)
                    {
                        sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                        foreach (var error in failure.ValidationErrors)
                        {
                            sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                            sb.AppendLine();
                        }
                    }

                    throw new DbEntityValidationException(
                        "Entity Validation Failed - errors follow:\n" +
                        sb.ToString(), ex
                    ); // Add the original exception as the innerException
                }
            }
        }

    
        public void Remove(Guid id)
        {
            using (var iwSubjectsDbContext = new IwSubjectsDbContext())
            {
                var student = iwSubjectsDbContext.Students.Include(x => x.TaskList).FirstOrDefault(x => x.Id == id);
                foreach (TaskEvaluation t in student.TaskList.ToList())
                {
                    iwSubjectsDbContext.TaskEvaluations.Remove(t);
                }
                iwSubjectsDbContext.SaveChanges();
                iwSubjectsDbContext.Students.Remove(student);
                iwSubjectsDbContext.SaveChanges();
            }
        }
    }
}
