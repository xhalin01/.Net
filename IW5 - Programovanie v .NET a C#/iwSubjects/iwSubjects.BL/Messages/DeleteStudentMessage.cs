using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iwSubjects.BL.Messages
{
    public class DeleteStudentMessage
    {
        public DeleteStudentMessage(Guid studentId)
        {
            StudentId = studentId;
        }

        public Guid StudentId { get; set; }
    }
}
