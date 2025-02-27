namespace MusicServicesAdministrator.Models.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        public required string FullName { get; set; }
        public List<Song> Songs { get; } = [];
        public List<AuthorSong> AuthorSongs { get; } = [];
    }
}
