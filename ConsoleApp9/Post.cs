using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post
{
    class Post
    {
        public int Id { get; private set; }
        public string Content { get; set; }
        public DateTime CreatingDate { get; set; }
        public int ViewCount { get; set; } = 0;
        public int LikeCount { get; set; } = 0;
        public static int myId = 0;

        public Post()
        {
            myId++;
            Id = myId;
        }
        public void Show()
        {
            Console.WriteLine("+++++++++++++++++++++++++++++");
            Console.WriteLine($"Id : {Id}");
            Console.WriteLine($"The content : {Content}");
            Console.WriteLine($"Notification date : {CreatingDate}");
            Console.WriteLine($"View Count : {ViewCount}");
            Console.WriteLine($"Like Count : {LikeCount}");
        }
    }
}
