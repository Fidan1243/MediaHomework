using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Admin
{
    class Admin
    {
        public int Id { get; private set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Post.Post[] Posts { get; set; }
        public Notification.Notification[] Notifications { get; set; }
        public int PostCount { get; private set; } = 0;
        public int NotificationCount { get; private set; } = 0;
        public static int myId = 0;

        

        public Admin()
        {
            myId++;
            Id = myId;
        }
        public void addPost(Post.Post post)
        {
            var newPost = new Post.Post[PostCount + 1];
            for (int i = 0; i < PostCount; i++)
            {
                newPost[i] = Posts[i];
            }
            newPost[PostCount] = post;
            PostCount++;
            Posts = newPost;
        }
        public void addNotification(ref Notification.Notification notification)
        {
            var newNotification = new Notification.Notification[NotificationCount + 1];
            for (int i = 0; i < PostCount; i++)
            {
                newNotification[i] = Notifications[i];
            }
            newNotification[PostCount] = notification;
            NotificationCount++;

            Notifications = newNotification;
        }

        public void ShowNotifications()
        {
            Console.Clear();
            foreach (var item in Notifications)
            {
                item.Show();
            }
            Notifications = null;
            NotificationCount = 0;
        }
        public void ShowPosts()
        {
            Console.Clear();
            foreach (var item in Posts)
            {
                item.Show();
            }
        }
    }
}
