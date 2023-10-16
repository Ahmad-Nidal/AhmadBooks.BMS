using System;
using System.ComponentModel.DataAnnotations;

namespace AhmadBooks.BMS.Groups
{
    public class CreateGroupDto
    {
        [Required]
        [StringLength(BookConsts.MaxNameLength)]
        public string Name { get; set; }
    }
}
