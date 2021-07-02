using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Martial.Models
{
    public partial class Albums
    {
        public Albums()
        {
            Pictures = new HashSet<Pictures>();
        }

        public int Id { get; set; }
        
        [Required(ErrorMessage ="Fill out Name fileds")]
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<Pictures> Pictures { get; set; }
    }
}
