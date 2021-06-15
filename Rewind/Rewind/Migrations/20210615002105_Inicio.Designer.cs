﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rewind.Data;

namespace Rewind.Migrations
{
    [DbContext(typeof(RewindDB))]
    [Migration("20210615002105_Inicio")]
    partial class Inicio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Rewind.Models.Comentarios", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comentario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("Estrelas")
                        .HasColumnType("int");

                    b.Property<int>("SeriesID")
                        .HasColumnType("int");

                    b.Property<int>("UtilizadoresID")
                        .HasColumnType("int");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("SeriesID");

                    b.HasIndex("UtilizadoresID");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("Rewind.Models.Estudios", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Estudio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Estudios");
                });

            modelBuilder.Entity("Rewind.Models.Series", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("Episodios")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstudioID")
                        .HasColumnType("int");

                    b.Property<string>("Imagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sinopse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("EstudioID");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("Rewind.Models.Utilizadores", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Utilizador")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Utilizadores");
                });

            modelBuilder.Entity("Rewind.Models.Comentarios", b =>
                {
                    b.HasOne("Rewind.Models.Series", "Serie")
                        .WithMany("ListaDeComentarios")
                        .HasForeignKey("SeriesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rewind.Models.Utilizadores", "Utilizador")
                        .WithMany("ListaDeComentarios")
                        .HasForeignKey("UtilizadoresID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Serie");

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("Rewind.Models.Series", b =>
                {
                    b.HasOne("Rewind.Models.Estudios", "Estudio")
                        .WithMany("ListaDeSeries")
                        .HasForeignKey("EstudioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estudio");
                });

            modelBuilder.Entity("Rewind.Models.Estudios", b =>
                {
                    b.Navigation("ListaDeSeries");
                });

            modelBuilder.Entity("Rewind.Models.Series", b =>
                {
                    b.Navigation("ListaDeComentarios");
                });

            modelBuilder.Entity("Rewind.Models.Utilizadores", b =>
                {
                    b.Navigation("ListaDeComentarios");
                });
#pragma warning restore 612, 618
        }
    }
}
