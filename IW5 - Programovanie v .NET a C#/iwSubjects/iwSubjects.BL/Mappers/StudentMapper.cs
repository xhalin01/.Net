using System.Collections.Generic;
using System.Collections.ObjectModel;
using iwSubjects.BL.Models;

namespace iwSubjects.BL.Mappers
{
    class StudentMapper
    {
        public static StudentListModel MapEntityToListModel(Student s)
        {
            return new StudentListModel()
            {
                Id = s.Id,
                Login = s.Login,
                Name = s.Name,
                PhotoLink = s.PhotoLink,
                Surname = s.Surname
            };
        }

        public static StudentDetailModel MapEntityToDetailModel(Student s)
        {
            return new StudentDetailModel()
            {
                Id = s.Id,
                Login = s.Login,
                Name = s.Name,
                PhotoLink = s.PhotoLink,
                Surname = s.Surname,
                TaskList = TaskMapper.MapEntityCollectionToListModelCollection(s.TaskList)
            };
        }

        public static Student MapDetailModelToEntity(StudentDetailModel s)
        {
            return new Student()
            {
                Id = s.Id,
                Login = s.Login,
                Name = s.Name,
                PhotoLink = s.PhotoLink,
                Surname = s.Surname,
                TaskList = TaskMapper.MapListModelCollectionToEntityCollection(s.TaskList)
            };
        }

        public static Student MapListModelToEntity(StudentListModel s)
        {
            return new Student
            {
                Id=s.Id,
                Name = s.Name,
                Surname = s.Surname,
                Login = s.Login
            };
        }

        public static ICollection<StudentListModel> MapEntityCollectionToListModelCollection(ICollection<Student> studs)
        {
            var studentListModels = new Collection<StudentListModel>();
            foreach (var student in studs)
            {
                studentListModels.Add(MapEntityToListModel(student));
            }
            return studentListModels;
        }

        public static ICollection<Student> MapListModelCollectionToEntityCollection(ICollection<StudentListModel> studModels)
        {
            var students = new Collection<Student>();
            foreach (var studModel in studModels)
            {
                students.Add(MapListModelToEntity(studModel));
            }
            return students;
        }

    }
}
