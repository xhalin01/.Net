using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iwSubjects.BL.Models;
using iwSubjects.BL.Mappers;

namespace iwSubjects.BL.Mappers
{
    class SubjectMapper
    {
        public static SubjectDetailModel MapEntityToDetailModel(Subject s)
        {
            return new SubjectDetailModel
            {
                Id = s.Id,
                Name = s.Name,
                StudentsList = StudentMapper.MapEntityCollectionToListModelCollection(s.StudentsList)
            };
        }

        public static SubjectListModel MapEntityToListModel(Subject s)
        {
            return new SubjectListModel
            {
                Id = s.Id,
                Name = s.Name
            };
        }

        public static Subject MapDetailModelToEntity(SubjectDetailModel s)
        {
            return new Subject
            {
                Id = s.Id,
                Name = s.Name,
                StudentsList = StudentMapper.MapListModelCollectionToEntityCollection(s.StudentsList)
            };
        }

        public static Subject MapListModelToEntity(SubjectListModel s)
        {
            return new Subject()
            {
                Id = s.Id,
                Name = s.Name
            };
        }

        public static ICollection<SubjectListModel> MapEntityCollectionToListModelCollection(ICollection<Subject> subjects)
        {
            var subjectListModels = new Collection<SubjectListModel>();
            foreach (var subject in subjects)
            {
               subjectListModels.Add(MapEntityToListModel(subject));
            }
            return subjectListModels;
        }

        public static ICollection<Subject> MapListModelCollectionToEntityCollection(ICollection<SubjectListModel> subjectModels)
        {
            var subjects = new Collection<Subject>();
            foreach (var subject in subjectModels)
            {
                subjects.Add(MapListModelToEntity(subject));
            }
            return subjects;
        }
    }
}
