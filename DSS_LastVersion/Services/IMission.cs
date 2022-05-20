using DSS_LastVersion.Models;

namespace DSS_LastVersion.Services
{
    public interface IMission
    {
        IEnumerable<Mission> GetMissions { get; }
        Mission GetMission(int ID);
        void Add(Mission _Mission);
        void Remove(int ID);
    }
}
