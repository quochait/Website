using System;
using System.Collections.Generic;

namespace Martial.Models
{
    public partial class TopSlides
    {
        public TopSlides()
        {
            Pictures = new HashSet<Pictures>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int NumberPictureDisplay { get; set; }

        public virtual ICollection<Pictures> Pictures { get; set; }
    }
}
