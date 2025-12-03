using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Museek.Data;

namespace Museek.Data
{
    public class MuseekContext(DbContextOptions<MuseekContext> options) : IdentityDbContext<MuseekUser>(options)
    {


        public DbSet<Museek.Domain.Admin> Admin { get; set; } = default!;
        public DbSet<Museek.Domain.Album> Album { get; set; } = default!;
        public DbSet<Museek.Domain.Artist> Artist { get; set; } = default!;
        public DbSet<Museek.Domain.ArtistSong> ArtistSong { get; set; } = default!;
        public DbSet<Museek.Domain.Playlist> Playlist { get; set; } = default!;
        public DbSet<Museek.Domain.PlaylistSong> PlaylistSong { get; set; } = default!;
        public DbSet<Museek.Domain.Rating> Rating { get; set; } = default!;
        public DbSet<Museek.Domain.Song> Song { get; set; } = default!;
        public DbSet<Museek.Domain.User> User { get; set; } = default!;
        public DbSet<Museek.Domain.UserSong> UserSong { get; set; } = default!;

    }
}
