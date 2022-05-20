using DSS_LastVersion.Models;
using DSS_LastVersion.Services;
using Microsoft.EntityFrameworkCore;

namespace DSS_LastVersion.Repository
{
    public class ContractRepository : IContract
    {
        private DBContext db;
        public ContractRepository(DBContext _db)
        {
            db = _db;
        }

        public IEnumerable<Contract> GetContracts => db.Contracts
            .Include(c => c.Assassins)
            .Include(d => d.Missions);

        public void Add(Contract _Contract)
        {
            db.Contracts.Add(_Contract);
            db.SaveChanges();
        }

        public Contract GetContract(int ID)
        {
            return db.Contracts.Include(c => c.Assassins)
                .Include(d => d.Missions)
                .SingleOrDefault(e => e.ContractID == ID);
        }

        public void Remove(int ID)
        {
            Contract model = db.Contracts.Find(ID);
            db.Contracts.Remove(model);
            db.SaveChanges();

        }
    }
}
