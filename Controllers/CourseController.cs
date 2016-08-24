using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using System.Diagnostics;


namespace WebApplication.Controllers
{
    public class CourseController : Controller
    {
        private static List<Course> courses;
        private static List<Student> students;
        public CourseController()
        {
            if(courses == null)
            {

            courses = new List<Course>
            //students = new List<Student>
            {
                new Course {
                    ID = 1,
                    Name = "Vefforritun",
                    TemplateID = "T-211-VEF",
                    students = new List<Student>(),
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(4)
                },
                 new Course {
                    ID = 2,
                    Name = "Programming for dummies",
                    TemplateID = "T-101-PFD",
                    students = new List<Student>(),
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(4)
                }

            };
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
                },
                new Student {
                    SSN = "1001994276",
                    Name = "Jon Ingvi Arnason",
                },
                new Student {
                    SSN = "0912924276",
                    Name = "Ari Freyr Skulason",
                },
                new Student {
                    SSN = "0906994276",
                    Name = "Laufey Gudmundsdottir",
                },
                new Student {
                    SSN = "0303914276",
                    Name = "Vala Grand",
                },
                new Student {
                    SSN = "0301834276",
                    Name = "Bjarni Ben",
                },
                new Student {
                    SSN = "0909154276",
                    Name = "IceHot1",
                },
                new Student {
                    SSN = "1011854276",
                    Name = "Gylfi Valgeirsosn",
                },
                new Student {
                    SSN = "2209944276",
                    Name = "Logi Fitness",
                }
            };
            //Pick Random people in the courses
                Random rand = new Random();
                for(int i = 0; i < 3; i++)
                { 
                    int r = rand.Next(students.Count);
                    courses[0].students.Add(students[r]);
                }
                for(int i = 0; i < 3; i++)
                {
                    int r2 = rand.Next(0,6);
                    courses[1].students.Add(students[r2]);
                }
            }
            
          }
        }
      [HttpGet]
      [Route("/api/courses")]
      //[Route("/courses/{ID:int}",Name="GetCourse")]
      public List<Course> GetCourses(int id) 
       {
            return courses;
       }
      [HttpGet]
      [Route("api/courses/{ID:int}",Name="GetCourse")]
      public IActionResult GetCourseByID(int id) 
       {
           foreach (Course c in courses)
           {
               if(c.ID == id)
               {
                   //Redirect not working
                  return Ok(c);
               }
           }
           //Else not found
           return NotFound();
       }

     [HttpPost]
     // ResponseType ??
      //[Route("/courses/{ID:int}",Name="GetCourse")]
      public IActionResult CreateCourse(int id,string name, string templateID, DateTime startdate, DateTime enddate) 
       {

           var course = new Course{
                    ID = id,
                    Name = name,
                    TemplateID = templateID,
                    StartDate = startdate,
                    EndDate = enddate
           
           };
           courses.Add(course);
           var location = Url.Link("GetCourse", new { id = course.ID });  
           return Created(location,course);
       }

     [HttpPut]
      //[Route("/courses/{ID:int}",Name="GetCourse")]
      public List<Course> UpdateCourse(int id) 
       {
            return courses;
       }

      [HttpDelete]
      [Route("api/courses/{ID:int}")]
      public IActionResult DeleteCourse(int id) 
       {
           foreach (Course c in courses)
           {
               if(c.ID == id)
               {
                   courses.Remove(c);
                   return new NoContentResult();
               }
           }
        return NotFound();
           
    }

}
}
