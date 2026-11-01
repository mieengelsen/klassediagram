namespace ClassLibrary.Model;

public class FitnessClass
{
    public int ClassId { get; set; }
    public string Name { get; set; } = "";
    public DateTime StartTime { get; set; }
    public int Capacity { get; set; }
}