using System;
using System.ComponentModel.DataAnnotations;
using iwSubjects.Base.Implementation;

namespace iwSubjects
{
    public class TaskEvaluation : EntityBase
    {
        [Required]
        public TaskEvaluationType Type { get; set; }
        [Required]
        public string Lector { get; set; }
        [Required]
        public double Points { get; set; }
        public string Note { get; set; }
        [Required]  
        public Guid StudentFk { get; set; }
    }
}