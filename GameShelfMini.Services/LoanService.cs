using GameShelfMini.Data;
using GameShelfMini.Data.Entities;
using GameShelfMini.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShelfMini.Services
{
    public class LoanService: ILoanService
    {
        private readonly GameDbContext db;

        public LoanService(GameDbContext context)
        {
           db = context;
        }

        public List<Loan> GetAll()
        {
            return db.Loans
                .Include(l => l.Game)
                .Include(l => l.Customer)
                .OrderByDescending(l => l.LoanDate)
                .ToList();
        }
    }
}
