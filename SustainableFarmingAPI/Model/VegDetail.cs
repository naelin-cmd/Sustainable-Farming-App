using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SustainableFarmingAPI.Model
{
    public class VegDetail
    {
        public int Id { get; set; }
        public string ImgSrc { get; set; }
        public string Name { get; set; }
        public string WaterContent { get; set; }
        public string Soil { get; set; }
        public string Sunlight { get; set; }
        public string Yield { get; set; }
        public string HowLongItTakeToHarvest { get; set; }
        public string TimeToPlant { get; set; }
    }
}
