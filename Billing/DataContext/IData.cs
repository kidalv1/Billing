using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext
{
  public interface IData 
  {
    IQueryable<Customer> Customers { get; } 
  }
}
