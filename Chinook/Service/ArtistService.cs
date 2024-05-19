using Chinook.Interface;
using Chinook.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Service
{
    public class ArtistService : IArtistService
    {
        private IDbContextFactory<ChinookContext> DbFactory { get; set; }
        public ArtistService(IDbContextFactory<ChinookContext> _DbFactory) { DbFactory = _DbFactory;  }
        public async Task<List<Artist>> GetArtistsAsync()
        {
            try
            {
                var dbContext = await DbFactory.CreateDbContextAsync();
                return dbContext.Artists.Include(a => a.Albums).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Artist>> GetArtistsByNameAsync(string search)
        {
            try
            {
                var dbContext = await DbFactory.CreateDbContextAsync();
                return dbContext.Artists.Include(a => a.Albums).Where(a => a.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
