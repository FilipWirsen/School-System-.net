using System.ComponentModel.DataAnnotations;

namespace SchoolSystemWebApi.Objects;

public record Student
{
    public int StudentId { get; set; }
    
    [Required]
    [StringLength(25)]
    public string FirstName { get; set; }
    
    [Required]
    [StringLength(25)]
    public string LastName { get; set; }
    
    [Required]
    public DateTime DateOfBirth { get; set; }
    
    [Required]
    [StringLength(25)]
    public string Email { get; set; }
    
    [Required]
    [StringLength(25)]
    public string PhoneNumber { get; set; }
    
}


