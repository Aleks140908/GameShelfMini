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
    public class CustomerService:ICustomerService
    {
        private readonly GameDbContext db;

        public CustomerService(GameDbContext context)
        {
            this.db = context;
        }

        public List<Customer> GetAll()
        {
            return db.Customers
                .OrderBy(c => c.FullName)
                .ToList();
        }
    }
}
