using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RoosterLottery.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string FullName { get; set; }
        public DateTime? DoB { get; set; }
        public string Phone { get; set; }
    }
}
