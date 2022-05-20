using DSS_LastVersion.Models;
using DSS_LastVersion.Services;
using Microsoft.EntityFrameworkCore;

namespace DSS_LastVersion.Repository
{
    public class AssassinRepository : IAssassin
    {
        private DBContext db;
        public AssassinRepository(DBContext _db)
        {
            db = _db;
        }

        public IEnumerable<Assassin> GetAssassins => db.Assassins.Include(a => a.Brotherhoods);

        public void Add(Assassin _Assassin)
        {
            db.Assassins.Add(_Assassin);
            db.SaveChanges();
        }

        public Assassin GetAssassin(int ID)
        {
            Assassin dbEntity = db.Assassins
                .Include(a => a.Brotherhoods)
                .Include(t => t.Contracts)
                .ThenInclude(g=>g.Missions)
                .SingleOrDefault(s => s.AssassinID == ID);

            return dbEntity;
        }

        public void Remove(int ID)
        {
            Assassin dbEntity = db.Assassins.Find(ID);
            db.Assassins.Remove(dbEntity);
            db.SaveChanges();
        }
    }
}
