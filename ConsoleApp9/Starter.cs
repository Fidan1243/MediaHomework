using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Starter
{

    class Starter
    {
        static string mail;
        static string password;
        static int indexofuser;
        static char Choosing(string choose, Admin.Admin a, User.User[] users)
        {
            Console.Clear();
            if (Convert.ToInt32(choose) == 1)
            {
                Console.Write("Enter mail: ");
                mail = Console.ReadLine();
                Console.Write("Enter password: ");
                password = Console.ReadLine();

                if (mail == a.Email && a.Password == password)
                {
                    a.ShowPosts();

                    Thread.Sleep(1000);
                    Console.Clear();
                    return 'a';
                }
                return 'f';
            }
            else if (Convert.ToInt32(choose) == 2)
            {
                Console.Write("Enter mail: ");
                mail = Console.ReadLine();
                Console.Write("Enter password: ");
                password = Console.ReadLine();
                if (FindUser(users, mail, password) != -1)
                {
                    indexofuser = FindUser(users, mail, password);
                    return 'u';
                }
                else
                {
                    Console.Clear();
                    throw new Exception("Invalid mail or password");
                }
            }
            else
            {
                throw new Exception("Invalid choose");
            }
        }
        static int FindUser(User.User[] users, string mail, string password)
        {
            for (int i = 0; i < users.Length; i++)
            {
                if (users[i].Email == mail)
                {
                    if (users[i].Password == password)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        static int LookForPost(Post.Post[] posts, string id)
        {
            for (int i = 0; i < posts.Length; i++)
            {
                if (Convert.ToInt32(id) == posts[i].Id)
                {
                    return i;
                }
            }
            throw new Exception("Invalid ID");
        }
        static void LookingAround(User.User user, Admin.Admin a)
        {
            Console.Clear();
            Console.WriteLine("1) For View Post");
            Console.WriteLine("2) For Like Post");
            string ch = Console.ReadLine();
            Console.Clear();
            if (Convert.ToInt32(ch) == 1)
            {
                Console.WriteLine("Enter post id:");
                int ab = LookForPost(a.Posts, Console.ReadLine());
                if (ab != -1)
                {
                    Console.Clear();
                    a.Posts[ab].Show();
                    a.SendMail(user.Email, a.Posts, ab, user, "View");
                    Console.Clear();
                }
            }
            else if (Convert.ToInt32(ch) == 2)
            {
                Console.WriteLine("Enter post id:");
                dynamic ab = LookForPost(a.Posts, Console.ReadLine());
                if (ab != -1)
                {
                    a.SendMail(user.Email, a.Posts, ab, user, "Like");
                }
                Console.Clear();
            }
            else
            {
                throw new Exception("Invalid choose!");
            }
        }

        public void Start()
        {
            Admin.Admin admin = new Admin.Admin()
            {
                Username = "Admin123",
                Email = "testm3212@gmail.com",
                Password = "test121416",

            };
            User.User u1 = new User.User()
            {
                Name = "User",
                Surname = "Number 1",
                Email = "blabla@gmail.com",
                Password = "blabla123"
            };
            User.User u2 = new User.User()
            {
                Name = "Sun",
                Surname = "Glasses",
                Email = "hakuna@gmail.com",
                Password = "hakuna123"
            };
            User.User u3 = new User.User()
            {
                Name = "Moon",
                Surname = "Shine",
                Email = "shiny@gmail.com",
                Password = "shine123"
            };
            Post.Post p1 = new Post.Post()
            {
                Content = "Forest Holiday",
                CreatingDate = new DateTime(2017, 2, 25),
                LikeCount = 100,
                ViewCount = 160
            };

            Post.Post p2 = new Post.Post()
            {
                Content = "Snowing woww!",
                CreatingDate = new DateTime(2015, 12, 13),
                LikeCount = 20,
                ViewCount = 22
            };

            Post.Post p3 = new Post.Post()
            {
                Content = "Happy Easter everyone!",
                CreatingDate = new DateTime(2021, 3, 17),
                LikeCount = 2,
                ViewCount = 14
            };

            admin.addPost(p1);
            admin.addPost(p2);
            admin.addPost(p3);

            User.User[] users = new User.User[3] { u1, u2, u3 };
            dynamic a;
            while (true)
            {
                Console.WriteLine("1)Admin");
                Console.WriteLine("2)User");
                try
                {
                    a = Choosing(Console.ReadLine(), admin, users);
                    Console.Clear();
                    if (a == 'u')
                    {
                        while (true)
                        {
                            try
                            {
                                LookingAround(users[indexofuser], admin);
                                break;
                            }
                            catch (Exception ex)
                            { 
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            
        }
    }
}
