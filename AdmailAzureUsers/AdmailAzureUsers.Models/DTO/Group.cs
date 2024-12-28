using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmailAzureUsers.Models.DTO
{
    public class Group
    {
        public string GroupId { get; set; }
        public string GroupName { get; set; }
        public List<Member> Members { get; set; }

        public Group() { }
        public Group(string _groupId, string _groupName,List<Member> _members)
        {
            GroupId = _groupId;
            GroupName = _groupName;
            Members = _members;
        }

    }
}
