using MysqlConnect1.models;
using System;

namespace MysqlConnect1
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            var db = new MyDbContext();

            User user = new User()
            {
                userid = "3",
                username = "admin",
                useraddress = "부천",
                tes = "테슽"
            };
            db.Users.Add(user);

            TestUser testUser = new TestUser()
            {
                username = "admin",
                useraddress = "부천",
                tes = "테슽"
            };
            db.TestUsers.Add(testUser);

            db.SaveChanges();

            Console.WriteLine($"{user.userid} 번의 유저가 생성되었습니다.");
            Console.WriteLine($"{testUser} 가 생성되어졌습니다");
            Console.ReadLine();
        }
    }
}