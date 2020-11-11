using AppProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppProduto.Controllers.api
{
    public class ProdutosApiController : ApiController
    {
        private readonly DataContext _dbContext;
        public ProdutosApiController()
        {
            _dbContext = new DataContext();
        }

        [HttpGet]
        [Route("produtosapi")]
        public IHttpActionResult Get()
        {
            var produtos = _dbContext.Produto.ToList();
            return Ok(produtos);
        }

        [HttpGet]
        [Route("produtosapi/{id}")]
        public IHttpActionResult Get(int id)
        {
            var produto = _dbContext.Produto.Where(p => p.Id == id).FirstOrDefault();

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }


        [HttpPost]
        [Route("produtosapi")]
        public IHttpActionResult Post([FromBody]Produto produto)
        {
            try
            {
                _dbContext.Produto.Add(produto);
                _dbContext.SaveChanges();
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest("Houve algum erro ao adicionar o produto\n" + ex.Message);
            }
        }


        [HttpPut]
        [Route("produtosapi")]
        public IHttpActionResult Put([FromBody] Produto produto)
        {
            try
            {
                var _produto = _dbContext.Produto.Where(p => p.Id == produto.Id).FirstOrDefault();

                if (produto == null)
                {
                    return NotFound();
                }
                _produto.Name = produto.Name;
                _produto.Description = produto.Description;
                _produto.Type = produto.Type;
                _produto.DateAdd = produto.DateAdd;
                _dbContext.SaveChanges();
                return Ok("Id: " + _produto.Id + " Editado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Houve algum erro ao editar o produto\n" + ex.Message);
            }
        }


        [HttpDelete]
        [Route("produtosapi/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var produto = _dbContext.Produto.Where(p => p.Id == id).FirstOrDefault();

                if (produto == null)
                {
                    return NotFound();
                }
                _dbContext.Produto.Remove(produto);
                _dbContext.SaveChanges();
                return Ok("Produto Id: " + id + " deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possível excluir o produto id: " + id);
            }
        }
    }
}
