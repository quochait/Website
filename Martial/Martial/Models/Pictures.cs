using System;
using System.Collections.Generic;

namespace Martial.Models
{
    public partial class Pictures
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public int? AlbumId { get; set; }
        public int? TopSlidesId { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Albums Album { get; set; }
        public virtual TopSlides TopSlides { get; set; }
    }
}
