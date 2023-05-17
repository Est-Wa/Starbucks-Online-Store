using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;


namespace Repository
{
    public class RatingRepository : IRatingRepository
    {
        StoreDbContext _storeDbContext;
        public RatingRepository(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }
        public async Task AddRating (Rating rate)
        {
            await _storeDbContext.Rating.AddAsync(rate);
            await _storeDbContext.SaveChangesAsync();
        }

    }
}
