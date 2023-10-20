using System;
using System.ComponentModel.DataAnnotations;

namespace AhmadBooks.BMS.Groups
{
    public class CreateGroupDto
    {
        [Required]
        [StringLength(GroupConsts.MaxNameLength)]
        public string Name { get; set; }
    }
}
