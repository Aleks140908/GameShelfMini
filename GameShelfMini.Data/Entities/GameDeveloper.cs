using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShelfMini.Data.Entities
{
    public class GameDeveloper
    {
        public Guid GameId { get; set; }
        public Game Game { get; set; } = null!;
        public Guid DeveloperId { get; set; }
        public Developer Developer { get; set; } = null!;
    }
}
