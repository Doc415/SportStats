using SportStats.Enums;
using System.ComponentModel.DataAnnotations;

namespace SportStats.Models
{
    public class Pass : BaseStat
    {
        public int Id { get; set; }
        [Required]
        public Game InGame { get; set; }
        [Required]
        public Player BelongsTo { get; set; }
        [Required]
        public StatType Stat { get; set; } = StatType.Pass;
        [Required]
        public string Location { get; set; }
    }
}
