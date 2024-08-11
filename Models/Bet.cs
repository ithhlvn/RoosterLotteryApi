using System;
using System.ComponentModel.DataAnnotations;

namespace RoosterLottery.Models
{
    public class Bet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PlayerId { get; set; }
        
        //[Required]
        //[Range(0, 24)]
        //public SlotEnum Slot { get; set; }

        [Required] 
        public int SlotId { get; set; }

        [Required]
        [Range(0, 9)]
        public byte Value { get; set; }

        [Required]
        public DateTime OnDate { get; set; }

        [Required]
        public bool IsWin { get; set; }
    }
}
