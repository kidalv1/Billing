using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Repositories
{
  class UserRepo
  {
    private Data data = new Data();

    public void addUser(User user)
    {
      data.Users.Add(user);
      data.SaveChanges();
    }
    public User findUser(int id)
    {
      return data.Users.Find(id);
    }
    public void removeUser(User user)
    {
      data.Users.Remove(user);
    }
  }
}
