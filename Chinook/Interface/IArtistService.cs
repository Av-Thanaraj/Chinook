using Chinook.Models;

namespace Chinook.Interface
{
    public interface IArtistService
    {
        Task<List<Artist>> GetArtistsAsync();
        Task<List<Artist>> GetArtistsByNameAsync(string search);
    }
}
