using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Data
{
    public class UserDTO : UserPublicDTO
    {
        public DateTime CreatedTs { get; set; }
        public string Email { get; set; }
        public int EnrollmentYear { get; set; }

        //TODO
        public string SecondaryEmail { get; set; }
        public UserRole Role { get; set; }
        public string PhoneNumber { get; set; }
        public int CurrentYear { get; set; }
    }
}
