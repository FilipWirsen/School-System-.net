

using Microsoft.EntityFrameworkCore;
using SchoolSystemWebApi.Objects;

namespace SchoolSystemWebApi;

public class SqlDbContext: DbContext
{
    public SqlDbContext(DbContextOptions<SqlDbContext> options): base(options) {}
    
    public DbSet<Student> Students { get; set; }
}