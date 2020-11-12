using AppProduto.Models;
using AppProduto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace AppProduto.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly DataContext _dbContext;
        private readonly int itensPorPagina = 3;

        public ProdutosController()
        {
            _dbContext = new DataContext();
        }


        // GET: Produtos
        public ActionResult Index(int page = 1)
        {
            ViewData["NomeModulo"] = "Produtos";
            ViewBag.CriadoPor = "Luiz";

            ViewBag.QuantidadeProdutos = _dbContext.Produto.Count();

            IQueryable<Produto> _produtos;

            _produtos = _dbContext.Produto
                .Include(p => p.TipoProduto)
                .OrderBy(p => p.Id)
                .Skip(itensPorPagina * (page - 1))
                .Take(itensPorPagina);


            return View(_produtos.ToList());
        }

        [Route("produtos/novoproduto")]
        public ActionResult Create()
        {
            ViewBag.TiposProduto = _dbContext.TipoProduto.ToList();

            return View();
        }

        [HttpPost]
        [Route("produtos/novoproduto")]
        public ActionResult Create(Produto produto)
        {
            _dbContext.Produto.Add(produto);
            _dbContext.SaveChanges();
            return RedirectToAction("index");
        }

        [Route("produtos/editarproduto/{id}")]
        public ActionResult Edit(int id)
        {
            var produto = _dbContext.Produto.Where(x => x.Id == id).FirstOrDefault();

            var prodTo = (from x in _dbContext.Produto 
                         where x.Id == id
                         select x).FirstOrDefault();


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
            var _produto = _dbContext.Produto.Where(p => p.Id == produto.Id).FirstOrDefault();

            if (produto != null)
            {
                _produto.Name = produto.Name;
                _produto.Description = produto.Description;
                _produto.Type = produto.Type;
                _produto.DateAdd = produto.DateAdd;
                _dbContext.SaveChanges();
            }
            return RedirectToAction("index");
        }


        [Route("produtos/deletarproduto/{id}")]
        public ActionResult Delete(int id)
        {
            var produto = _dbContext.Produto.Where(_produto => _produto.Id == id).FirstOrDefault();

            if (produto != null)
            {
                _dbContext.Produto.Remove(produto);
                _dbContext.SaveChanges();
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
    }
}