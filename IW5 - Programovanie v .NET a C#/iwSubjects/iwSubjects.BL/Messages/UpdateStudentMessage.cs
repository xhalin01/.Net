using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iwSubjects.BL.Models;

namespace iwSubjects.BL.Messages
{
    public class UpdateStudentMessage
    {
        public StudentDetailModel Model { get; set; }
        public UpdateStudentMessage(StudentDetailModel model)
        {
            Model = model;
        }
    }
}
