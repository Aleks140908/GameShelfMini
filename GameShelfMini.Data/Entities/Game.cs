using GameShelfMini.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShelfMini.Data.Entities
{
    public class Game
    {
        public Guid GameId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        public Platform Platform { get; set; }

        public Genre Genre { get; set; }

        public int ReleaseYear { get; set; }

        public ICollection<GameDeveloper> GameDevelopers { get; set; }= new List<GameDeveloper>();
    }
}
