using System.ComponentModel.DataAnnotations;

namespace FinalTest.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Pasword is Required")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessage = "Password must have at-least 1 special character, 1 number and 1 alphabet")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Required]
        public string ImageName { get; set; }

       
        public bool IsApprover { get; set; } = false;

        public string VolunteerStatus { get; set; } = "Pending";

        [Required]
        [RegularExpression(@"^[0-9]{12,12}$", ErrorMessage ="Enter 12 Digit Number")]
        public string AdhaarNumber { get; set; }
    }
}