using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppProduto.Models
{
    public class TipoProduto
    {
        public int IdTipoPrdto { get; set; }
        public string NomeTipoProduto { get; set; }
        public ICollection<Produto> Produto { get; set; }
    }
}