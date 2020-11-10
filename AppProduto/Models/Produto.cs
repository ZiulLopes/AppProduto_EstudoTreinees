﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppProduto.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public DateTime DateAdd { get; set; }

        public TipoProduto TipoProduto { get; set; }
    }
}