using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using gym.Models;

namespace Gym.Models
{
    public class Trainer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Specialty { get; set; }

        public List<GymClass> Classes { get; set; }  // Navigation property
    }
}
