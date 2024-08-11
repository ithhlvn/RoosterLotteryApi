using System;
using System.ComponentModel.DataAnnotations;

namespace RoosterLottery.Models
{
    public class Slot
    {
        [Key]
        public int Id { get; set; }
      
        [Required]
        public TimeSpan FrTime { get; set; }
        
        [Required]
        public TimeSpan ToTime { get; set; }
    }
}
