using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Employee
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Employee name is required")]
    [StringLength(100, MinimumLength = 3,
        ErrorMessage = "Name must be between 3 and 100 characters")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Phone number is required")]
    [Phone(ErrorMessage = "Invalid phone number")]
    [StringLength(15, MinimumLength = 10)]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Salary is required")]
    [Range(1000, 1000000,
        ErrorMessage = "Salary must be between 1,000 and 1,000,000")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Salary { get; set; }

    [Required(ErrorMessage = "Department is required")]
    [StringLength(50)]
    public string Department { get; set; } = string.Empty;

    [Required(ErrorMessage = "Date of joining is required")]
    public DateTime DateOfJoining { get; set; }

    [Range(18, 65, ErrorMessage = "Age must be between 18 and 65")]
    public int Age { get; set; }

    public bool IsActive { get; set; } = true;
}