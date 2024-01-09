using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GradeView.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter student name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter student surname")]  
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Please enter student date of birth")]
        public string? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter student gender")]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Please enter student Year")]
        public string? Year { get; set; }

        [Required(ErrorMessage = "Please enter an email address")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        public string? Password { get; set; }

    }
}
