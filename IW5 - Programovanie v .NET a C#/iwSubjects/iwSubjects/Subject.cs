using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using iwSubjects.Base.Implementation;

namespace iwSubjects
{
    public class Subject : EntityBase
    {
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Student> StudentsList { get; set; } = new List<Student>();
    }
}