using System.Collections.Generic;
using System.Linq;
using demo.Data;
using Microsoft.AspNetCore.Identity;

namespace demo.Areas.Admin.Models.Customers
{
    public class CustomerModelFactory : ICustomerModelFactory
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CustomerModelFactory(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public virtual List<IdentityUser> PrepareCustomerList()
        {
            var customers = _applicationDbContext.Users.ToList();
            return customers;
        }
    }
}
