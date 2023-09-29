using Volo.Abp;

namespace AhmadBooks.BMS.Groups
{
    public class GroupAlreadyExistsException : BusinessException
    {
        public GroupAlreadyExistsException(string name)
            : base(AhmadBooksBMSDomainErrorCodes.GroupAlreadyExists)
        {
            WithData("name", name);
        }
    }
}