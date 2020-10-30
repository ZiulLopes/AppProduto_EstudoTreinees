using AppProduto.Models;
using AppProduto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppProduto.Controllers
{
    public class ProdutosController : Controller
    {
        private static List<Produto> produtos = new List<Produto>()
        {
            new Produto()
            {
                Id = 1,
                Name = "Computador",
                Description = "",
                Type = 1,
                DateAdd = DateTime.Now.AddDays(-1)
            },
            new Produto()
            {
                Id = 2,
                Name = "Teclado",
                Description = "",
                Type = 1,
                DateAdd = DateTime.Now.AddDays(-1)
            },
            new Produto()
            {
                Id = 3,
                Name = "Monitor",
                Description = "",
                Type = 1,
                DateAdd = DateTime.Now.AddDays(-1)
            }
        };

        private static List<TipoProduto> tipo_produtos = new List<TipoProduto>() { };

        // GET: Produtos
        public ActionResult Index()
        {
            ViewData["NomeModulo"] = "Produtos";
            ViewBag.CriadoPor = "Luiz";
            ViewBag.ListaDeProdutos = produtos;

            //var _produtosETipoProdutos = new ProdutoViewModel() { 
            //    produtos = produtos,
            //    tipoProdutos = tipo_produtos
            //};

            return View(produtos);
        }

        [Route("produtos/novoproduto")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("produtos/novoproduto")]
        public ActionResult Create(Produto produto)
        {
            produto.Id = IdMaisUm();
            produtos.Add(produto);
            return RedirectToAction("index");
        }

        [Route("produtos/editarproduto/{id}")]
        public ActionResult Edit(int id)
        {
            var produto = produtos.Where(_produto => _produto.Id == id).FirstOrDefault();

            if (produto != null)
            {
                return View(produto);
            }

            return RedirectToAction("index");
        }

        [HttpPost]
        [Route("produtos/editarproduto")]
        public ActionResult Edit(Produto produto)
        {
            produtos[produto.Id - 1] = produto;
            return RedirectToAction("index");
        }


        [Route("produtos/deletarproduto/{id}")]
        public ActionResult Delete(int id)
        {
            var produto = produtos.Where(_produto => _produto.Id == id).FirstOrDefault();

            if (produto != null)
            {
                produtos.Remove(produto);
            }

            return RedirectToAction("index");
        }



        [HttpGet]
        public ActionResult Produto()
        {
            var produto = new Produto() { Id = 2, Name = "Computador" };

            return View(produto);
        }

        [Route("produtos/{id}/deletar/{hashdeseguranca}")]
        public ActionResult Deletar(int id)
        {
            return View();
        }


        [Route("produtos/liberado/{year}/{month}")]
        public ActionResult Liberado(int year, int month)
        {
            return Content(year + "/" + month);
        }
    
    
        public int IdMaisUm()
        {
            return produtos.Count() + 1;
        }
    }
}