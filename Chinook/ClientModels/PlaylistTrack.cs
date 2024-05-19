namespace Chinook.ClientModels;

public class PlaylistTrack
{
    public long TrackId { get; set; }
    public string TrackName { get; set; }
    public string AlbumTitle { get; set; }
    public string ArtistName { get; set; }
    public byte[] UnitPrice { get; set; } = null!;
    public bool IsFavorite { get; set; }

}