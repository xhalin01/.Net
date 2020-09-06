using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using iwSubjects.Base.Implementation;

namespace iwSubjects
{
    public class Student : EntityBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Login { get; set; }
        public string PhotoLink { get; set; }
        public virtual ICollection<TaskEvaluation> TaskList { get; set; } = new List<TaskEvaluation>();
    }
}