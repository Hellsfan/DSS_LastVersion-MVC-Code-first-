using DSS_LastVersion.Models;

namespace DSS_LastVersion.Services
{
    public interface IAssassin
    {
        IEnumerable<Assassin> GetAssassins { get; }
        Assassin GetAssassin(int ID);
        void Add(Assassin _Assassin);
        void Remove(int ID);
    }
}
