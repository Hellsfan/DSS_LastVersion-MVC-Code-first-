using DSS_LastVersion.Models;

namespace DSS_LastVersion.Services
{
    public interface IBrotherhood
    {
        IEnumerable<Brotherhood> GetBrotherhoods { get; }
        Brotherhood GetBrotherhood(int ID);
        void Add(Brotherhood _Brotherhood);
        void Remove(int ID);
    }
}
