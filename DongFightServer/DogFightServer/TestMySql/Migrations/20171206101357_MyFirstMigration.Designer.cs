﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using TestMySql.DAL;

namespace TestMySql.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20171206101357_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("TestMySql.Entity.UserList", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreteTime");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("ReMark")
                        .HasMaxLength(100);

                    b.Property<DateTime>("RowVersion")
                        .IsConcurrencyToken();

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("UserList");
                });
#pragma warning restore 612, 618
        }
    }
}
