using Microsoft.AspNetCore.Identity;
using System.Data;

namespace Chinook
{
    public class StartupDbInitializer
    {
        public static void SeedData(ChinookContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            CreateDefaultPlaylist(dbContext);
        }
        private static void CreateDefaultPlaylist(ChinookContext dbContext)
        {
            if (!dbContext.Playlists.Where(p=>p.Name == "My favorite tracks").Any())
            {
                dbContext.Playlists.Add(new Models.Playlist { Name = "My favorite tracks" });
                dbContext.SaveChanges();
            }
        }
    }
}
