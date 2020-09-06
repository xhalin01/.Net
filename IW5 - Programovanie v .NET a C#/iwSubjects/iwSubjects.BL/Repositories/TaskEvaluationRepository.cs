using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iwSubjects.BL.Mappers;
using iwSubjects.BL.Models;

namespace iwSubjects.BL.Repositories
{
    public class TaskEvaluationRepository
    {
        public List<TaskEvaluationListModel> GetAll()
        {
            using (var iwSubjectsDbContext = new IwSubjectsDbContext())
            {
                return iwSubjectsDbContext.TaskEvaluations.Select(TaskMapper.MapEntityToListModel).ToList();
            }
        }

        public TaskEvaluationDetailModel FindById(Guid id)
        {
            using (var iwSubjectsDbContext = new IwSubjectsDbContext())
            {
                var task = iwSubjectsDbContext.TaskEvaluations.FirstOrDefault(s => s.Id == id);
                return TaskMapper.MapEntityToDetailModel(task);
            }
        }

        public TaskEvaluationDetailModel Insert(TaskEvaluationDetailModel task)
        {
            using (var iwSubjectsDbContext = new IwSubjectsDbContext())
            {
                var taskDetail = TaskMapper.MapDetailModelToEntity(task);
                taskDetail.Id = Guid.NewGuid();

                iwSubjectsDbContext.TaskEvaluations.Add(taskDetail);
                iwSubjectsDbContext.SaveChanges();
                return TaskMapper.MapEntityToDetailModel(taskDetail);
            }
        }

        public void Update(TaskEvaluationDetailModel taskDetail)
        {
            using (var iwSubjectsDbContext = new IwSubjectsDbContext())
            {
                Console.Out.WriteLine("tu");

                var task = iwSubjectsDbContext.TaskEvaluations.First(s => taskDetail.Id == s.Id);

                task.Lector = taskDetail.Lector;
                task.Id = taskDetail.Id;
                task.Note = taskDetail.Note;
                task.Type = taskDetail.Type;
                task.Points = taskDetail.Points;

                iwSubjectsDbContext.SaveChanges();
            }
        }

        public void Remove(Guid id)
        {
            using (var iwSubjectsDbContext = new IwSubjectsDbContext())
            {
                var task = new TaskEvaluation() { Id = id };
                iwSubjectsDbContext.TaskEvaluations.Attach(task);
                iwSubjectsDbContext.TaskEvaluations.Remove(task);
                iwSubjectsDbContext.SaveChanges();
            }
        }

    }
}
