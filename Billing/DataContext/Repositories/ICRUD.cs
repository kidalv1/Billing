using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Repositories
{
  public interface ICRUD <TEntity> where TEntity : class
  {
    void Add(TEntity t);
    TEntity FindById(int id);
    void Edit(TEntity t);
    List<TEntity> GetAll();
    void Remove(TEntity t);
  }
}
