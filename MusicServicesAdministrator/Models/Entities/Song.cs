namespace MusicServicesAdministrator.Models.Entities
{
    public class Song
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public List<SongAuthor> SongAuthors { get; } = [];
        public List<Author> Authors{ get; } = [];
    }
}
