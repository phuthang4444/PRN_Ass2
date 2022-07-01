using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        public IEnumerable<MemberObject> GetMembers();
        public MemberObject GetMemberByID(int memberID);
        public void AddNewMember(MemberObject member);
        public void UpdateMember(MemberObject member);
        public void RemoveMember(int memberID);

        public MemberObject Login(string Email, string Password);

    }
}
