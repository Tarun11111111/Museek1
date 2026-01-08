using System;

namespace Museek.Domain
{
    public class Album : BaseDomainModel
    {
        public string? Title { get; set; }
        public DateTime? ReleasedDate { get; set; }
        public string? Description { get; set; }
        public string? Cover_Image { get; set; }

        public int ArtistId { get; set; }
    }
}
