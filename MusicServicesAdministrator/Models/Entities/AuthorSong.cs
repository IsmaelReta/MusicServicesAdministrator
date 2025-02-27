namespace MusicServicesAdministrator.Models.Entities
{
    public class AuthorSong
    {
        public Guid Id { get; set; }
        public Guid SongId { get; set; }
        public Guid AuthorId { get; set; }
        public Song Song { get; set; } = null!;
        public Author Author { get; set; } = null!;
    }
}
