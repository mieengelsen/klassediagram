using ClassLibrary.Model;

namespace ClassLibrary.DataAccess;

public class BookingRepository
{
    private readonly List<Booking> _bookings = new();

    public int CountByClassId(int classId)
    {
        return _bookings.Count(b => b.ClassId == classId);
    }

    public bool Exists(int memberNo, int classId)
    {
        return _bookings.Any(b => b.MemberNo == memberNo && b.ClassId == classId);
    }

    public Booking Add(Booking b)
    {
        _bookings.Add(b);
        return b;
    }
}