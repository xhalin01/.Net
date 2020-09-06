namespace iwSubjects.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<iwSubjects.IwSubjectsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(iwSubjects.IwSubjectsDbContext context)
        {
            var Subject1 = new Subject
            {
                Id = new Guid("75447abc-5d6f-4dab-aa06-495339c04487"),
                Name = "IW5",
                StudentsList =
                {
                    new Student
                    {
                        Id = new Guid("222d2c49-9c5a-4fcf-9bf3-d5fb2812c0a0"),
                        Name = "Michael",
                        Surname = "Halinár",
                        Login = "xhalin01",
                        PhotoLink = "https://pbs.twimg.com/profile_images/1357505418/stickman_prof_pic.png",
                        TaskList =
                        {
                            new TaskEvaluation
                            {
                                Id = new Guid("42546c7c-b6a1-4e00-8d03-0e2a625b8f0f"),
                                Type = TaskEvaluationType.Exam,
                                Lector = "Pluskal",
                                Points = 30,
                                Note = "Good job!",
                                StudentFk = new Guid("222d2c49-9c5a-4fcf-9bf3-d5fb2812c0a0")
                            
                                
                            },
                            new TaskEvaluation
                            {
                                Id = new Guid("4257e887-dc41-4760-8aa4-400f7d30e6c5"),
                                Type = TaskEvaluationType.Project,
                                Lector = "Dybal",
                                Points = 45,
                                Note = "Nice!",
                                StudentFk = new Guid("222d2c49-9c5a-4fcf-9bf3-d5fb2812c0a0")
                            }
                        }
                    },
                    new Student
                    {
                        Id = new Guid("e48076be-8eaf-4a7c-a0ca-c5f021f30968"),
                        Name = "Matej",
                        Surname = "Deveèka",
                        Login = "xdevec00",
                        PhotoLink = "https://pbs.twimg.com/profile_images/1357505418/stickman_prof_pic.png",
                        TaskList =
                        {
                            new TaskEvaluation
                            {
                                Id = new Guid("137976b0-207a-4e4b-9d0e-f2ad16d30af9"),
                                Type = TaskEvaluationType.Exam,
                                Lector = "Dybal",
                                Points = 40,
                                Note = "Nice",
                                StudentFk = new Guid("e48076be-8eaf-4a7c-a0ca-c5f021f30968")

                            },
                            new TaskEvaluation
                            {
                                Id = new Guid("bf929c6b-d2cd-4309-af61-ae6237c5aa8b"),
                                Type = TaskEvaluationType.Project,
                                Lector = "Pluskal",
                                Points = 45,
                                Note = "",
                                StudentFk = new Guid("e48076be-8eaf-4a7c-a0ca-c5f021f30968")
                            }
                        }
                    },
                    new Student
                    {
                        Id = new Guid("993f5d6a-545b-483d-84b9-ae6c987b676c"),
                        Name = "Martin",
                        Surname = "Malárik",
                        Login = "xmalar02",
                        PhotoLink = "https://pbs.twimg.com/profile_images/1724449330/stick_man_by_minimoko94-d2zvfn8.png",
                        TaskList =
                        {
                            new TaskEvaluation
                            {
                                Id = new Guid("c22338ec-08f6-474b-995a-b499ff36708a"),
                                Type = TaskEvaluationType.Exam,
                                Lector = "Dybal",
                                Points = 90,
                                Note = "",
                                StudentFk = new Guid("993f5d6a-545b-483d-84b9-ae6c987b676c")
                            }
                        }
                    },
                    new Student
                    {
                        Id = new Guid("93e8d9ce-347f-4c92-a20d-cc91e7f0b872"),
                        Name = "Alex",
                        Surname = "Zebra",
                        Login = "xsimat00",
                        PhotoLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/94/Stick_Figure.svg/170px-Stick_Figure.svg.png",
                        TaskList =
                        {
                            new TaskEvaluation
                            {
                                Id = new Guid("ba2ca623-9890-4061-aa4c-7467cda65870"),
                                Type = TaskEvaluationType.Exam,
                                Lector = "Dybal",
                                Points = 40,
                                Note = "This guy is lit!",
                                StudentFk = new Guid("93e8d9ce-347f-4c92-a20d-cc91e7f0b872")
                            },
                            new TaskEvaluation
                            {
                                Id = new Guid("dbbf77de-50e7-47ab-91ac-2d3d4d9671de"),
                                Type = TaskEvaluationType.Project,
                                Lector = "Pluskal",
                                Points = 55,
                                Note = "Good Job!",
                                StudentFk = new Guid("93e8d9ce-347f-4c92-a20d-cc91e7f0b872")
                            }
                        }
                    }
                }
            };

            context.Subjects.AddOrUpdate(i => i.Id, Subject1);
            context.SaveChanges();
        }
    }
}
