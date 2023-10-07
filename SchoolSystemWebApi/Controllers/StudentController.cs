using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore;
using SchoolSystemWebApi.Objects;
namespace SchoolSystemWebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/students")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly SqlDbContext _context;
    private readonly IStudentService _service;

    public StudentsController(SqlDbContext context, IStudentService service)
    {
        _context = context;
        _service = service;
    }


    [HttpPost("createStudent")]
    public async Task<IActionResult> CreateStudent([FromBody] Student student)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetStudent), new { id = student.StudentId }, student);
    }

    

    // READ: GET /students/{id}
    [HttpGet("getStudent/{id}")]
    public async Task<ActionResult<Student>> GetStudent(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null)
        {
            return NotFound();
        }
        return student;
    }
    
    // READ: GET /students/{id}
    [HttpGet("getAllStudents")]
    public async Task<ActionResult<List<Student>>> GetAllStudents()
    {
        var students = await _service.GetAllStudents();
            
        return students;
    }
    
    [HttpPut("updateStudent/{id}")]
    public async Task<IActionResult> UpdateStudent([FromBody] Student student)
    {
        if (student.StudentId != student.StudentId || !ModelState.IsValid)
        {
            return BadRequest();
        }

        var existingStudent = await _service.GetStudentByIdAsync(student.StudentId);
        if (existingStudent == null)
        {
            return NotFound();
        }

        await _service.UpdateStudentAsync(student);
        return NoContent();
    }

    // DELETE: DELETE /students/{id}
    [HttpDelete("deleteStudent/{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null)
        {
            return NotFound();
        }

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
