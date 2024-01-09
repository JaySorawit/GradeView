using System.ComponentModel.DataAnnotations;

namespace GradeView.Models
{
    public class Enroll
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        [Range(0, 100, ErrorMessage = "Please enter a valid score")]
        public int Score { get; set; }

        public string? time { get; set; }
    }
}