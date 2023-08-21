using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace AhmadBooks.BMS.Pages;

public class Index_Tests : BMSWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
