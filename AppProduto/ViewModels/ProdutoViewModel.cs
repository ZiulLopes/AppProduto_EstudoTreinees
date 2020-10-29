using AppProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppProduto.ViewModels
{
    public class ProdutoViewModel
    {
        public List<Produto> produtos { get; set; }
        public List<TipoProduto> tipoProdutos { get; set; }
    }
}