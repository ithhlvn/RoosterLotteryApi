using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoosterLottery.Models
{
    public class RoosterLotteryContext : DbContext
    {
        public RoosterLotteryContext(DbContextOptions options) : base(options)
        {
        }
        DbSet<Slot> Slot { get; set; }
        DbSet<Player> Player { get; set; }
        DbSet<Bet> Bet { get; set; }
    }
}
