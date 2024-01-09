using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GradeView.Models
{
    public class Course
    {
        [Key]
        [Required(ErrorMessage = "Please enter course code")]
        public string? Id { get; set; }

        [Required(ErrorMessage = "Please enter course name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter course credit")]
        public int Credit { get; set; }

        [Required(ErrorMessage = "Please enter course teacher")]
        public string? Teacher { get; set; }
    }
}