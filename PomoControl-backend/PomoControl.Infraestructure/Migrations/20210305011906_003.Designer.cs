﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PomoControl.Infraestructure.Context;

namespace PomoControl.Infraestructure.Migrations
{
    [DbContext(typeof(PomoContext))]
    [Migration("20210305011906_003")]
    partial class _003
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PomoControl.Domain.Scope", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("VARCHAR(500)");

                    b.Property<bool>("Friday")
                        .HasColumnType("bit");

                    b.Property<int>("IntervalSeconds")
                        .HasColumnType("int");

                    b.Property<bool>("Monday")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(75)");

                    b.Property<bool>("Saturday")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Steps")
                        .HasColumnType("int");

                    b.Property<bool>("Sunday")
                        .HasColumnType("bit");

                    b.Property<bool>("Thursday")
                        .HasColumnType("bit");

                    b.Property<bool>("Tuesday")
                        .HasColumnType("bit");

                    b.Property<int>("UserCode")
                        .HasColumnType("int");

                    b.Property<bool>("Wednesday")
                        .HasColumnType("bit");

                    b.Property<int>("WorkSeconds")
                        .HasColumnType("int");

                    b.HasKey("Code");

                    b.ToTable("Scope");
                });

            modelBuilder.Entity("PomoControl.Domain.ScopeItem", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Commentary")
                        .HasColumnType("VARCHAR(500)");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<int>("ScopeCode")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Type")
                        .HasColumnType("TINYINT");

                    b.HasKey("Code");

                    b.HasIndex("ScopeCode");

                    b.ToTable("ScopeItems");
                });

            modelBuilder.Entity("PomoControl.Domain.User", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("BIT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(75)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(500)");

                    b.Property<string>("PasswordVerify")
                        .IsRequired()
                        .HasColumnType("VARCHAR(500)");

                    b.HasKey("Code");

                    b.ToTable("User");
                });

            modelBuilder.Entity("PomoControl.Domain.ScopeItem", b =>
                {
                    b.HasOne("PomoControl.Domain.Scope", "Scope")
                        .WithMany("ScopeItems")
                        .HasForeignKey("ScopeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Scope");
                });

            modelBuilder.Entity("PomoControl.Domain.Scope", b =>
                {
                    b.Navigation("ScopeItems");
                });
#pragma warning restore 612, 618
        }
    }
}
