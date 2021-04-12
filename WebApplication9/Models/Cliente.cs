using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Models
{
    public class Cliente
    {
        [Key]
        public Guid CDCL { get; set; } //Código do cliente
        public string DSNOME { get; set; } //Nome do cliente
        public string IDTIPO { get; set; } //Tipo de pessoa
        [ForeignKey("Vendedor")]
        public Guid CDVEND { get; set; } //Código do vendedor (FK da tabela dos vendores)
        public Vendedor vendedor { get; set; }
        public float DSLIM { get; set; } //limite de crédito
    }
}
