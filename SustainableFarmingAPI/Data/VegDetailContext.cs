using Microsoft.EntityFrameworkCore;
using SustainableFarmingAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SustainableFarmingAPI.Data
{
    public class VegDetailContext : DbContext
    {
        public VegDetailContext(DbContextOptions<VegDetailContext> options)
            : base(options)
        {
           
        }
    public DbSet<VegDetail> VegdetailInfo { get; set; }
    }
}
