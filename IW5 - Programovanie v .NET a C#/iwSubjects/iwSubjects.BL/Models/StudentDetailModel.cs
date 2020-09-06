using System;
using System.Collections.Generic;

namespace iwSubjects.BL.Models
{
    public class StudentDetailModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string PhotoLink { get; set; }
        public double TotalPoints { get; set; }
        public virtual ICollection<TaskEvaluationListModel> TaskList { get; set; } = new List<TaskEvaluationListModel>();
    }
}