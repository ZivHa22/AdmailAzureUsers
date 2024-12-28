using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmailAzureUsers.Models.DTO
{
    public class Member
    {
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberEmail { get; set; }

        public Member() { }
        public Member(string _memberId, string _memberName,string _memberEmail)
        {
            MemberId = _memberId;
            MemberName = _memberName;
            MemberEmail = _memberEmail;
        }
    }
}
