﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SamuraiApp.Data;

#nullable disable

namespace SamuraiApp.Data.Migrations
{
    [DbContext(typeof(SamuraiContext))]
    [Migration("20220419151536_pedangdanelemennew")]
    partial class pedangdanelemennew
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SamuraiApp.Domain.Battle", b =>
                {
                    b.Property<int>("BattleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BattleId"), 1L, 1);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StarDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BattleId");

                    b.ToTable("Battles");
                });

            modelBuilder.Entity("SamuraiApp.Domain.BattleSamurai", b =>
                {
                    b.Property<int>("BattleId")
                        .HasColumnType("int");

                    b.Property<int>("SamuraiId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateJoined")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("BattleId", "SamuraiId");

                    b.HasIndex("SamuraiId");

                    b.ToTable("BattleSamurai");
                });

            modelBuilder.Entity("SamuraiApp.Domain.Elemen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("elemen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pedangId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("pedangId");

                    b.ToTable("elements");
                });

            modelBuilder.Entity("SamuraiApp.Domain.Horse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SamuraiId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SamuraiId")
                        .IsUnique();

                    b.ToTable("Horses", (string)null);
                });

            modelBuilder.Entity("SamuraiApp.Domain.Pedang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Berat")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SamuraiId")
                        .HasColumnType("int");

                    b.Property<int>("Tahun")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SamuraiId");

                    b.ToTable("pedangs");
                });

            modelBuilder.Entity("SamuraiApp.Domain.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("SamuraiId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SamuraiId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("SamuraiApp.Domain.Samurai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Samurais");
                });

            modelBuilder.Entity("SamuraiApp.Domain.SamuraiBattleStart", b =>
                {
                    b.Property<string>("EarliestBattle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumberOfBattles")
                        .HasColumnType("int");

                    b.ToView("SamuraiBattleStats");
                });

            modelBuilder.Entity("SamuraiApp.Domain.BattleSamurai", b =>
                {
                    b.HasOne("SamuraiApp.Domain.Battle", null)
                        .WithMany()
                        .HasForeignKey("BattleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SamuraiApp.Domain.Samurai", null)
                        .WithMany()
                        .HasForeignKey("SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SamuraiApp.Domain.Elemen", b =>
                {
                    b.HasOne("SamuraiApp.Domain.Pedang", "pedang")
                        .WithMany("elemens")
                        .HasForeignKey("pedangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pedang");
                });

            modelBuilder.Entity("SamuraiApp.Domain.Horse", b =>
                {
                    b.HasOne("SamuraiApp.Domain.Samurai", null)
                        .WithOne("Horse")
                        .HasForeignKey("SamuraiApp.Domain.Horse", "SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SamuraiApp.Domain.Pedang", b =>
                {
                    b.HasOne("SamuraiApp.Domain.Samurai", "Samurai")
                        .WithMany("Pedangs")
                        .HasForeignKey("SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Samurai");
                });

            modelBuilder.Entity("SamuraiApp.Domain.Quote", b =>
                {
                    b.HasOne("SamuraiApp.Domain.Samurai", "Samurai")
                        .WithMany("Quotes")
                        .HasForeignKey("SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Samurai");
                });

            modelBuilder.Entity("SamuraiApp.Domain.Pedang", b =>
                {
                    b.Navigation("elemens");
                });

            modelBuilder.Entity("SamuraiApp.Domain.Samurai", b =>
                {
                    b.Navigation("Horse")
                        .IsRequired();

                    b.Navigation("Pedangs");

                    b.Navigation("Quotes");
                });
#pragma warning restore 612, 618
        }
    }
}
