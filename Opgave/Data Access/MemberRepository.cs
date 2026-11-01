using ClassLibrary.Model;

namespace ClassLibrary.DataAccess;

public class MemberRepository
{
    private readonly List<Member> _members = new()
    {
        new Member { MemberNo = 1, Name = "Anna" },
        new Member { MemberNo = 2, Name = "Bo" }
    };

    public Member? GetByMemberNo(int memberNo)
    {
        return _members.FirstOrDefault(m => m.MemberNo == memberNo);
    }
}