using System.ComponentModel.DataAnnotations;

namespace GradeView.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter student name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter student surname")]
        public string? Surname { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        [Required(ErrorMessage = "Please enter student email")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please enter student password")]
        public string? Password { get; set; }
    }
}