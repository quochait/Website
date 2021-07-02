using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Areas.Admin.Models
{
    public partial class BaseEntityModel : BaseModel
    {
        public virtual int Id { get; set; }
    }
}
