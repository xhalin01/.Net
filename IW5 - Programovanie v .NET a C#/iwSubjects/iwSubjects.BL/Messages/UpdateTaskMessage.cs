using iwSubjects.BL.Models;

namespace iwSubjects.BL.Messages
{
    public class UpdateTaskMessage
    {
        public TaskEvaluationDetailModel Model { get; set; }
        public UpdateTaskMessage(TaskEvaluationDetailModel model)
        {
            Model = model;
        }
    }
}