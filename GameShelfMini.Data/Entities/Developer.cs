using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShelfMini.Data.Entities
{
    public class Developer
    {
        public Guid DeveloperId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public ICollection<GameDeveloper> GameDevelopers { get; set; } = new List<GameDeveloper>();
    }
}
