using System.ComponentModel.DataAnnotations;

namespace DSS_LastVersion.Models
{
    public class Brotherhood
    {
        [Key]
        public int BrotherhoodId { get; set; }
        public string? BrotherhoodName { get; set; }
        public int BrotherhoodLevel { get; set; }
        public ICollection<Assassin>? Assassins { get; set; }

    }
}
