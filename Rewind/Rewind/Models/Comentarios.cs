using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rewind.Models
{
    public class Comentarios
    {
        /// <summary>
        /// Chave primaria de ligação entre utilizadores e series
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// FK do utilizador
        /// </summary>
        [ForeignKey(nameof(Utilizador))]
        public int UtilizadoresID { get; set; }
        public Utilizadores Utilizador { get; set; }
        /// <summary>
        /// FK da Serie
        /// </summary>
        [ForeignKey(nameof(Serie))]
        public int SeriesID { get; set; }
        public Series Serie { get; set; }

        /// <summary>
        /// Comentario feito à serie por um utilizador
        /// </summary>
        public string Comentario { get; set; }
        /// <summary>
        /// Avaliação feita à serie por um utilizador
        /// </summary>
        public int Estrelas { get; set; }
    }
}
