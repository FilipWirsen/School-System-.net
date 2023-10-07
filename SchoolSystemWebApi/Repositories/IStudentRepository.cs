using Microsoft.EntityFrameworkCore;
using SchoolSystemWebApi;
using SchoolSystemWebApi.Objects;

public interface IStudentRepository
{
    Task<Student> GetStudentByIdAsync(int id);
    void Update(Student student);
    Task SaveChangesAsync();

    Task<List<Student>> GetAllStudents();
}

public class StudentRepository : IStudentRepository
{
    private readonly SqlDbContext _context;

    public StudentRepository(SqlDbContext context)
    {
        _context = context;
    }

    public async Task<Student> GetStudentByIdAsync(int id)
    {
        return await _context.Students.FindAsync(id);
    }
    
    public async Task<List<Student>> GetAllStudents()
    {
        return await _context.Students.ToListAsync();
    }


    public void Update(Student student)
    {
        _context.Entry(student).State = EntityState.Modified;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}