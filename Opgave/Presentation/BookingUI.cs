using ClassLibrary.Application;
using ClassLibrary.Model;

namespace ClassLibrary.Presentation;

public class BookingUI
{
    private readonly BookingController _controller;
    private int memberNo;
    private int classId;

    public BookingUI(BookingController controller)
    {
        _controller = controller;
    }

    public List<FitnessClass> BookClass()
    {
        Console.Write("Indtast medlemsnummer: ");
        memberNo = int.Parse(Console.ReadLine() ?? "0");

        List<FitnessClass> classes = _controller.GetUpcomingClasses(memberNo);

        Console.WriteLine("\nKommende hold:");
        foreach (FitnessClass c in classes)
            Console.WriteLine($"  {c.ClassId}: {c.Name} - {c.StartTime:dd/MM HH:mm}");

        Console.Write("\nVælg hold-id: ");
        classId = int.Parse(Console.ReadLine() ?? "0");

        try
        {
            _controller.BookClass(memberNo, classId);
            Console.WriteLine("Booking gennemført!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fejl: {ex.Message}");
        }

        return classes;
    }
}