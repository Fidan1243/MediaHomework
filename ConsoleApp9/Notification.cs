using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification
{
    class Notification
    {
        public int Id { get; private set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public string FromUser { get; set; }
        public static int myId = 0;

        public Notification()
        {
            myId++;
            Id = myId;
        }

        public void Show()
        {
            Console.WriteLine("+++++++++++++++++++++++++++++");
            Console.WriteLine($"Id : {Id}");
            Console.WriteLine($"The content : {Text}");
            Console.WriteLine($"Notification date : {Time}");
            Console.WriteLine($"The User : {FromUser}");
        }
    }
}
