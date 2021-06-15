using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rewind.Models
{
    /// <summary>
    /// Descrição de cada utilizador
    /// </summary>
    public class Utilizadores
    {
        public Utilizadores()
        {   //Inicializa a lista de comentário pertencentes a este utilizador
            ListaDeComentarios = new HashSet<Comentarios>();
        }
        /// <summary>
        /// Identificação do utilizador
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// Nome do utilizador
        /// </summary>
        [Required]
        public string Utilizador { get; set; }
        /// <summary>
        /// Email do utilizador
        /// </summary>
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// Funciona como Chave Forasteira no relacionamento entre os utilizadores e a tabela de autenticação
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Lista de comentarios do utilizador
        /// </summary>
        public ICollection<Comentarios> ListaDeComentarios { get; set; }
    }
}
