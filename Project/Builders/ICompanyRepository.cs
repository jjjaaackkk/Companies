using Companies.Models;
using Microsoft.EntityFrameworkCore;

namespace Companies.Builders
{
    public class ICompanyBuilder
    {
        public void GetCompanies(IApplicationBuilder appBuilder)
        {
            appBuilder.Run(async context => await context.Response.WriteAsync("Index Page"));
        }
    }
}
