using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iwSubjects.BL.Models;

namespace iwSubjects.BL.Mappers
{
    public class TaskMapper
    {
        public static TaskEvaluationDetailModel MapEntityToDetailModel(TaskEvaluation t)
        {
            return new TaskEvaluationDetailModel()
            {
                Id = t.Id,
                Type = t.Type,
                Lector = t.Lector,
                Points = t.Points,
                Note = t.Note,
                StudentFk = t.StudentFk
            };
        }

        public static TaskEvaluationListModel MapDetailToListModel(TaskEvaluationDetailModel t)
        {
            return new TaskEvaluationListModel()
            {
                Id = t.Id,
                Type = t.Type,
                Lector = t.Lector,
                Points = t.Points,
                Note = t.Note,
                StudentFk = t.StudentFk
            };
        }

        public static TaskEvaluationListModel MapEntityToListModel(TaskEvaluation t)
        {
            return new TaskEvaluationListModel
            {
                Id = t.Id,
                Type = t.Type,
                Lector = t.Lector,
                Points = t.Points,
                Note = t.Note,
                StudentFk = t.StudentFk
            };
        }

        public static TaskEvaluation MapDetailModelToEntity(TaskEvaluationDetailModel t)
        {
            return new TaskEvaluation
            {
                Id = t.Id,
                Type = t.Type,
                Lector = t.Lector,
                Note = t.Note,
                Points = t.Points,
                StudentFk = t.StudentFk
                
            };
        }
        public static TaskEvaluation MapListModelToEntity(TaskEvaluationListModel t)
        {
            return new TaskEvaluation
            {
                Id = t.Id,
                Type = t.Type,
                Lector = t.Lector,
                Note = t.Note,
                Points = t.Points,
                StudentFk = t.StudentFk
                
                
            };
        }


        public static ICollection<TaskEvaluationListModel> MapEntityCollectionToListModelCollection(ICollection<TaskEvaluation> tasks)
        {
            var taskListModels = new Collection<TaskEvaluationListModel>();
            foreach (var task in tasks)
            {
                taskListModels.Add(MapEntityToListModel(task));
            }
            return taskListModels;
        }

        public static ICollection<TaskEvaluation> MapListModelCollectionToEntityCollection(ICollection<TaskEvaluationListModel> taskModels)
        {
            var tasks = new Collection<TaskEvaluation>();
            foreach (var model in taskModels)
            {
                tasks.Add(MapListModelToEntity(model));
            }
            return tasks;
        }
    }
}
