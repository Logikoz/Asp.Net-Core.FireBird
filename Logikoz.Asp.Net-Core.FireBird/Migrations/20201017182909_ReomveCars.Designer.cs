﻿// <auto-generated />
using System;
using FireBird.API.Data;
using FirebirdSql.EntityFrameworkCore.Firebird.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FireBird.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201017182909_ReomveCars")]
    partial class ReomveCars
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Fb:ValueGenerationStrategy", FbValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 31);

            modelBuilder.Entity("FireBird.API.Models.PersonModel", b =>
                {
                    b.Property<Guid>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("CHAR(16) CHARACTER SET OCTETS");

                    b.Property<DateTime?>("BirthDate")
                        .IsRequired()
                        .HasColumnType("TIMESTAMP");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("VARCHAR(11)")
                        .HasMaxLength(11);

                    b.Property<double>("Height")
                        .HasColumnType("DOUBLE PRECISION");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("BLOB SUB_TYPE TEXT");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });
#pragma warning restore 612, 618
        }
    }
}
