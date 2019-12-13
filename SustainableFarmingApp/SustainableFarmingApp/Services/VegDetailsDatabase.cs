using Newtonsoft.Json;
using SQLite;
using SustainableFarmingApp.Models;
using SustainableFarmingApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SustainableFarmingApp.Services
{
    public class VegDetailsDatabase : IVegDatabase
    {
        private SQLiteAsyncConnection _database;

        public VegDetailsDatabase()
        {
            string dbPath = GetDbPath();

            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<VegDetail>().Wait();
            _database.CreateTableAsync<VeggieOrders>().Wait();
            SeedData();
        }






        private string GetDbPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "VegDetail.db3");
        }


        public async Task<int> DeleteUser(User user)
        {
            return await _database.DeleteAsync(user);
        }
     

        public async Task<int> DeleteVegDetails(VegDetail vegDetail)
        {
            return await _database.DeleteAsync(vegDetail);
        }

        public async Task<User> GetUser()
        {
            return await _database.Table<User>().FirstOrDefaultAsync();
        }
        public async Task<List<User>>GetUserList()
        {
            return await _database.Table<User>().ToListAsync();
        }
        public async Task<List<VegDetail>> GetVegDetails()
        {
            return await _database.Table<VegDetail>().ToListAsync();
        }

        public async Task<int> InsertUser(User user)
        {
            return await _database.InsertAsync(user);
        }

        public async Task<int> InsertVegDetails(VegDetail vegdetail)
        {
            return await _database.InsertAsync(vegdetail);
        }

        public async Task<int> UpdateUser(User user)
        {
            return await _database.UpdateAsync(user);
        }
        public Task<List<User>> GetItemsAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public async Task<int> UpdateVegDetails(VegDetail vegdetail)
        {
            return await _database.UpdateAsync(vegdetail);
        }
        public async Task<VeggieOrders> GetVeggieOrders()
        {
            return await _database.Table<VeggieOrders>().FirstOrDefaultAsync();
        }

        public async Task<int> DeleteVegOrders(VeggieOrders veggieOrders)
        {
            return await _database.DeleteAsync(veggieOrders);
        }

        public async Task<int> UpdateVegOrders(VeggieOrders veggieOrders)
        {
            return await _database.UpdateAsync(veggieOrders);
        }

        public async Task<int> InsertVegOrders(VeggieOrders veggieOrders)
        {
            return await _database.InsertAsync(veggieOrders);
        }
        private async void SeedData()
        {
           
            //Add Veg Stuff
            if (await _database.Table<VegDetail>().CountAsync() == 0)
            {
               

                 


                
               
                  var  vegdetail =new VegDetail
                    { 
                      Name = "Pea",
                    Sunlight = "Best in areas that receive six to eight hours of sunlight",
                    Soil = "Peas prefer a fertile, sandy loam that drains well, but will tolerate most soils except heavy, impermeable clay",
                    ImgSrc = "Pea.jpg",
                    Yield = "In the past I get about 3 peas per pod and about 5 pods per plant that = about 15 peas per plant.",
                    WaterContent = "As young plants, peas are composed of 80 to 95 percent water, and the remaining percent is tissue. Old woody plants contain about 50 percent water, while leafy plants can contain as much as 95 percent.",
                    TimeToPlant = "Winter",
                    HowLongItTakeToHarvest = "Peas are ready to harvest in approximately 60-70 days.",

                 


                };
                await _database.InsertAsync(vegdetail);

                vegdetail = new VegDetail
                {
                    Name = "Scallion",
                    Sunlight = "Grows best an enclosed environment with partial sunlight between six to seven hours",
                    Soil = "Scallions prefer an organic soil that drains well. Work organic matter into your soil at least 6-8 inches deep, removing stones, then level and smooth.",
                    ImgSrc = "Scallion.jpg",
                    Yield = "Yield 750grams per 10-foot row.",
                    WaterContent = "Cook with them, place their stumps in a cup of water, and they'll regrow in no time at all. Green onions are one such vegetable, and they work especially well because they're usually sold with their roots still attached",
                    TimeToPlant = "Winter",
                    HowLongItTakeToHarvest = "The exact time for scallion picking varies upon personal preference but is usually within about 60 days after planting.",




                };
                await _database.InsertAsync(vegdetail);


                vegdetail = new VegDetail
                {
                    Name = "Chard",
                    Sunlight = "It grows best in full sunlight for round about six to eight hours",
                    Soil = "Growing Swiss chard works best in rich, moist soil with a soil pH between 6.0 and 6.8. Plant about 12 to 18 inches apart in fertile soil, watering directly after planting.",
                    ImgSrc = "Chard.png",
                    Yield = "Grow 2 to 3 plants per person. Yield 8 to 12 pounds per 10-foot row. Space plants 12 inches apart in rows 18 to 30 inches apart.",
                    WaterContent = "Water content and RDA percentage, per serving and per 100g, in 3 types of swiss chard. The amount of Water is 92.66 g to 92.65 g per 100g, in swiss chard.",
                    TimeToPlant = "Winter",
                    HowLongItTakeToHarvest = "45 to 60 days",




                };
                await _database.InsertAsync(vegdetail);

                vegdetail = new VegDetail
                {
                    Name = "Broad Bean",
                    Sunlight = "Needs to receive full sunlight, which means eight to ten hours of sunlight",
                    Soil = "Grow your broad beans in full sun on rich, fertile, well-manured soil.",
                    ImgSrc = "BroadBeans.png",
                    Yield = "A: Broad beans are prolific producers but need to be picked regularly to keep them coming on.",
                    WaterContent = "Creating the bean pod takes photosynthesis energy along with a generous water supply; plants use approximately 1/2 inch of water each day during the blossom and pod growth period.",
                    TimeToPlant = "Winter",
                    HowLongItTakeToHarvest = "Four months before you can harvest",




                };
                await _database.InsertAsync(vegdetail);

                vegdetail = new VegDetail
                {
                    Name = "Kale",
                    Sunlight = "Grows best in light shade to minimize the burning of the leaves, requires sunlight of six hours per day",
                    Soil = "Kale also prefers loamy, well-drained, moist (but not soggy) soil of average fertility. ",
                    ImgSrc = "Kale.png",
                    Yield = "Yield 2 to 4 kilograms per 10-foot row",
                    WaterContent = "Kale likes a nice, even supply of water, about 1 to 1.5 inches per week. You can measure how much water rain has provided by using a rain gauge in the garden. ",
                    TimeToPlant = "Winter",
                    HowLongItTakeToHarvest = "Kale will be ready for harvest 55 days from transplanting, 70 to 80 days from seed.",




                };
                await _database.InsertAsync(vegdetail);

                vegdetail = new VegDetail
                {
                    Name = "Cabbage",
                    Sunlight = "The cabbage needs about six hours sunlight daily.",
                    Soil = "Like most vegetables, cabbage needs at least 6 hours of full sun each day; more is better. It also needs fertile, well-drained, moist soil with plenty of rich organic matter. The soil pH should be between 6.5 and 6.8 for optimum growth and to discourage clubroot disease.",
                    ImgSrc = "Cabbage.jpg",
                    Yield = "To get two crops from early cabbage plants",
                    WaterContent = "Cabbage requires a consistently moist soil. While it won't tolerate sitting in wet, soggy soil, it needs regular watering to produce its leafy heads. Water your cabbage once a week",
                    TimeToPlant = "Summer",
                    HowLongItTakeToHarvest = "This will take around 70 days for most green cabbage varieties.",




                };
                await _database.InsertAsync(vegdetail);

                vegdetail = new VegDetail
                {
                    Name = "Chilli",
                    Sunlight = "This veggie requires full sunlight for best growth",
                    Soil = "Chilli loves loamy soil",
                    ImgSrc = "Chilli.jpg",
                    Yield = "50 - 100 chillies per plant",
                    WaterContent = "The chilli plants will need to be watered every day and perhaps even twice a day in very hot weather. Once the plant starts bearing fruit, it is advisable to add potash liquid feed to the water every 10 or so days.",
                    TimeToPlant = "Summer",
                    HowLongItTakeToHarvest = "This will take around 70 days for most green cabbage varieties.",




                };
                await _database.InsertAsync(vegdetail);

                vegdetail = new VegDetail
                {
                    Name = "Carrot",
                    Sunlight = "This requires full sunlight for a full eight hours in the sun",
                    Soil = "he best soil for carrots is deep sandy loam or loamy soils with a loose structure. Sand is easier to clean off at harvest. Heavy, stony, compacted or poorly-drained soils cause deformed roots.",
                    ImgSrc = "Carrot.jpg",
                    Yield = "10 per plant",
                    WaterContent = "Like most vegetables, growing carrots need a minimum of 1 inch of water every week. If they cannot get an adequate supply from rainfall, you will need to water the soil. When you water your carrots, make sure to soak the soil completely.",
                    TimeToPlant = "Summer",
                    HowLongItTakeToHarvest = "Baby carrots are usually ready to harvest 50 to 60 days from the planting date. Mature carrots need a few more weeks and are usually ready in about 75 days.",




                };
                await _database.InsertAsync(vegdetail);

                vegdetail = new VegDetail
                {
                    Name = "Beetroot",
                    Sunlight = "This veggie needs little sunlight of about four to five hours ",
                    Soil = "Soil. Beets grow best in loamy, acid soils (pH levels ranging between 6.0 and 7.5).",
                    ImgSrc = "Beetroot.jpg",
                    Yield = "One plant only reproduces on beetroot",
                    WaterContent = "so give 8mm water per day during long spells of hot, sunny weather. On cold winter days, apply about 2mm of water.",
                    TimeToPlant = "Summer",
                    HowLongItTakeToHarvest = "this is usually 90 days after sowing.",




                };
                await _database.InsertAsync(vegdetail);

                vegdetail = new VegDetail
                {
                    Name = "Cucumber",
                    Sunlight = "This will need full sunlight throughout the day",
                    Soil = "This veggie requires well drained soil and should not be soggy.",
                    ImgSrc = "Cucumber.jpg",
                    Yield = "2 kilograms of cucumbers per plant.",
                    WaterContent = "The main care requirement for cucumbers is water—consistent watering! They need at least one inch of water per week",
                    TimeToPlant = "Summer",
                    HowLongItTakeToHarvest = " It is ready for harvest in 50 to 70 days from planting",




                };

                await _database.InsertAsync(vegdetail);

            }
        }

      
    }
}
