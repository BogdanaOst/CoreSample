using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryCoreSample.Models
{
    public class HouseContext : DbContext
    {
        public DbSet<House> Houses { get; set; }
        public HouseContext(DbContextOptions<HouseContext> options) :
            base(options)
        {

        }
    }
}
