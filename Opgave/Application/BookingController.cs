using ClassLibrary.DataAccess;
using ClassLibrary.Model;

namespace ClassLibrary.Application;

public class BookingController
{
    private readonly MemberRepository _memberRepo;
    private readonly FitnessClassRepository _fitnessClassRepo;
    private readonly BookingRepository _bookingRepo;

    public BookingController(MemberRepository memberRepo,
                             FitnessClassRepository fitnessClassRepo,
                             BookingRepository bookingRepo)
    {
        _memberRepo = memberRepo;
        _fitnessClassRepo = fitnessClassRepo;
        _bookingRepo = bookingRepo;
    }

    public List<FitnessClass> GetUpcomingClasses(int memberNo)
    {
        if (_memberRepo.GetByMemberNo(memberNo) == null)
            throw new ArgumentException($"Medlem {memberNo} findes ikke.");

        return _fitnessClassRepo.GetUpcoming(DateTime.Now);
    }

    public Booking BookClass(int memberNo, int classId)
    {
        if (_memberRepo.GetByMemberNo(memberNo) == null)
            throw new ArgumentException($"Medlem {memberNo} findes ikke.");

        FitnessClass? fitnessClass = _fitnessClassRepo.GetById(classId);
        if (fitnessClass == null)
            throw new ArgumentException($"Hold {classId} findes ikke.");

        if (fitnessClass.StartTime <= DateTime.Now)
            throw new InvalidOperationException("Holdet er allerede startet.");

        if (_bookingRepo.Exists(memberNo, classId))
            throw new InvalidOperationException("Du har allerede booket dette hold.");

        if (_bookingRepo.CountByClassId(classId) >= fitnessClass.Capacity)
            throw new InvalidOperationException("Holdet er fuldt.");

        return _bookingRepo.Add(new Booking { MemberNo = memberNo, ClassId = classId });
    }
}