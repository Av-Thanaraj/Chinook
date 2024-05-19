using Chinook.Models;

namespace Chinook.Interface
{
    public interface IUserPlaylistService
    {
        Task<UserPlaylist> CreateAsync(UserPlaylist userPlaylist);
        Task UpdateAsync(UserPlaylist userPlaylist);
        Task<UserPlaylist> GetByUserIdPlaylistIdAsync(string userId, long playlistId);
    }
}
