using System;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        public DateTime JoinDate { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}
