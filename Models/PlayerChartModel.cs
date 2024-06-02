using SportStats.Enums;

namespace SportStats.Models;

public class StatChartModel
{
    public StatType Type { get; set; }
    public int Count { get; set; }

}

public class PlayerChartModel
{
    public int Id { get; set; }
    public List<StatChartModel> StatList { get; set; }
}
