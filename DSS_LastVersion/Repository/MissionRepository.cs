using DSS_LastVersion.Models;
using DSS_LastVersion.Services;
using Microsoft.EntityFrameworkCore;

namespace DSS_LastVersion.Repository
{
    public class MissionRepository : IMission
    {
        private DBContext db;
        public MissionRepository(DBContext _db)
        {
            db = _db;
        }
        public IEnumerable<Mission> GetMissions => db.Missions;

        public void Add(Mission _Mission)
        {
            db.Missions.Add(_Mission);
            db.SaveChanges();
        }

        public Mission GetMission(int ID)
        {
            Mission dbEntity = db.Missions.Include(t => t.Contracts)
                .ThenInclude(g => g.Assassins)
                .SingleOrDefault(s => s.MissionID == ID); ;
            return dbEntity;
        }

        public void Remove(int ID)
        {
            Mission dbEntity = db.Missions.Find(ID);
            db.Missions.Remove(dbEntity);
            db.SaveChanges();
        }
    }
}
