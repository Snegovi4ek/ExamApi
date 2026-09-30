using ExamApi.Data;
using ExamApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamApi.Controllers;

[ApiController]
[Route("api/students")]
public class StudentsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Student>> GetAll()
    {
        return Ok(InMemoryDb.Students);
    }

    [HttpGet("{id:int}")]
    public ActionResult<Student> GetById(int id)
    {
        var student = InMemoryDb.Students.FirstOrDefault(s => s.Id == id);
        if (student is null)
        {
            return NotFound();
        }

        return Ok(student);
    }

    [HttpPost]
    public ActionResult<Student> Create(Student student)
    {
        student.Id = InMemoryDb.Students.Count == 0
            ? 1
            : InMemoryDb.Students.Max(s => s.Id) + 1;

        InMemoryDb.Students.Add(student);
        return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
    }
}
