using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingTechniques.Mocks
{
    public interface IEmailSender
    {
        public void SendEmail(string to, string subject, string body);
    }
}
