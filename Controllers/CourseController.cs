using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using System.Diagnostics;


namespace WebApplication.Controllers
{
    [Route("/api/courses")]
    public class CourseController : Controller
    {
        private static List<Course> courses;
        private static List<Student> students;
        public CourseController()
        {
            if(courses == null)
            {
                courses = new List<Course>
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
                        Name = "Jan Cutman",
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
            //Pick Random people in the 2 courses
                Random rand = new Random();
                for(int i = 0; i < 3; i++)
                {      
                    int r = rand.Next(students.Count);
                    courses[0].students.Add(students[r]);
                }
                for(int i = 0; i < 3; i++)
                {
                    int r2 = rand.Next(students.Count);
                    courses[1].students.Add(students[r2]);
                }
            }
            
          }
        }
    
      [HttpGet]
      public List<Course> GetCourses() 
       {
            return courses;
       }

       //Gets a specific course 
       //If the course exists it returns HTTP code 200
      [HttpGet]
      [Route("{id:int}",Name="GetCourse")]
      public IActionResult GetCourseByID(int id) 
       {
           foreach (Course c in courses)
           {
               if(c.ID == id)
               {
                  return Ok(c);
               }
           }
           return NotFound();
       }

        //Gets a specific students list from a course
       //If the course is real and the students list isn't empty it returns HTTP code 200
      [HttpGet]
      [Route("{id:int}/students", Name="GetStudents")]
      public IActionResult GetStudents(int id) 
       {
           foreach(Course c in courses)
           {
               if(c.ID == id)
               {
                   if(c.students == null)
                   {
                       return NotFound();
                   }
                   else
                   {
                     return Ok(c.students);
                   }
               }
           }
           return NotFound();
       }

        //Creates a new course
       //Uses FromBody to get the course
       //After creating the course it gives the HTTP code 201
     [HttpPost]
      public IActionResult CreateCourse([FromBody] Course course) 
       {
          if(course == null)
          {
              return BadRequest();
          }
           courses.Add(course);
           var location = Url.Link("GetCourse", new { id = course.ID });  
           return Created(location,course);
       }

       //Adds a student to the course
       //Uses Route to get the ID of the course
       //After adding the student gives the HTTP code 201
       [HttpPost]
       [Route("{id:int}/students")]
       public IActionResult AddStudent([FromBody] Student stud, int id ) 
       {
          if(stud == null)
          {
              return BadRequest();
          }
          foreach(Course c in courses)
          {
              if(c.ID == id)
              {
                  c.students.Add(stud);
                  var location2 = Url.Link("GetStudents", new { id = c.ID });  
                  return Created(location2,stud);
              }
          }
          return NotFound();
       }

        //Updates a given course
       //After updating the course it gives the HTTP code 204
     [HttpPut]
     [Route("{id:int}")]
      public IActionResult UpdateCourse(int id, [FromBody] Course course) 
       {
           if(course == null)
           {
               return BadRequest();
           }
           int index = 0;
           foreach(Course c in courses)
           { 
               if(c.ID == id)
               {
                   courses.Remove(c);
                   courses.Insert(index,course);
                   return NoContent();
               }
               index++;
           }
            return NotFound();
       }

        //Deletes a specific course
       //After deleting the course it gives the HTTP code 204
      [HttpDelete]
      [Route("{id:int}")]
      public IActionResult DeleteCourse(int id) 
       {
           foreach (Course c in courses)
           {
               if(c.ID == id)
               {
                   courses.Remove(c);
                   return NoContent();
               }
           }
        return NotFound();
      }

}
}
