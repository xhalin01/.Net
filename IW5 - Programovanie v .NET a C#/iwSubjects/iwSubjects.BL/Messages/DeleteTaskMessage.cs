using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iwSubjects.BL.Messages
{
    public class DeleteTaskMessage
    {
        public DeleteTaskMessage(Guid taskId)
        {
            TaskId = taskId;
        }

        public Guid TaskId { get; set; }
    }
}
