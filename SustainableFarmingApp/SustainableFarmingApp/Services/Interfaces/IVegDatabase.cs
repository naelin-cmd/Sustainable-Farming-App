using SustainableFarmingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SustainableFarmingApp.Services.Interfaces
{
    public interface IVegDatabase
    {
        Task<List<VegDetail>> GetVegDetails();
        Task<int> DeleteVegDetails(VegDetail vegDetail);
        Task<int> UpdateVegDetails(VegDetail vegdetail);
        Task<int> InsertVegDetails(VegDetail vegdetail);



        Task<User> GetUser();
        Task<int> DeleteUser(User user);
        Task<int> UpdateUser(User user);
        Task<int> InsertUser(User user);

        Task<VeggieOrders> GetVeggieOrders();
        Task<int> DeleteVegOrders(VeggieOrders veggieOrders);
        Task<int> UpdateVegOrders(VeggieOrders veggieOrders);
        Task<int> InsertVegOrders(VeggieOrders veggieOrders);

    }
}
