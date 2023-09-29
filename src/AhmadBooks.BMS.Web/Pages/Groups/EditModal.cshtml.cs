using AhmadBooks.BMS.Groups;
using AhmadBooks.BMS.Web.ViewModels.Groups;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp;
using Microsoft.Extensions.Logging;

namespace AhmadBooks.BMS.Web.Pages.Groups
{
    public class EditModel : BMSPageModel
    {
        [BindProperty]
        public UpdateGroupViewModel Group { get; set; }

        private readonly IGroupAppService _groupAppService;

        public EditModel(IGroupAppService groupAppService)
        {
            _groupAppService = groupAppService;
        }

        public async Task OnGetAsync(Guid id)
        {
            try
            {
                var groupDto = await _groupAppService.GetAsync(id);
                Group = ObjectMapper.Map<GroupDto, UpdateGroupViewModel>(groupDto);
            }
            catch (EntityNotFoundException ex)
            {
                throw new UserFriendlyException(message: ex.Message);
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, L["CantRetrieveGroup"]);
                throw new UserFriendlyException(message: L["CantRetrieveGroup"], innerException: ex);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var groupDto = ObjectMapper.Map<UpdateGroupViewModel, UpdateGroupDto>(Group);
            try
            {
                await _groupAppService.UpdateAsync(Group.Id, groupDto);
            }
            catch (GroupAlreadyExistsException ex)
            {
                //TODO: throw new UserFriendlyException(message: L[ex.Code, Group.Name]);
                throw new UserFriendlyException(message: L[ex.Code]);
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, L["CantUpdateGroup"]);
                throw new UserFriendlyException(message: L["CantUpdateGroup"], innerException: ex);
            }
            return NoContent();
        }
    }
}
