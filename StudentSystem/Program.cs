using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using StudentSystem.Data;
using StudentSystem.Entities;




namespace StudentSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {

                Console.WriteLine("Select a task to execute (1-5):");
                Console.WriteLine("1: List all students and their homework submissions");
                Console.WriteLine("2: List all resources by course");
                Console.WriteLine("3: List courses with more than 5 resources");
                Console.WriteLine("4: List courses active on a given date");
                Console.WriteLine("5: For each student, calculate course enrollment details");



                int taskNumber;
                if (int.TryParse(Console.ReadLine(), out taskNumber))
                {
                    switch (taskNumber)
                    {
                        case 1:
                            //Task1


                            var studentHomework = context.HomeWorks
                            .Select(hw => new
                            {
                                StudentName = hw.Student.Name, // Get student's name
                                HomeworkContent = hw.Content, // Get homework content
                                HomeworkContentType = hw.ContentType // Get homework content type
                            }).ToList(); // Execute the query and return as a list
                            foreach (var item in studentHomework)
                            {
                                Console.WriteLine($"{item.StudentName}: {item.HomeworkContent} ({item.HomeworkContentType})");
                            }
                            break;

                            case 2:
                            //Task2


                            var reourse = context.Resources.OrderBy(o => o.Course.StartDate)
                                .ThenByDescending(o => o.Course.EndDate)
                                .Select(r => new
                                {
                                    CourseName = r.Course.Name,
                                    CourseDescription = r.Course.Description,
                                    StartDate = r.Course.StartDate,
                                    EndDate = r.Course.EndDate,
                                    Id = r.Id,
                                    ResourseName = r.Name,
                                    type = r.ResourceType,
                                    url = r.URL,
                                    CourseId = r.CourseId
                                });
                            foreach (var item in reourse)
                            {
                                Console.WriteLine(item);
                            }
                            break;

                        case 3:
                            //Task3

                            var Course = context.Courses.Where(x => x.Resources.Count >= 5)
                                .Select(x => new { x.Name, ResourceCount = x.Resources.Count, x.StartDate })
                                .OrderByDescending(x => x.ResourceCount).ThenByDescending(x => x.StartDate)
                                .ToList();

                            foreach (var item in Course)
                            {
                                Console.WriteLine($"{item.Name}: {item.ResourceCount} resources");
                            }
                            break;

                        case 4:
                            //Task4

                            var GivenDate = new DateTime(2024, 8, 20);
                            var course = context.Courses.Include(x => x.StudentCourses)
                                .Where(x => x.StartDate <= GivenDate && x.EndDate >= GivenDate)
                                .Select(x => new
                                {
                                    x.Name,
                                    x.StartDate,
                                    x.EndDate,
                                    Duration = Duration(x.StartDate, x.EndDate),
                                    NumOfStudent = x.StudentCourses.Count
                                }).OrderByDescending(x => x.NumOfStudent)
                                //.ThenByDescending(x=> (x.EndDate - x.StartDate).Days)
                                .ToList();

                            foreach (var item in course)
                            {
                                Console.WriteLine($"{item.Name}: {item.NumOfStudent} students enrolled, Duration: {item.Duration} days");

                            }
                            break;

                        case 5:
                            //Task5

                            var student = context.Students
                                .Select(x => new
                                {
                                    x.Name,
                                    NumberOfCourses = x.StudentCourses.Count,
                                    ToatalPrice = x.StudentCourses.Sum(x => x.Course.Price),
                                    AvgPrice = x.StudentCourses.Average(x => x.Course.Price),

                                }).OrderByDescending(x => x.ToatalPrice).ThenByDescending(x => x.NumberOfCourses)
                                .ThenByDescending(x => x.Name)
                                .ToList();

                            foreach (var item in student)
                            {
                                Console.WriteLine(item);

                            }
                            break;

                    }
                }


            }

        }
        public static int Duration(DateTime startDate, DateTime endDate)
        {
            return (endDate - startDate).Days; // Corrected to return days
        }

    }

   
}

