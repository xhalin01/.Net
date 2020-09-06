using System;

namespace iwSubjects.BL.Models
{
    public class StudentListModel 
    {
        public Guid Id { get; set; }
        public string Name { get; set;}
        public string Surname { get; set;}
        public string Login { get; set;}
        public string PhotoLink { get; set;}

        public double totalPoints;
    }
}