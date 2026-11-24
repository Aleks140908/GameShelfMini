using GameShelfMini.Data.Entities;
using GameShelfMini.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShelfMini.Services.Contracts
{
    public interface IGameService
    {
        Task<List<Game>> GetAll();
        Task Create(string title, string developer, Platform platform, Genre genre, int releaseYear);
    }
}
