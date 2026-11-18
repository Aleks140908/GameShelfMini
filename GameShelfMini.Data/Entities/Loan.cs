using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShelfMini.Data.Entities
{
    public class Loan
    {
        [Key]
        public Guid LoanId { get; set; }

        public Guid GameId { get; set; }

        public Guid CustomerId { get; set; }

        public DateTime LoanDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public Game Game { get; set; } = null!;

        public Customer Customer { get; set; } = null!;
    }
}
