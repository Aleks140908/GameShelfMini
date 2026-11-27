using GameShelfMini.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShelfMini.Services.Contracts
{
    public interface ILoanService
    {
        List<Loan> GetAll();
    }
}
