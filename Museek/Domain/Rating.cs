namespace Museek.Domain
{
    public class Rating : BaseDomainModel
    {
        public int Value { get; set; }    // 1..5
        public string? Comment { get; set; }
        public string UserId { get; set; } = default!;
        public int SongId { get; set; }
    }
}
