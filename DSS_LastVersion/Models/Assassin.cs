namespace DSS_LastVersion.Models
{
    public enum Rank
    {
        Novice, Spy, Dispatcher, Master, Leader
    }
    public class Assassin
    {
        public int AssassinID { get; set; }
        public string? AssassinName { get; set; }
        public Rank AssassinRank { get; set; }
        public string image { get; set; }

        public int BrotherhoodID { get; set; }
        public Brotherhood? Brotherhoods { get; set; }

        public ICollection<Contract>? Contracts { get; set; }

    }
}
