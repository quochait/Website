using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace demo.Areas.Admin.Models.Customers
{
    public partial interface ICustomerModelFactory
    {
        List<IdentityUser> PrepareCustomerList();
    }
}
