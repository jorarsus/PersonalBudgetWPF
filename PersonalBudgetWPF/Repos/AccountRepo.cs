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

        /// <summary>
        /// Gets all Account's concepts
        /// </summary>
        /// <returns>List of String with the concepts</returns>
        public List<String> GetAllConcepts()
        {
            var query = from account in Table
                        select account.Concept;
            return query.ToList();
        }

        /// <summary>
        /// Gets an account with the specified concept
        /// </summary>
        /// <param name="concept">The concept to search</param>
        /// <returns>Account with the specified concept, or null if no Account found</returns>
        public Account GetAccountByConcept(String concept)
        {
            var query = from account in Context.Accounts
                        where account.Concept == concept
                        select account;
            return query.FirstOrDefault();
        }
    }
}
