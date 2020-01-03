using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Billing.BLL
{
  public class EmailConfig
  {
    public EmailConfig()
    {

    }
    public void SendEmail(string to , string subject , string body)
    {
      MailMessage o = new MailMessage("VMProjectAp2019@hotmail.com", to, subject, body);
      NetworkCredential netCred = new NetworkCredential("VMProjectAp2019@hotmail.com", "MVProjectAp2019");
      SmtpClient smtpobj = new SmtpClient("smtp.live.com", 587);
      smtpobj.EnableSsl = true;
      smtpobj.Credentials = netCred;
      smtpobj.Send(o);
    }
  }
}
