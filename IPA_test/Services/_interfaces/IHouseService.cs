using IPA_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPA_test.Services
{
    public interface IHouseService
    {
        Task<House> GetHouseDetails(int id);
        Task<List<House>> GetHouses();
    }
}
