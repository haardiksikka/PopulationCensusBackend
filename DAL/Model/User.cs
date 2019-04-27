using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
{
   public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string ImageName { get; set; }
        [Required]
        public string Password { get; set; }

        public bool IsApprover { get; set; } = false;

        public string VolunteerStatus { get; set; } = "Pending";

        [Required]
        public string AdhaarNumber { get; set; }

        


    }
}
