using ExamApi.Data;
using ExamApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamApi.Controllers;

[ApiController]
[Route("api/courses")]
public class CoursesController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Course>> GetAll()
    {
        return Ok(InMemoryDb.Courses);
    }

    [HttpGet("{id:int}")]
    public ActionResult<Course> GetById(int id)
    {
        var course = InMemoryDb.Courses.FirstOrDefault(c => c.Id == id);
        if (course is null)
        {
            return NotFound();
        }

        return Ok(course);
    }

    [HttpPost]
    public ActionResult<Course> Create(Course course)
    {
        course.Id = InMemoryDb.Courses.Count == 0
            ? 1
            : InMemoryDb.Courses.Max(c => c.Id) + 1;

        InMemoryDb.Courses.Add(course);
        return CreatedAtAction(nameof(GetById), new { id = course.Id }, course);
    }
}
