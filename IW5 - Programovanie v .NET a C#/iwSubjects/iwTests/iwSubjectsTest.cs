using System;
using System.Collections.Generic;
using iwSubjects;
using iwSubjects.BL.Models;
using iwSubjects.BL.Repositories;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iwTests
{
    [TestClass]
    public class IwSubjectsTest
    {
        [TestMethod]
        public void InitializedStudentsListNotNullTest()
        {
            var iw5 = new Subject
            {
                Name = "iw5",
                StudentsList = new List<Student>()
            };

            Assert.IsNotNull(iw5.StudentsList);
        }

        [TestMethod]
        public void InitializedStudentsListAttributesNotNullTest()
        {
            var iw5 = new Subject
            {
                Name = "iw5",
                StudentsList = new List<Student>()
            };

            for (var i = 0; i < 5; i++)
                iw5.StudentsList.Add(new Student
                {
                    Login = "xlogin0" + i,
                    Name = "Name" + i,
                    Surname = "Lector+i",
                    PhotoLink = "link" + i
                });

            foreach (var s in iw5.StudentsList)
            {
                Assert.IsNotNull(s);
                Assert.IsNotNull(s.Name);
                Assert.IsNotNull(s.Surname);
                Assert.IsNotNull(s.Login);
                Assert.IsNotNull(s.Id);
                Assert.IsNotNull(s.PhotoLink);
            }

        }


        [TestMethod]
        public void CompleteClassesDesignTest()
        {
            var iw5 = new Subject
            {
                Name = "iw5",
                StudentsList = new List<Student>()
            };

            var taskLists = new List<List<TaskEvaluation>>();
            for (var i = 0; i < 5; i++)
            {
                var taskList = new List<TaskEvaluation>();
                for (var j = 0; j < 5; j++)
                    taskList.Add(new TaskEvaluation
                    {
                        Note = "note" + j,
                        Points = j * 5,
                        Type = TaskEvaluationType.Exam
                    });
                taskLists.Add(taskList);
            }
            for (var i = 0; i < 5; i++)
                iw5.StudentsList.Add(new Student
                {
                    Login = "xlogin0" + i,
                    Name = "Name" + i,
                    Surname = "Lector+i",
                    PhotoLink = "link" + i,
                    TaskList = taskLists[i]
                });

            Assert.IsNotNull(iw5.StudentsList);

            foreach (var s in iw5.StudentsList)
            {
                Assert.IsNotNull(s);
                Assert.IsNotNull(s.Name);
                Assert.IsNotNull(s.Surname);
                Assert.IsNotNull(s.Login);
                Assert.IsNotNull(s.Id);
                Assert.IsNotNull(s.PhotoLink);
                Assert.IsNotNull(s.TaskList);

                foreach (var t in s.TaskList)
                {
                    Assert.IsNotNull(t);
                    Assert.IsNotNull(t.Id);
                    Assert.IsNotNull(t.Points);
                    Assert.IsNotNull(t.Note);
                    Assert.IsNotNull(t.Type);
                }
            }
        }

        [TestMethod]
        /*public void InsertSubjectTest()
        {
            SubjectRepository _repository = new SubjectRepository();
            SubjectDetailModel _detail = new SubjectDetailModel()
            {
                Id = Guid.NewGuid(),
                Name = "IW4",
                StudentsList = new List<StudentListModel>()
            };
            _repository.Insert(_detail);
        }*/

        public void SelectSubjectTest()
        {
            SubjectRepository _repository = new SubjectRepository();
            Assert.IsNotNull(_repository.GetAllSubjects());
            Assert.IsNotNull(1);
        }


    }
}