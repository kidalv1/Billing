using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Exeptions
{
  public class NotExistExeption : Exception
  {
    public NotExistExeption() :base("this customer is not exist")
    {
    }
  }
}
