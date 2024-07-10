﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyData;

#nullable disable

namespace MyData.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyClass.Asi", b =>
                {
                    b.Property<int>("AsiID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AsiID"));

                    b.Property<string>("AsiAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AsiTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("HayvanID")
                        .HasColumnType("int");

                    b.Property<string>("Notlar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SonrakiAsiTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("AsiID");

                    b.HasIndex("HayvanID");

                    b.ToTable("Asilar", "security");
                });

            modelBuilder.Entity("MyClass.Bakim", b =>
                {
                    b.Property<int>("BakimID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BakimID"));

                    b.Property<DateTime>("BakimTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("BakimTipi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HayvanID")
                        .HasColumnType("int");

                    b.Property<string>("Notlar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SonrakiBakimTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("BakimID");

                    b.HasIndex("HayvanID");

                    b.ToTable("Bakimlar", "security");
                });

            modelBuilder.Entity("MyClass.Cins", b =>
                {
                    b.Property<int>("CinsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CinsId"));

                    b.Property<string>("Isim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TurId")
                        .HasColumnType("int");

                    b.HasKey("CinsId");

                    b.HasIndex("TurId");

                    b.ToTable("Cinsler", "security");
                });

            modelBuilder.Entity("MyClass.Hayvan", b =>
                {
                    b.Property<int>("HayvanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HayvanId"));

                    b.Property<int?>("CinsId")
                        .HasColumnType("int");

                    b.Property<string>("Cinsiyet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Isim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OlumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Resim1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resim2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resim3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TurId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Yas")
                        .HasColumnType("int");

                    b.HasKey("HayvanId");

                    b.HasIndex("CinsId");

                    b.HasIndex("TurId");

                    b.HasIndex("UserId");

                    b.ToTable("Hayvanlar", "security");
                });

            modelBuilder.Entity("MyClass.Iliski", b =>
                {
                    b.Property<int>("IliskiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IliskiId"));

                    b.Property<int>("Hayvan1Id")
                        .HasColumnType("int");

                    b.Property<int>("Hayvan2Id")
                        .HasColumnType("int");

                    b.Property<int>("IliskiTuru")
                        .HasColumnType("int");

                    b.HasKey("IliskiId");

                    b.HasIndex("Hayvan1Id");

                    b.HasIndex("Hayvan2Id");

                    b.ToTable("Iliskiler", "security");
                });

            modelBuilder.Entity("MyClass.Tur", b =>
                {
                    b.Property<int>("TurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TurId"));

                    b.Property<string>("Isim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TurId");

                    b.ToTable("Turler", "security");
                });

            modelBuilder.Entity("MyClass.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LasttName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<byte[]>("ProfileImage")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("normalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("normalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User", "security");
                });

            modelBuilder.Entity("MyClass.Asi", b =>
                {
                    b.HasOne("MyClass.Hayvan", "Hayvan")
                        .WithMany("Asilar")
                        .HasForeignKey("HayvanID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Hayvan");
                });

            modelBuilder.Entity("MyClass.Bakim", b =>
                {
                    b.HasOne("MyClass.Hayvan", "Hayvan")
                        .WithMany("Bakimlar")
                        .HasForeignKey("HayvanID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Hayvan");
                });

            modelBuilder.Entity("MyClass.Cins", b =>
                {
                    b.HasOne("MyClass.Tur", "Tur")
                        .WithMany("Cinsler")
                        .HasForeignKey("TurId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Tur");
                });

            modelBuilder.Entity("MyClass.Hayvan", b =>
                {
                    b.HasOne("MyClass.Cins", "Cins")
                        .WithMany("Hayvanlar")
                        .HasForeignKey("CinsId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MyClass.Tur", "Tur")
                        .WithMany("Hayvanlar")
                        .HasForeignKey("TurId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MyClass.User", "User")
                        .WithMany("hayvans")
                        .HasForeignKey("UserId");

                    b.Navigation("Cins");

                    b.Navigation("Tur");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyClass.Iliski", b =>
                {
                    b.HasOne("MyClass.Hayvan", "Hayvan1")
                        .WithMany()
                        .HasForeignKey("Hayvan1Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MyClass.Hayvan", "Hayvan2")
                        .WithMany()
                        .HasForeignKey("Hayvan2Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Hayvan1");

                    b.Navigation("Hayvan2");
                });

            modelBuilder.Entity("MyClass.Cins", b =>
                {
                    b.Navigation("Hayvanlar");
                });

            modelBuilder.Entity("MyClass.Hayvan", b =>
                {
                    b.Navigation("Asilar");

                    b.Navigation("Bakimlar");
                });

            modelBuilder.Entity("MyClass.Tur", b =>
                {
                    b.Navigation("Cinsler");

                    b.Navigation("Hayvanlar");
                });

            modelBuilder.Entity("MyClass.User", b =>
                {
                    b.Navigation("hayvans");
                });
#pragma warning restore 612, 618
        }
    }
}