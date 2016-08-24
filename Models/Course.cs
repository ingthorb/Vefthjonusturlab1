using System;

namespace WebApplication.Models
{
    public class Course
    {
        public int ID{ get; set; }
        public String Name { get; set;}
        public String TemplateID { get; set;}
        public System.Collections.Generic.List<Student> students {get; set;}
        public DateTime StartDate {get; set;}
        public DateTime EndDate {get; set;}

}

}