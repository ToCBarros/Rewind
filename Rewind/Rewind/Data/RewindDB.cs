using Microsoft.EntityFrameworkCore;
using Rewind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rewind.Data
{
    /// <summary>
    /// Esta classe representa a DB utilizada
    /// </summary>
    public class RewindDB :DbContext
    {
        //construtoes da classe RewindDB
        //indica ao qual as tabelas estao associadas
        //ver o conteudo do ficheiro "startup.cs"
        public RewindDB(DbContextOptions<RewindDB> options):base(options)
        {

        }
        //Representa as tabelas da BD
        public DbSet<Comentarios> Comentarios { get; set; }
        public DbSet<Estudios> Estudios { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Utilizadores> Utilizadores { get; set; }
    }
}
