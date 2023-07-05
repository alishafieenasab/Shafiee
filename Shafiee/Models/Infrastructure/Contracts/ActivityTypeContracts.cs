using Shafiee.Models.Entities;
using Shafiee.Models.Infrastructure.DB;

namespace Shafiee.Models.Infrastructure.Contracts
{
    public class ActivityTypeContracts
    {
        private readonly AppDbContext _context;
        public ActivityTypeContracts()
        {
            _context = new AppDbContext();
        }
        public ActivityType GetByName(string name, int id)
        {
            var activityType = _context.ActivityTypes.Where(t => t.Id == id).SingleOrDefault(t => t.Name == name);
            return activityType;
        }
        public bool EnsureNameNotExist(string name, int id)
        {
            var activityType = GetByName(name, id);
            if (activityType == null)
            {
                return true;
            }
            else return false;
        }
        public ActivityType GetByCode(int code, int id)
        {
            var activityType = _context.ActivityTypes.Where(t => t.Id == id).SingleOrDefault(t => t.Code == code);
            return activityType;
        }
        public bool EnsureCodeNotExist(int code, int id)
        {
            var activityType = GetByCode(code, id);
            if (activityType == null)
            {
                return true;
            }
            else return false;
        }
    }
}
