using System.ComponentModel.DataAnnotations;

namespace MVC_Core_WebApp1.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Roll No is required.")]
        public int RollNo { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(15,MinimumLength = 2,ErrorMessage = "Name must be between 2 and 15 characters.")]
        public string Name { get; set; }

        [Range(18,60,ErrorMessage = "Age must be between 18 and 60.")]
        public int Age { get; set; }


        public string Address { get; set; }
    }
}
