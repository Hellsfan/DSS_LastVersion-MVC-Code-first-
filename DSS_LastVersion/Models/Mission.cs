namespace DSS_LastVersion.Models
{
    public class Mission
    {
        public int MissionID { get; set; }
        public string MissionName { get; set; }
        public int MissionLevel { get; set; }
        public string Target { get; set; }
        public ICollection<Contract>? Contracts { get; set; }

    }
}
