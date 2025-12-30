namespace Museek.Domain
{
    public class Playlist : BaseDomainModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Cover_Image { get; set; }
        public string UserId { get; set; } = default!;
        public bool IsCurated { get; set; } = false;
        public bool IsPublic { get; set; } = false;
        public string? CuratedCategory { get; set; }
    }
}
