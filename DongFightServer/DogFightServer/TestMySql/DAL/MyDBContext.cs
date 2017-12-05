using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestMySql.Entity;

namespace TestMySql.DAL
{
    public class MyDBContext:DbContext
    {
        //https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/complex-data-model
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
            //在此可对数据库连接字符串做加解密操作
        }

        public DbSet<UserList> UserList { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
