using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinimalisticTelnet;

namespace mantis_tests
{
    public class JamesHelper : HelperBase
    {
        public JamesHelper(ApplicationManager manager) : base(manager) { }
        public void Add(AccountData account)
        {
            if (Verify(account))
            {
                return;
            }
            TelnetConnection telnet = TelnetConnectionLogin();
            telnet.WriteLine($"adduser {account.Username } { account.Password }");
            Console.Out.WriteLine(telnet.Read());
        }

        public bool Verify(AccountData account)
        {
            TelnetConnection telnet = TelnetConnectionLogin();
            telnet.WriteLine($"verify {account.Username }");
            string str = telnet.Read();
            Console.Out.WriteLine(str);
            return !str.Contains("does not exist");
        }
        public void Delete(AccountData account)
        {
            if (! Verify(account))
            {
                return;
            }
            TelnetConnection telnet = TelnetConnectionLogin();
            telnet.WriteLine($"deluser {account.Username }");
            Console.Out.WriteLine(telnet.Read());
        }
        private TelnetConnection TelnetConnectionLogin()
        {
            TelnetConnection telnet = new TelnetConnection("localhost", 4555);
            Console.Out.WriteLine(telnet.Read());
            telnet.WriteLine("root");
            Console.Out.WriteLine(telnet.Read());
            telnet.WriteLine("root");
            Console.Out.WriteLine(telnet.Read());
            return telnet;
        }
    }
}
