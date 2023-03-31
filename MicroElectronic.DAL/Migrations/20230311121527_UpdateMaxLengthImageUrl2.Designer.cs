﻿// <auto-generated />
using MicroElectronic.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MicroElectronic.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230311121527_UpdateMaxLengthImageUrl2")]
    partial class UpdateMaxLengthImageUrl2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MicroElectronic.Domain.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "/lib/images/crystal.png",
                            Name = "Кристальное производство"
                        });
                });

            modelBuilder.Entity("MicroElectronic.Domain.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BodyMaterial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FullDescription")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)");

                    b.Property<string>("GuaranteePeriod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Power")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkingArea")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Equipments", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BodyMaterial = "Изготовлен из нержавеющей стали",
                            CategoryId = 1,
                            Description = "Полуавтоматическая установка нанесения покрытий методом центрифугирования",
                            FullDescription = "Полуавтоматическая автономная установка UNIXX S 760+ предназначена для нанесения покрытий методом центрифугирования на крупноразмерные подложки. В установке применяется технология CCP (Covered Chuck Processor – центрифугирование с закрытой крышкой), позволяющей наносить покрытия с превосходной однородностью и повторяемостью.\r\nПрограммное обеспечение установки имеет дружественный пользовательский интерфейс со всеми необходимыми функциями, такими как создание и редактирование рабочих программ, администрирование пользователей, отслеживание состояния системы. Подвод необходимых сред (воздух, азот, вакуум) выполняется подключением через быстроразъемные соединения и управляется программным обеспечением.",
                            GuaranteePeriod = "2 года",
                            ImageUrl = "/lib/images/equipments/poluavtomaticheskaya_ustanovka_naneseniya_pokrytij_metodom_centrifugirovaniya_unixx_s760.jpg",
                            Name = "UNIXX S760+",
                            Power = "400 (208) В, 3 фазы, 50-60 Гц",
                            Price = 450000m,
                            Size = "1250 х 1250/1510 х 2000/2500 мм",
                            WorkingArea = "500 x 750 мм"
                        });
                });

            modelBuilder.Entity("MicroElectronic.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Login = "admin",
                            Name = "Дмитрий",
                            Password = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
                            Position = "Developer",
                            Role = 2,
                            Surname = "Зотов"
                        });
                });

            modelBuilder.Entity("MicroElectronic.Domain.Models.Equipment", b =>
                {
                    b.HasOne("MicroElectronic.Domain.Models.Category", "Category")
                        .WithMany("Equipments")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MicroElectronic.Domain.Models.Category", b =>
                {
                    b.Navigation("Equipments");
                });
#pragma warning restore 612, 618
        }
    }
}
