using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApplication
{
    class Program
    {
        static BL.IBL bl = BL.FactoryBL.GetBL();
        static int[] studentId = new int[] { 1, 2, 3, 4 };
        static int[] courseId = new int[] { 11, 22, 33, 44 };
        static int[] year = new int[] { 5774, 5775, 5776 };


        static void addTest()
        {
            foreach (var item in studentId)
            {
                bl.AddStudent(
                    new Student
                    {
                        StudentId = item,
                        StudentName = "user "+item,
                        StudentCampus = item%2==0 ? Campus.Lev : Campus.Tal,
                        StudentGender = item%2==0 ? Gender.male : Gender.female                       
                    });
            }

            foreach (var item in courseId)
            {
                bl.AddCourse(
                    new Course
                    {
                        CourseId = item,
                        CourseName = "course " + item,
                    });
            }

            
            bl.AddCourseToStudent(studentId[0], courseId[0], 5774, Semester.a);
            bl.AddCourseToStudent(studentId[0], courseId[2], 5774, Semester.a);
            bl.AddCourseToStudent(studentId[1], courseId[2], 5774, Semester.b);

        }

        private static void UpdateStudentTest()
        {
            Console.WriteLine("all Students:");
            foreach (var item in bl.GetAllStudents())
            {
                Console.WriteLine(item);
            }

            Student source = bl.GetStudent(studentId[0]);

            Student toUpdate = new Student
            {
                StudentId = studentId[0],
                StudentName = "student 1",
                IsMarried = !source.IsMarried
            };

            bl.UpdateStudent(toUpdate);

            bl.RemoveStudent(studentId[2]);

            Console.WriteLine("-----------------");
            Console.WriteLine("all Students:");
            foreach (var item in bl.GetAllStudents())
            {
                Console.WriteLine(item);
            }
        }

        private static void UpdateCourseTest()
        {
            Console.WriteLine("all Courses:");
            foreach (var item in bl.GetAllCourses())
            {
                Console.WriteLine(item);
            }

          
            Course toUpdate = new Course
            {
                CourseId = courseId[2],
                CourseName = "update course name",
               
            };

            bl.UpdateCourse(toUpdate);

            bl.RemoveCourse(courseId[1]);

            Console.WriteLine("-----------------");
            Console.WriteLine("all courses:");
            foreach (var item in bl.GetAllCourses())
            {
                Console.WriteLine(item);
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("insert element :");
            addTest();
            Console.WriteLine("-----------------");
            UpdateStudentTest();
            Console.WriteLine("-----------------");
            UpdateCourseTest();
        }

       
    }
}
