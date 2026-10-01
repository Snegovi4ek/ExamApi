using ExamApi.Models;

namespace ExamApi.Data;

public static class InMemoryDb
{
    public static List<Student> Students { get; } = new()
    {
        new Student { Id = 1, Name = "Маяков Сергей Александрович", Group = "УВП-312" }
    };

    public static List<Course> Courses { get; } = new()
    {
        new Course { Id = 1, Title = "Администрирование ОС Linux", Hours = 72 },
        new Course { Id = 2, Title = "Компьютерные сети", Hours = 36 }
    };
}
