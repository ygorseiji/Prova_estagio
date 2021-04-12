using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication9.Models
{
    public class Vendedor
    {
        [Key]
        public Guid CDVEND { get; set; } //Código de Vendedor (chave primária)
        public ICollection<Cliente> Clientes { get; set; }

        public string DSNOME { get; set; } //Nome do Vendedor

        public int CDTAB { get; set; } // Código da Tabela de preço padrão

        public string DTNASC { get; set; } // Data de Nascimento
    }
}

