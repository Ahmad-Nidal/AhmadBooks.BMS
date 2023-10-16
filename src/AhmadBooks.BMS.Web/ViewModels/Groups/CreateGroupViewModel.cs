using AhmadBooks.BMS.Groups;
using System.ComponentModel.DataAnnotations;

namespace AhmadBooks.BMS.Web.ViewModels.Groups
{
    public class CreateGroupViewModel
    {
        [Required]
        [StringLength(BookConsts.MaxNameLength)]
        public string Name { get; set; }
    }
}