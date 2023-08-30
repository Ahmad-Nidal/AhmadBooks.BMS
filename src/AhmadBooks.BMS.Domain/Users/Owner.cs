using AhmadBooks.BMS.Books;
using AhmadBooks.BMS.Groups;
using System.Collections.Generic;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace AhmadBooks.BMS.Users
{
    public class Owner : IdentityUser, IUser
    {
        public List<Book> Books { get; set; }
        public List<Group> Groups { get; set; }
    }
}
