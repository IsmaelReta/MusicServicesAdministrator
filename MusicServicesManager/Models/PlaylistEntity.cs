namespace MusicServicesManager.Models
{
    public class Playlist
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? PlayListPlatformId { get; set; }
        public Platform Platform { get; set; } = null!;
        public List<Song> Songs { get; } = [];
    }
}
