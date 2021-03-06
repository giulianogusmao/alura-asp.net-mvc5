﻿using CaelumEstoque.DAO;
using CaelumEstoque.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class ProdutoController : Controller
    {
        [Route("produtos", Name = "ListaProdutos")]
        public ActionResult Index()
        {
            ProdutosDAO dao = new ProdutosDAO();
            IList<Produto> produtos = dao.Lista();
            return View(produtos);
        }

        public ActionResult Form()
        {
            ViewBag.Categorias = this.ListaCategorias();
            ViewBag.Produto = new Produto();
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Produto produto)
        {
            var informaticaId = 1;
            if (produto.CategoriaId.Equals(informaticaId) && produto.Preco < 100)
            {
                ModelState.AddModelError("produto.InformaticaComPrecoInvalido", "Produtos da categoria informática devem ter preço maior do que 100");
            }

            if (ModelState.IsValid)
            {
                ProdutosDAO dao = new ProdutosDAO();
                dao.Adiciona(produto);
                return RedirectToAction("Index", "Produto");
            } else {
                ViewBag.Categorias = this.ListaCategorias();
                ViewBag.Produto = produto;
                return View("Form");
            }
        }

        [Route("produtos/{id}", Name = "DetalheProduto")]
        public ActionResult Detalhe(int id)
        {
            var dao = new ProdutosDAO();
            ViewBag.Produto = dao.BuscaPorId(id);
            return View();
        }

        private IList<CategoriaDoProduto> ListaCategorias()
        {
            CategoriasDAO categoriasDao = new DAO.CategoriasDAO();
            return categoriasDao.Lista();
        }
    }
}