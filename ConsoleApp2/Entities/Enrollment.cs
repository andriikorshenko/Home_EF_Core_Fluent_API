public class Enrollment
{
    public uint CourseId { get; set; }
    public Course Course { get; set; }

    public uint StudentId { get; set; }
    public Student Student { get; set; }

    public byte Mark { get; set; }
}
