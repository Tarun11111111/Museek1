namespace Museek.Domain
{
    public class PlaylistSong : BaseDomainModel
    {
        public int SongId { get; set; }
        public int PlaylistId { get; set; }
    }
}