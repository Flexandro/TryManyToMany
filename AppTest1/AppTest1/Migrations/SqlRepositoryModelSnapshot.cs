﻿// <auto-generated />
using AppTest1.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppTest1.Migrations
{
    [DbContext(typeof(SqlRepository))]
    partial class SqlRepositoryModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppTest1.Models.Men", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Men");
                });

            modelBuilder.Entity("AppTest1.Models.MormonsPartner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ManId");

                    b.Property<int>("WomanId");

                    b.HasKey("Id");

                    b.HasIndex("ManId");

                    b.HasIndex("WomanId");

                    b.ToTable("Partners");
                });

            modelBuilder.Entity("AppTest1.Models.Women", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Women");
                });

            modelBuilder.Entity("AppTest1.Models.MormonsPartner", b =>
                {
                    b.HasOne("AppTest1.Models.Men", "Man")
                        .WithMany()
                        .HasForeignKey("ManId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AppTest1.Models.Women", "Woman")
                        .WithMany("Partners")
                        .HasForeignKey("WomanId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
