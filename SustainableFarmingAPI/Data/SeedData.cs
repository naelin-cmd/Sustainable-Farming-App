using SustainableFarmingAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SustainableFarmingAPI.Data
{
    public static class SeedData
    {
        public static void Initialize(VegDetailContext context)
        {
            if (!context.VegdetailInfo.Any())
            {
                {

                    context.VegdetailInfo.AddRange(



                    );



                    context.SaveChanges();

                }
            }
        }
        public static void Initialize(UserContext context)
        {
            if (!context.UserInfo.Any())

            {

                context.UserInfo.AddRange(



                );



                context.SaveChanges();
            }
        }
    }
}
