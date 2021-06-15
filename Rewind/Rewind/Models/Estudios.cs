using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rewind.Models
{
    /// <summary>
    /// Descrição dos estudios
    /// </summary>
    public class Estudios
    {
        public Estudios()
        {
            //Inicializa a lista de séries pertencente a este estudio
            ListaDeSeries = new HashSet<Series>();
        }
        /// <summary>
        /// Identificação do estudio
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// Nome do estudio
        /// </summary>
        public string Estudio { get; set; }
        /// <summary>
        /// Pais do estudio.
        /// </summary>
        public string Pais { get; set; }
        /// <summary>
        /// lista das séries associados ao estudio
        /// </summary>
        public ICollection<Series> ListaDeSeries { get; set; }
    }
}
