using SchoolSystemWebApi.Objects;

public interface IStudentService
{
    Task<Student> GetStudentByIdAsync(int id);
    Task UpdateStudentAsync(Student student);

    Task<List<Student>> GetAllStudents();
}

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repository;

    public StudentService(IStudentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Student> GetStudentByIdAsync(int id)
    {
        return await _repository.GetStudentByIdAsync(id);
    }

    public async Task UpdateStudentAsync(Student student)
    {
        _repository.Update(student);
        await _repository.SaveChangesAsync();
    }

    public async Task<List<Student>> GetAllStudents()
    {
        var students = await _repository.GetAllStudents();
        return students; // Return the list or an empty list if null
    }
}