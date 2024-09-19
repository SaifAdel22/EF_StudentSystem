namespace StudentSystem.Entities
{
    public class Course
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string? Description { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual decimal Price { get; set; }
        public virtual List<StudentCourses> StudentCourses { get; set; } = new List<StudentCourses>();
        public virtual List<Resource> Resources { get; set; } = new List<Resource>();
        public virtual List<HomeWork> HomeWorks { get; set; } = new List<HomeWork>();

    }
    public class DateRange
    {
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public override string ToString()
        {
            return $"{StartDate.ToString("yyyy-MM-dd")} - {EndDate.ToString("yyyy-MM-dd")}";
        }
    }
}
