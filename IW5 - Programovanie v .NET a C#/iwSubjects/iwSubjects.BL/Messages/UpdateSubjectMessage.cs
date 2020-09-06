using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iwSubjects.BL.Models;

namespace iwSubjects.BL.Messages
{
    public class UpdatedSubjectMessage
    {
        public SubjectDetailModel Model { get; set; }
        public UpdatedSubjectMessage(SubjectDetailModel model)
        {
            Model = model;
        }
    }
}
