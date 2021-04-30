using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

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

        public void SendMail(string mails, Post.Post[] posts, int idp, User.User user, string vl)
        {
            Random r = new Random();
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(mails);
                mail.To.Add(Email);
                mail.Subject = $"You have 1 notification!";
                mail.Body = $"<h1>{user.Name} {vl} your post. The post's content: {posts[idp].Content}</h1>";
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("testm3212@gmail.com", "test121416");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }

        }

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
        public void addNotification(Notification.Notification notification)
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
