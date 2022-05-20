using DSS_LastVersion.Models;

namespace DSS_LastVersion.Services
{
    public interface IContract
    {
        IEnumerable<Contract> GetContracts { get; }
        Contract GetContract(int ID);
        void Add(Contract _Contract);
        void Remove(int ID);
    }
}
