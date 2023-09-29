using AhmadBooks.BMS.Groups;
using System.ComponentModel.DataAnnotations;

namespace AhmadBooks.BMS.Web.ViewModels.Groups
{
    public class CreateGroupViewModel
    {
        [Required]
        [StringLength(GroupConsts.MaxNameLength)]
        public string Name { get; set; }
    }
}