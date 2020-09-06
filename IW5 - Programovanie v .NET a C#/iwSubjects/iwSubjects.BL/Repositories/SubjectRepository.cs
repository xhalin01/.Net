using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using iwSubjects.BL.Mappers;
using iwSubjects.BL.Models;

namespace iwSubjects.BL.Repositories
{
    public class SubjectRepository
    {
    
        public List<SubjectListModel> GetAllSubjects()
        {
            using (var iwSubjectsDbContext = new IwSubjectsDbContext())
            {
                return iwSubjectsDbContext.Subjects.
                        Select(SubjectMapper.MapEntityToListModel).
                        ToList();
            }
        }

        

        public SubjectDetailModel GetSubjectById(Guid id)
        {
            using (var iwSubjectsDbContext = new IwSubjectsDbContext())
            {
                var subjects = iwSubjectsDbContext.Subjects
                    .Include(s => s.StudentsList.Select(p => p.TaskList))
                    .FirstOrDefault(r => r.Id == id);

                return SubjectMapper.MapEntityToDetailModel(subjects);
            }
        }


        public SubjectDetailModel Insert(SubjectDetailModel subjectDetail)
        {
            using (var iwSubjectsDbContext = new IwSubjectsDbContext())
            {
                var subject= SubjectMapper.MapDetailModelToEntity(subjectDetail);
                iwSubjectsDbContext.Subjects.Add(subject);
                iwSubjectsDbContext.SaveChanges();
                return SubjectMapper.MapEntityToDetailModel(subject);
            }
        }

        public void Update(SubjectDetailModel subjectDetail)
        {
            using (var iwSubjectsDbContext = new IwSubjectsDbContext())
            {
                var subject = iwSubjectsDbContext.Subjects.First(s => s.Id == subjectDetail.Id);
                subject.Id = subjectDetail.Id;
                subject.Name = subjectDetail.Name;
                subject.StudentsList = StudentMapper.MapListModelCollectionToEntityCollection(subjectDetail.StudentsList);

                iwSubjectsDbContext.SaveChanges();
            }
        }

        public void Remove(Guid id)
        {
            using (var iwSubjectsDbContext = new IwSubjectsDbContext())
            {
                var subject = new Subject() { Id = id };
                iwSubjectsDbContext.Subjects.Attach(subject);

                iwSubjectsDbContext.Subjects.Remove(subject);
                iwSubjectsDbContext.SaveChanges();
            }
        }

    }
}