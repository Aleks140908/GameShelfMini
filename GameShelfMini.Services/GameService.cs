using GameShelfMini.Data;
using GameShelfMini.Data.Entities;
using GameShelfMini.Data.Enums;
using GameShelfMini.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShelfMini.Services
{
    public class GameService:IGameService
    {
        private readonly GameDbContext db;

        public GameService(GameDbContext context)
        {
            db = context;
        }
        public async Task Create(string title, string developer, Platform platform, Genre genre, int releaseYear)
        {
            var dev = await db.Developers.FirstOrDefaultAsync(d => d.Name == developer);

            if (dev is null)
            {
                dev = new Developer{DeveloperId = Guid.NewGuid(), Name = developer};
                db.Developers.Add(dev);
            }

            var game = new Game
            {
                GameId = Guid.NewGuid(),
                Title = title,
                DeveloperId = dev.DeveloperId,
                Platform = platform,
                Genre = genre,
                ReleaseYear = releaseYear
            };
            game.GameDevelopers.Add(new GameDeveloper
            {
                Game = game,
                Developer = dev
            });

                db.Games.Add(game);
            await db.SaveChangesAsync();
        }

        public Task<List<Game>> GetAll()
        {
            return db.Games
                .Include(g => g.GameDevelopers)
                    .ThenInclude(gd => gd.Developer)
                .OrderBy(g => g.Title)
                .ToListAsync();
        }
    }
}
