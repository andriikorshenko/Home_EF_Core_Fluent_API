public class Course
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public List<Student> Students { get; set; } = new List<Student>();
    public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
