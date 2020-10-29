using AppProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppProduto.Controllers
{
    public class ProdutosController : Controller
    {
        // GET: Produtos
        public ActionResult Index()
        {
            return View();
        }

        [Route("produtos/liberado/{year}/{month}")]
        public ActionResult Liberado(int year, int month)
        {
            return Content(year + "/" + month);
        }

        [HttpGet]
        public ActionResult Produto()
        {
            var produto = new Produto() { Id = 2, Name = "Computador" };

            return View(produto);
        }
    }
}