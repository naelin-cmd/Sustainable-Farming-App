﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace SustainableFarmingApp.Models
{
    static class MyLocation
    {
         static Random Random = new Random(Environment.TickCount);

        public static Position Next(Position position, double latitudeRange, double longitudeRange)
        {
            return new Position(
            position.Latitude + (Random.NextDouble() * 2 - 1) * latitudeRange,
            position.Longitude + (Random.NextDouble() * longitudeRange)

                                                                        ); 
        }
  }
  
}
