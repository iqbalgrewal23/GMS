using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Gym.Models;

namespace Gym.Models
{
    public class GymClass
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime Schedule { get; set; }

        [ForeignKey("Trainer")]
        public int TrainerId { get; set; }

        public Trainer Trainer { get; set; }
    }
}
