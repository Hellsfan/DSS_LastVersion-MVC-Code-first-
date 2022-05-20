using DSS_LastVersion.Models;
using DSS_LastVersion.Services;
using Microsoft.EntityFrameworkCore;

namespace DSS_LastVersion.Repository
{
    public class BrotherhoodRepository : IBrotherhood
    {
        private DBContext db;
        public BrotherhoodRepository(DBContext _db)
        {
            db = _db;
        }

        public IEnumerable<Brotherhood> GetBrotherhoods => db.Brotherhoods;

        public void Add(Brotherhood _Brotherhood)
        {
                db.Brotherhoods.Add(_Brotherhood);
                db.SaveChanges();
        }

        public Brotherhood GetBrotherhood(int ID)
        {
            Brotherhood dbEntity = db.Brotherhoods.Include(c => c.Assassins).SingleOrDefault(x => x.BrotherhoodId==ID);
            return dbEntity;
        }

        public void Remove(int ID)
        {
            Brotherhood dbEntity = db.Brotherhoods.Find(ID);
            db.Brotherhoods.Remove(dbEntity);
            db.SaveChanges();
        }
    }
}
