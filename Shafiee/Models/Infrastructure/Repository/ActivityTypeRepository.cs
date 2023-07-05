using Microsoft.EntityFrameworkCore;
using Shafiee.Models.Entities;
using Shafiee.Models.Infrastructure.DB;

namespace Shafiee.Models.Infrastructure.Repository
{
    public class ActivityTypeRepository
    {
        private readonly AppDbContext _context;
        public ActivityTypeRepository()
        {
            _context = new AppDbContext();
        }

        public async Task<List<ActivityType>> ActivityTypes()
        {
            return await _context.ActivityTypes.ToListAsync();
        }
        public async Task<ActivityType> GetById(int id)
        {
            return await _context.ActivityTypes.SingleOrDefaultAsync(t => t.Id == id);
        }
        public async Task Add(ActivityType activityType)
        {
            var _activityType = new ActivityType
            {
                Name = activityType.Name,
                Code = activityType.Code,
                IsActive = activityType.IsActive
            };
            _context.ActivityTypes.AddAsync(_activityType);
            _context.SaveChangesAsync();

        }
        public void Update(ActivityType activityType)
        {
            var _activityType = new ActivityType
            {
                Name = activityType.Name,
                Code = activityType.Code,
                IsActive = activityType.IsActive
            };
            _context.ActivityTypes.Update(_activityType);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var _activityType = _context.ActivityTypes.SingleOrDefault(t => t.Id == id);
            _context.ActivityTypes.Remove(_activityType);
            _context.SaveChanges();
        }

    }
}
