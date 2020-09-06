using System;

namespace iwSubjects.BL.Models
{
    public class TaskEvaluationDetailModel
    {
        public Guid Id { get; set; }
        public TaskEvaluationType Type { get; set; } = TaskEvaluationType.Other;
        public string Lector { get; set; } = string.Empty;
        public double Points { get; set; } = 0;
        public string Note { get; set; }
        public Guid StudentFk { get; set; }
    }
}