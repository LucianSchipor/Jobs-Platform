﻿// <auto-generated />
using System;
using Jobs_Platform.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobsPlatform.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Jobs_Platform.Data.Entities.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("industry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("requirementsJob_Id")
                        .HasColumnType("int");

                    b.Property<int>("salary")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("requirementsJob_Id");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Jobs_Platform.Data.Entities.Requirements", b =>
                {
                    b.Property<int>("Job_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Job_Id"));

                    b.HasKey("Job_Id");

                    b.ToTable("Requirements");
                });

            modelBuilder.Entity("Jobs_Platform.Data.Entities.Job", b =>
                {
                    b.HasOne("Jobs_Platform.Data.Entities.Requirements", "requirements")
                        .WithMany()
                        .HasForeignKey("requirementsJob_Id");

                    b.Navigation("requirements");
                });
#pragma warning restore 612, 618
        }
    }
}
