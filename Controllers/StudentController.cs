using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students;
        public StudentController()
        {
            if(students == null)
            {

            students = new List<Student>
            {
                new Student {
                    SSN = "2412954287",
                    Name = "Jan Hinrik Hansen",
                },
                 new Student {
                    SSN = "0101934276",
                    Name = "Ingthor Arnason",
                }
            };
         }
        }
      [HttpGet]
      [Route("/api/courses/Students")]
      //[Route("/courses/{ID:int}",Name="GetCourse")]
      public List<Student> GetStudents(int id) 
       {
           Console.WriteLine("WTF");
           System.Diagnostics.Debug.WriteLine("WTF");
            return students;
       }
    }
}
