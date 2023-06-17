﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SeakerSop;

#nullable disable

namespace SeakerSop.Migrations.SqlServerMigrations
{
    [DbContext(typeof(DbPayContext))]
    [Migration("20230603172144_AddPropertyBalance")]
    partial class AddPropertyBalance
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SeakerSop.Models.RequisitesUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<int>("CVCode")
                        .HasColumnType("int");

                    b.Property<long>("CardNumber")
                        .HasColumnType("bigint");

                    b.Property<int>("Date")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RequisitesUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
