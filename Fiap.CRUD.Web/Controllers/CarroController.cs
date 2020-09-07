using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.CRUD.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.CRUD.Web.Controllers
{
    public class CarroController : Controller
    {
        private static List<Carro> _banco = new List<Carro>(); //Simulacao do banco de dados

        public IActionResult Index()
        {
            return View(_banco);
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            //remove o carro na lista (Pesquisa a posicao do carro)
            _banco.RemoveAt(_banco.FindIndex(c => c.Codigo == id));

            //Mensagem de Sucesso
            //ViewData["msgCarro"] = "Carro excluido com sucesso!";
            TempData["msg"] = "Carro excluido com sucesso!";

            return RedirectToAction("Index"); //envia o carro para a view
        }

        [HttpPost]
        public IActionResult Editar(Carro carro)
        {
            //Substitui o carro na lista (Pesquisa a posicao do carro, depois substitui com o novo carro)
            _banco[_banco.FindIndex(c => c.Codigo == carro.Codigo)] = carro;

            //Mensagem de Sucesso
            ViewData["msgCarro"] = carro.Modelo + " Editado com sucesso!";

            return RedirectToAction("Index"); //envia o carro para a view
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            //Metodo para trazer os dados da atributo Marca no formulario
            ListaDeMarcas();

            //Pesquisa na colecao o livro com o codigo informado
            var carro = _banco.Find(li => li.Codigo == id);

            return View(carro);
        }

        [HttpPost]
        public IActionResult Pesquisar(Carro carro)
        {
            //Metodo para trazer os dados da atributo Marca no formulario
            ListaDeMarcas();

            //Pesquisa na colecao o livro com o codigo informado
            // var carro = _banco.Find(li => li.Codigo == id);

            return View(carro);
        }

        public IActionResult Search()
        {
            ViewData["Message"] = "Search page.";
            
            return View(_banco);
        }


        [HttpGet] 
        public IActionResult Cadastrar()
        {
            //Metodo para trazer os dados da atributo Marca no formulario
            ListaDeMarcas();

            return View();
        }

        private void ListaDeMarcas()
        {
            //Parametrizando os dados do array
            var listaMarca = new List<string>();
            listaMarca.Add("Fiat");
            listaMarca.Add("Honda");
            listaMarca.Add("Hyundai");
            //Enviar as editoras para o select
            ViewBag.marcas = new SelectList(listaMarca);

        }


        [HttpPost]
        public IActionResult Cadastrar(Carro carro)
        {
            //Validacao se exite algum livro cadastrado
            if (_banco.Any())
            {
                //Adicionar o codigo no livro (total de elementos na lista + 1)
                carro.Codigo = _banco[_banco.Count - 1].Codigo + 1;
                //-1 pois eh um array,e o .count traz aposicao no arry
                //Logo necessario o -1
            }
            else
            {
                carro.Codigo = 1;
            }
            _banco.Add(carro); // Adiciona no "banco"

            ViewData["msgCarro"] = carro.Modelo + " Cadastrado com sucesso!";
    
            return View("Cadastrar");
        }
    }
}