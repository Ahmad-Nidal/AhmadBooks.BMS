using AhmadBooks.BMS.Groups;
using AhmadBooks.BMS.Web.ViewModels.Groups;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Volo.Abp;

namespace AhmadBooks.BMS.Web.Pages.Groups
{
    public class CreateModel : BMSPageModel
    {
        [BindProperty]
        public CreateGroupViewModel Group { get; set; }

        private readonly IGroupAppService _groupAppService;

        public CreateModel(IGroupAppService groupAppService)
        {
            _groupAppService = groupAppService;
        }

        public void OnGet()
        {
            Group = new CreateGroupViewModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var groupDto = ObjectMapper.Map<CreateGroupViewModel, CreateGroupDto>(Group);
            try
            {
                await _groupAppService.CreateAsync(groupDto);
            }
            catch (GroupAlreadyExistsException ex)
            {
                //TODO: throw new UserFriendlyException(message: L[ex.Code, Group.Name]);
                throw new UserFriendlyException(message: L[ex.Code]);
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, L["CantCreateGroup"]);
                throw new UserFriendlyException(message: L["CantCreateGroup"], innerException: ex);
            }
            return NoContent();
        }
    }
}
