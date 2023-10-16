using System;
using System.ComponentModel.DataAnnotations;

namespace AhmadBooks.BMS.Groups
{
    public class UpdateGroupDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(BookConsts.MaxNameLength)]
        public string Name { get; set; }
    }
}
