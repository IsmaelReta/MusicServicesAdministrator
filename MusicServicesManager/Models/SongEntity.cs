﻿namespace MusicServicesManager.Models
{
    public class Song
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public List<Author> Authors { get; } = [];
        public List<Playlist> Playlists { get; } = [];
    }
}
