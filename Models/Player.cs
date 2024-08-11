using System;
using System.ComponentModel.DataAnnotations;

namespace RoosterLottery.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string FullName { get; set; }

        //[Required]
        //public Gender Gender { get; set; }

        [Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DoB { get; set; }
        
        [Required]
        [StringLength(11, MinimumLength =10)]
        public string Phone { get; set; }
    }
}
