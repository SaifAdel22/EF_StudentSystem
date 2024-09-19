using Microsoft.EntityFrameworkCore;
using StudentSystem.Data;




namespace StudentSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {

                bool cont = true;
                while (cont)
                {



                    Console.WriteLine("Select a task to execute (1-5):");
                    Console.WriteLine("1: List all students and their homework submissions");
                    Console.WriteLine("2: List all resources by course");
                    Console.WriteLine("3: List courses with more than 5 resources");
                    Console.WriteLine("4: List courses active on a given date");
                    Console.WriteLine("5: For each student, calculate course enrollment details");
                    Console.WriteLine("6: Task 6");
                    Console.WriteLine("7: Task 7");
                    Console.WriteLine("0: Exit");



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

                            case 6:

                                ////Task 6
                                var resourse = context.Resources
                                .Select(x => new
                                {
                                    CourseName = x.Course.Name,
                                    ResourseName = x.Name,
                                    LicenseNames = x.Licenses.Select(l => l.Name).ToList(), // Get a list of license names
                                    LicenseCount = x.Licenses.Count
                                }).ToList();

                                foreach (var item in resourse)
                                {
                                    // Use string.Join to convert the list of license names into a comma-separated string
                                    Console.WriteLine($"Course: {item.CourseName}, Resource: {item.ResourseName}, Licenses: {string.Join(", ", item.LicenseNames)}, License Count: {item.LicenseCount}");
                                }
                                break;


                            case 7:
                                ////TAsk 7
                                var studentDetails = context.Students
                                            .Select(student => new
                                            {
                                                StudentName = student.Name,
                                                CourseCount = student.StudentCourses.Count,
                                                ResourceCount = student.StudentCourses
                                                    .Select(sc => sc.Course)
                                                    .SelectMany(course => course.Resources)
                                                    .Distinct()
                                                    .Count(),
                                                LicenseCount = student.StudentCourses
                                                    .Select(sc => sc.Course)
                                                    .SelectMany(course => course.Resources)
                                                    .SelectMany(resource => resource.Licenses)
                                                    .Count()
                                            })
                                            .OrderByDescending(s => s.CourseCount)
                                            .ThenByDescending(s => s.ResourceCount)
                                            .ThenBy(s => s.StudentName)
                                            .ToList();
                                foreach (var detail in studentDetails)
                                {
                                    Console.WriteLine($"Student: {detail.StudentName}, Courses: {detail.CourseCount}, Resources: {detail.ResourceCount}, Licenses: {detail.LicenseCount}");
                                }

                                break;

                            case 0:
                                cont = false;
                                break;

                            default:
                                Console.WriteLine("Invalid option, please try again.");
                                break;

                        }
                    }

                    ////Task 6

                    //                var coursesWithResourcesAndLicenses = context.Courses
                    //                       .Select(x=>new
                    //                    {
                    //                       CourseName = x.Name,
                    //                       Resourses = x.Resources.Select(s=> new
                    //                       {
                    //                           ResourseName = s.Name,
                    //                           License =s.Licenses.Select(l=>l.Name).ToList()
                    //                       })
                    //.OrderByDescending(r => r.License.Count)
                    //                .ThenBy(r => r.ResourseName)
                    //                .ToList()
                    //            })
                    //            .OrderByDescending(c => c.Resourses.Count)
                    //            .ThenBy(c => c.CourseName)
                    //            .ToList();

                    //                foreach (var course in coursesWithResourcesAndLicenses)
                    //                {
                    //                    Console.WriteLine($"Course: {course.CourseName}");

                    //                    if (course.Resourses.Count == 0)
                    //                    {
                    //                        Console.WriteLine("  No resources available.");
                    //                    }

                    //                    foreach (var resource in course.Resourses)
                    //                    {
                    //                        Console.WriteLine($"  Resource: {resource.ResourseName}");

                    //                        if (resource.License.Count == 0)
                    //                        {
                    //                            Console.WriteLine("    No licenses available.");
                    //                        }
                    //                        else
                    //                        {
                    //                            Console.WriteLine($"    Licenses: {string.Join(", ", resource.License)}");
                    //                        }
                    //                    }
                    //                }


                    //            var courses = context.Courses
                    //.Select(c => new
                    //{
                    //    CourseName = c.Name,
                    //    Resources = c.Resources
                    //        .OrderByDescending(r => r.Licenses.Count)
                    //        .ThenBy(r => r.Name)
                    //        .Select(r => new
                    //        {
                    //            ResourceName = r.Name,
                    //            LicenseNames = r.Licenses.Any()
                    //                ? string.Join(", ", r.Licenses.Select(l => l.Name))
                    //                : "No Licenses", // Handle resources without licenses
                    //            LicenseCount = r.Licenses.Count
                    //        })
                    //})
                    //.OrderByDescending(c => c.Resources.Count())
                    //.ThenBy(c => c.CourseName)
                    //.ToList();

                    //            foreach (var course in courses)
                    //            {
                    //                Console.WriteLine($"Course: {course.CourseName}");

                    //                foreach (var resource in course.Resources)
                    //                {
                    //                    Console.WriteLine($"  Resource: {resource.ResourceName}, Licenses: {resource.LicenseNames}, License Count: {resource.LicenseCount}");
                    //                }
                    //            }





                    // Output the result

                }

            }
        }
        public static int Duration(DateTime startDate, DateTime endDate)
        {
            return (endDate - startDate).Days; // Corrected to return days
        }

    }


}

