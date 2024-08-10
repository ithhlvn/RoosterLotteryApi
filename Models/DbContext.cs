using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoosterLottery.Models
{
    public class PlayerContext : DbContext
    {
        public PlayerContext(DbContextOptions options) : base(options)
        {

        }
        DbSet<Player> Player { get; set; }
    }
}
