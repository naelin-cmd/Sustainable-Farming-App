using Microsoft.EntityFrameworkCore;
using SustainableFarmingAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SustainableFarmingAPI.Data
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext>options)
            :base(options)
        {

        }
        public DbSet <User> UserInfo { get; set; }
    }
}
