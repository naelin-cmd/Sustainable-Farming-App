using SustainableFarmingApp.Models;
using SustainableFarmingApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace SustainableFarmingApp.Services
{
    
       public class MappingService : IMapping
       {
    //       int _pinCreatedCount = 0;
           public Location GetNewLocation()
           {

            var myLocation = new Location("Address- Shoprite", "Description - Town Centre", new Position(-33.9323285, 18.6241775));

            return myLocation;

          /*     _pinCreatedCount++;
               return new Location(
                   $"Pin {_pinCreatedCount}",
                   $"Desc {_pinCreatedCount}",
                   Location.Next(new Position(-33.933329, 18.6333308), 4, 10));


    */


           }
       }
    
}
