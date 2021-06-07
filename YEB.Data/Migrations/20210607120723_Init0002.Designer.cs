﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YEB.Data;

namespace YEB.Data.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210607120723_Init0002")]
    partial class Init0002
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("FunctionRole", b =>
                {
                    b.Property<string>("FunctionsId")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("RolesId")
                        .HasColumnType("varchar(30)");

                    b.HasKey("FunctionsId", "RolesId");

                    b.HasIndex("RolesId");

                    b.ToTable("FunctionRole");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<string>("RolesId")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("UsersUsername")
                        .HasColumnType("varchar(30)");

                    b.HasKey("RolesId", "UsersUsername");

                    b.HasIndex("UsersUsername");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("YEB.Entity.Function", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Component")
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Disabled")
                        .HasColumnType("int");

                    b.Property<string>("Icon")
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("KeepAlive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("MenuId")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("OrderBy")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("Function");
                });

            modelBuilder.Entity("YEB.Entity.Menu", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(30)");

                    b.Property<bool>("Disabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Icon")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("OrderBy")
                        .HasColumnType("int");

                    b.Property<string>("ParentMenuId")
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("YEB.Entity.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("YEB.Entity.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Contact")
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(300)");

                    b.Property<string>("PortraitUrl")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Username");

                    b.ToTable("User");
                });

            modelBuilder.Entity("FunctionRole", b =>
                {
                    b.HasOne("YEB.Entity.Function", null)
                        .WithMany()
                        .HasForeignKey("FunctionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YEB.Entity.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("YEB.Entity.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YEB.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUsername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YEB.Entity.Function", b =>
                {
                    b.HasOne("YEB.Entity.Menu", "Menu")
                        .WithMany("Functions")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("YEB.Entity.Menu", b =>
                {
                    b.Navigation("Functions");
                });
#pragma warning restore 612, 618
        }
    }
}