using GameShelfMini.Data;
using GameShelfMini.Data.Entities;
using GameShelfMini.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShelfMini.Services
{
    public class DeveloperService:IDeveloperService
    {
        private readonly GameDbContext db;
        public DeveloperService(GameDbContext context)
        {
            this.db = context;
        }

        public List<Developer> GetAll()
        {
            return db.Developers
                .OrderBy(d => d.Name)
                .ToList();
        }
    }
}
