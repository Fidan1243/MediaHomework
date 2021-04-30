using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace main
{
    class Program
    {

        static void Main(string[] args)
        {
            Starter.Starter starter = new Starter.Starter();
            starter.Start();
        }
    }
}
