namespace MusicServicesAdministrator.Models.Entities
{
    public class Playlist
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? PlayListId { get; set; }
        public Platform Platform { get; set; } = null!;
    }
}
