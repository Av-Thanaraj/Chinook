using Chinook.Interface;
using Chinook.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Service
{
    public class UserPlaylistService : IUserPlaylistService
    {
        private IDbContextFactory<ChinookContext> DbFactory { get; set; }
        public UserPlaylistService(IDbContextFactory<ChinookContext> _DbFactory) { DbFactory = _DbFactory; }
        public async Task<UserPlaylist> CreateAsync(UserPlaylist userPlaylist)
        {
            try
            {
                var dbContext = await DbFactory.CreateDbContextAsync();
                var createdEntity = dbContext.UserPlaylists.Add(userPlaylist);
                dbContext.SaveChanges();
                return createdEntity.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task UpdateAsync(UserPlaylist userPlaylist)
        {
            try
            {
                var dbContext = await DbFactory.CreateDbContextAsync();
                dbContext.UserPlaylists.Update(userPlaylist);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<UserPlaylist> GetByUserIdPlaylistIdAsync(string userId, long playlistId)
        {
            try
            {
                var dbContext = await DbFactory.CreateDbContextAsync();
                var userPlaylist = await dbContext.UserPlaylists.Where(c => c.UserId == userId && c.PlaylistId == playlistId).FirstOrDefaultAsync();
                return userPlaylist;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
