using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iwSubjects.BL.Messages
{
    public class DeletedSubjectMessage
    {
        public DeletedSubjectMessage(Guid subjectId)
        {
            SubjectId = subjectId;
        }

        public Guid SubjectId { get; set; }
    }
}
