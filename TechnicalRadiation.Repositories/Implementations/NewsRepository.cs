using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Repositories.Data;

namespace TechnicalRadiation.Repositories.Implementations
{
    public class NewsRepository : INewsRepository
    {
        private readonly INewsDbContext _dbContext;

        public NewsRepository(INewsDbContext dbContext) 
        {
            _dbContext = dbContext;
        } 
    }
}
