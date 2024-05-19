using Chinook.Interface;
using Chinook.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Service
{
    public class PlaylistService : IPlaylistService
    {
        private IDbContextFactory<ChinookContext> DbFactory { get; set; }
        public PlaylistService(IDbContextFactory<ChinookContext> _DbFactory) { DbFactory = _DbFactory; }
        public async Task CreateAsync(Playlist playlist)
        {
            try
            {
                var dbContext = await DbFactory.CreateDbContextAsync();
                dbContext.Playlists.Add(playlist);
                dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task UpdateAsync(Playlist playlist)
        {
            try
            {
                var dbContext = await DbFactory.CreateDbContextAsync();
                dbContext.Playlists.Update(playlist);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task DeleteAsync(Playlist playlist)
        {
            try
            {
                var dbContext = await DbFactory.CreateDbContextAsync();

                var t = playlist.Tracks.FirstOrDefault();
                var dd = dbContext.Playlists.Include(z => z.Tracks).Where(x => x.PlaylistId == playlist.PlaylistId).FirstOrDefault();
                var dssd = dd.Tracks.Where(d => d.TrackId != t.TrackId).ToList();

                dd.Tracks = dssd;
                dbContext.Playlists.Update(dd);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Playlist> GetPlaylistByNameAsync(string name)
        {
            try
            {
                var dbContext = await DbFactory.CreateDbContextAsync();
                var playList = await dbContext.Playlists.Where(p => p.Name == name).FirstOrDefaultAsync();
                return playList;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Playlist>> GetPlaylistsByUserIdAsync(string userId)
        {
            try
            {
                var dbContext = await DbFactory.CreateDbContextAsync();
                var playLists = await dbContext.Playlists.Where(p => p.UserPlaylists.Select(x => x.UserId).Contains(userId)).ToListAsync();
                return playLists;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
