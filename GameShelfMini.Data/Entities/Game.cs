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
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public Guid DeveloperId { get; set; }

        public Platform Platform { get; set; }

        public Genre Genre { get; set; }

        public int ReleaseYear { get; set; }
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
        public ICollection<GameDeveloper> GameDevelopers { get; set; }= new List<GameDeveloper>();
    }
}
