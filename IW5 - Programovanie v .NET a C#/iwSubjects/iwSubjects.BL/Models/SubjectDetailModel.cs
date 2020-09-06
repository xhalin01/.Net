using System;
using System.Collections.Generic;

namespace iwSubjects.BL.Models
{
    public class SubjectDetailModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<StudentListModel> StudentsList { get; set; } = new List<StudentListModel>();

        public double totalPoints;
    }
}