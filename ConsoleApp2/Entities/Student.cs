public class Student
{
    public uint Id { get; set; }
    public string FName { get; set; }
    public string LName { get; set; }
    public List<Course> Courses { get; set; } = new List<Course>();
    public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
