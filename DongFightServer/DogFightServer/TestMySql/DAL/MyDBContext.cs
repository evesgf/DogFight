using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestMySql.Entity;

namespace TestMySql.DAL
{
    /// <summary>
    /// 生成数据库架构：Add-Migration MyFirstMigration
    /// 开启自动迁移：Enable-Migrations -EnableAutomaticMigrations
    /// 更新数据库：Update-Database
    /// </summary>
    public class MyDBContext:DbContext
    {
        public MyDBContext()
        {
        }

        //https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/complex-data-model
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
            //在此可对数据库连接字符串做加解密操作
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql("Data Source=localhost;port=3306;Initial Catalog=testmysql;uid=root;password=123456;Charset=utf8");
        }

        public DbSet<UserList> UserList { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
