using ClassLibrary.Model;

namespace ClassLibrary.DataAccess;

public class FitnessClassRepository
{
    private readonly List<FitnessClass> _classes = new()
    {
        new FitnessClass { ClassId = 1, Name = "Spinning", StartTime = DateTime.Now.AddDays(1), Capacity = 2 },
        new FitnessClass { ClassId = 2, Name = "Yoga", StartTime = DateTime.Now.AddDays(2), Capacity = 10 },
        new FitnessClass { ClassId = 3, Name = "Crossfit", StartTime = DateTime.Now.AddDays(-1), Capacity = 8 }
    };

    public List<FitnessClass> GetUpcoming(DateTime now)
    {
        return _classes.Where(c => c.StartTime > now).OrderBy(c => c.StartTime).ToList();
    }

    public FitnessClass? GetById(int classId)
    {
        return _classes.FirstOrDefault(c => c.ClassId == classId);
    }
}