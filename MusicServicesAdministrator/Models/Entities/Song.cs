namespace MusicServicesAdministrator.Models.Entities
{
    public class Song
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public List<Author> Authors{ get; } = [];
        public List<Playlist> Playlists { get; } = [];
    }
}
// https://learn.microsoft.com/en-us/ef/core/modeling/relationships/many-to-many