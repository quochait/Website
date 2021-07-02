using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace demo.Areas.Admin.Models
{
    public partial interface IAclSupportedModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets identifiers of the selected customer roles
        /// </summary>
        IList<int> SelectedCustomerRoleIds { get; set; }

        /// <summary>
        /// Gets or sets items for the all available customer roles
        /// </summary>
        IList<SelectListItem> AvailableCustomerRoles { get; set; }

        #endregion
    }
}