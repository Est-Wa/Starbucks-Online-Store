using Entities;

namespace Repository
{
    public interface IRatingRepository
    {
        public Task AddRating(Rating rate);

    }
}