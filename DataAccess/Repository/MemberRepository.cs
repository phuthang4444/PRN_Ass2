using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void AddNewMember(MemberObject member)
            => MemberDAO.Instace.AddNew(member);

        public MemberObject GetMemberByID(int memberID)
            => MemberDAO.Instace.GetMemberByID(memberID);

        public IEnumerable<MemberObject> GetMembers()
            => MemberDAO.Instace.GetMemberList();

        public MemberObject Login(string Email, string Password)
            => MemberDAO.Instace.Login(Email, Password);

        public void RemoveMember(int memberID)
            => MemberDAO.Instace.Remove(memberID);

        public void UpdateMember(MemberObject member)
            => MemberDAO.Instace.Update(member);
    }
}
