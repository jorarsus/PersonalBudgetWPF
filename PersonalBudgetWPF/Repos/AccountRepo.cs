using PersonalBudgetWPF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBudgetWPF.Repos
{
    class AccountRepo: BaseRepo<Account>, IRepo<Account>
    {
        public AccountRepo()
        {
            Table = Context.Accounts;
        }

        public int Delete(int id)
        {
            Context.Entry(new Account() { Id = id }).State = System.Data.Entity.EntityState.Deleted;
            return SaveChanges();
        }

        public List<String> GetAllConcepts()
        {
            var query = from account in Table
                        select account.Concept;
            return query.ToList();
        }
    }
}
