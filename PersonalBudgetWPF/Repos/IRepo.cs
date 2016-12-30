using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBudgetWPF.Repos
{
    interface IRepo<T>
    {
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
        int Delete(int id);
        T GetOne(int? id);
        List<T> GetAll();
    }
}
