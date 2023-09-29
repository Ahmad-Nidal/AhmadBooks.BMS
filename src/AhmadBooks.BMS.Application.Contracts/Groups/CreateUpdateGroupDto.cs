using System.ComponentModel.DataAnnotations;

namespace AhmadBooks.BMS.Groups
{
    public class CreateUpdateGroupDto
    {
        [Required]
        [StringLength(GroupConsts.MaxNameLength)]
        public string Name { get; set; }
    }
}
