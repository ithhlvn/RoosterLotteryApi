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
        public DbSet<Slot> Slot { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Bet> Bet { get; set; }
    }
}
