using LargeScaleAccountingSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LargeScaleAccountingSystemAPI.Data
{
    public class AccountingSystemDBContext: DbContext
    {

        public AccountingSystemDBContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<ClientAccount> ClientAccounts { get; set; }
        public DbSet<GLAccount> GLAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


    }
}
