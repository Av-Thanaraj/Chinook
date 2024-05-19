using Chinook.Models;

namespace Chinook.Interface
{
    public interface IPlaylistService
    {
        Task CreateAsync(Playlist playlist);
        Task UpdateAsync(Playlist playlist);
        Task DeleteAsync(Playlist playlist);
        Task<Playlist> GetPlaylistByNameAsync(string name);
        Task<List<Playlist>> GetPlaylistsByUserIdAsync(string userId);
    }
}
