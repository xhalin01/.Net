using System;

namespace iwSubjects.BL.Messages
{
    public class NewTaskMessage
    {
        public Guid studentFk;

        public NewTaskMessage(Guid s)
        {
            this.studentFk = s;
        }
    }
}