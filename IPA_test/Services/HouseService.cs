using IPA_test.Data;
using IPA_test.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPA_test.Services
{
    public class HouseService : IHouseService
    {
        private readonly DatabaseContext _db;
        public HouseService(DatabaseContext db)
        {
            _db = db;
          
        }
        public async Task<House> GetHouseDetails(int id)
        {
            return await _db.Houses
                .Include(house => house.Images)
                .Include(house => house.Rents)
                .FirstOrDefaultAsync(house => house.ID == id);
        }

        public async Task<List<House>> GetHouses()
        {
            return await _db.Houses
                .Include(house => house.Images)
                .Include(house => house.Rents)
                .OrderBy(house => house.Name)
                .ToListAsync();
        }
    }
}
