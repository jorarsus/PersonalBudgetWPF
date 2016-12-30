using PersonalBudgetWPF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBudgetWPF.Repos
{
    class TransactionRepo: BaseRepo<Transaction>, IRepo<Transaction>
    {
        public TransactionRepo()
        {
            Table = Context.Transactions;
        }

        public int Delete(int id)
        {
            Context.Entry(new Transaction() { Id = id }).State = System.Data.Entity.EntityState.Deleted;
            return SaveChanges();
        }
    }
}
