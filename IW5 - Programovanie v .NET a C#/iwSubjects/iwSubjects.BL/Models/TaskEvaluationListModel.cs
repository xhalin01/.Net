using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iwSubjects.BL.Models
{
    public class TaskEvaluationListModel
    {
        public Guid Id { get; set; }
        public TaskEvaluationType Type { get; set; }
        public string Lector { get; set; }
        public double Points { get; set; }
        public string Note { get; set; }
        public Guid StudentFk { get; set; }
    }
}
