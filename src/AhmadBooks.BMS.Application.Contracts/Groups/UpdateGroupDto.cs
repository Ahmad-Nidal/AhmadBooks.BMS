using System;
using System.ComponentModel.DataAnnotations;

namespace AhmadBooks.BMS.Groups
{
    public class UpdateGroupDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(GroupConsts.MaxNameLength)]
        public string Name { get; set; }
    }
}
