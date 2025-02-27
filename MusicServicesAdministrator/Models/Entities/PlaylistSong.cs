namespace MusicServicesAdministrator.Models.Entities
{
    public class PlaylistSong
    {
        public Guid Id { get; set; }
        public Guid SongId { get; set; }
        public Guid PlaylistId { get; set; }
        public Song Song { get; set; } = null!;
        public Playlist Playlist { get; set; } = null!;
    }
}
