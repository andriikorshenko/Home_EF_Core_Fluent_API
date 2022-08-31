using Microsoft.EntityFrameworkCore;

using MyApplicationContext mac = new();

mac.Database.EnsureDeleted();
mac.Database.EnsureCreated();

Student andrii = new Student { FName = "Andrii", LName = "Korshenko" };
Student marry = new Student { FName = "Marry", LName = "Jonson" };
Student tom = new Student { FName = "Tom", LName = "Hardy" };
mac.Students.AddRange(tom, andrii, marry);

Course efc = new Course { Name = "Entity Framework Core" };
Course sql = new Course { Name = "MS SQL" };
mac.Courses.AddRange(sql, efc);

andrii.Enrollments.Add(new Enrollment { Course = efc, Mark = 5 });
marry.Enrollments.Add(new Enrollment { Course = efc, Mark = 3 });
tom.Enrollments.Add(new Enrollment { Course = sql, Mark = 4 });

andrii.Courses.Add(sql);
marry.Courses.Add(sql);
tom.Courses.Add(efc);

mac.SaveChanges();

var courses = mac.Courses.Include(c => c.Students).ToList();

foreach (var course in courses)
{
    Console.WriteLine($"Course : {course.Name}");

    foreach (Student student in course.Students)
    {
        Console.WriteLine($"Name : {student.FName + " " + student.LName}");
    }

    Console.WriteLine(new String("-"), 5);
}
