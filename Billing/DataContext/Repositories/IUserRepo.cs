using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Repositories
{
  public interface IUserRepo : IDisposable
  {
    IEnumerable<User> GetStudents();
    User GetStudentByID(int userId);
    void InsertStudent(User user);
    void DeleteStudent(int userId);
    void UpdateStudent(User user);
    void Save();
  }
}
