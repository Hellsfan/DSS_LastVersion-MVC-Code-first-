namespace DSS_LastVersion.Models
{
    public class Contract
    {
        public int ContractID { get; set; }
        public int AssassinID   { get; set; }
        public int MissionID { get; set; }
        public Assassin? Assassins { get; set; }
        public Mission? Missions { get; set; }

    }
}
