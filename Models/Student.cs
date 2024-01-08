using System.ComponentModel.DataAnnotations;

namespace GradeView.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter student name")]
        public string? Name { get; set; }
        [Range(0, 100, ErrorMessage = "Please enter a valid score")]
        public int Score { get; set; }
    }
}