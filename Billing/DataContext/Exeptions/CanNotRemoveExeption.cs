using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Exeptions
{
  public class CanNotRemoveExeption : Exception
  {
    public CanNotRemoveExeption() : base("You can not remove this invoice")
    {
        
    }
  }
}
