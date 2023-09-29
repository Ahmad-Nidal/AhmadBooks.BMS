using Volo.Abp.Application.Dtos;

namespace AhmadBooks.BMS.Groups
{
    public class GetGroupListDto : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}
