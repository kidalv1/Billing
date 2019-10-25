using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Exeptions
{
  public class AllFieldReaquiredExeption : Exception
  {
    public AllFieldReaquiredExeption() : base("Fill all field")
    {

    }
  }
}
