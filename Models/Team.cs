using System.ComponentModel.DataAnnotations;
namespace SportStats.Models;

public class Team
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public List<Player> Players { get; set; }

}
