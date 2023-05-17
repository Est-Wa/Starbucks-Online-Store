using Entities;

namespace Services
{
    public interface IRatingService
    {
        public Task AddRating(Rating rate);

    }
}