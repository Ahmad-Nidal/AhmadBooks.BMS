using System;
using System.Collections.Generic;

namespace AhmadBooks.BMS.Members
{
    public class GroupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<MemberDto> Members { get; set; }
    }
}
