using System;
using System.Diagnostics;
using TestMySql.DAL;
using TestMySql.Service;

namespace TestMySql
{
    /// <summary>
    /// https://www.cnblogs.com/xiaoliangge/archive/2017/09/19/7543773.html
    /// </summary>
    public class Program
    {
        private static IUserService _userService;

        public Program(IUserService userService)
        {
            _userService = userService;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Console.WriteLine(_userService.Test());

            Stopwatch sw = new Stopwatch();
            sw.Start();

            MyDBContext _context = new MyDBContext();
            //_context.UserList.Add(new UserList
            //{
            //    UserName="admin",
            //    PassWord="123456"
            //});
            //_context.SaveChanges();

            Console.WriteLine(_context.UserList.Find((long)1).UserName);

            sw.Stop();
            TimeSpan ts2 = sw.Elapsed;
            Console.WriteLine("Stopwatch总共花费{0}ms.", ts2.TotalMilliseconds);

            Console.ReadKey(true);
        }
    }
}
