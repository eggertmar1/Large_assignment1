using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Repositories.Data;

namespace TechnicalRadiation.Repositories.Implementations
{
    public class NewsRepository : INewsRepository
    {
        private readonly NewsDbContext _dbContext;

        public NewsRepository(NewsDbContext dbContext) 
        {
            _dbContext = dbContext;
        } 
    }
}
