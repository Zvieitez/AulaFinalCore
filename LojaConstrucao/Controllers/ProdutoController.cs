using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using LojaConstrucao.Models;

namespace LojaConstrucao.Controllers;

public class ProdutoController : Controller
{

    private static List<Produto> _produto = new List<Produto>()
{

    new Produto { ProdutoId= 1, NomeProduto="Faca", Valor = 10, Estoque = "1500"},
        new Produto { ProdutoId= 2, NomeProduto="Garfo", Valor = 9, Estoque = "1500" },
             new Produto { ProdutoId= 3, NomeProduto="Colher", Valor = 7, Estoque = "1500" },
                new Produto { ProdutoId= 4, NomeProduto="Prato", Valor = 15, Estoque = "3000" }
};


    public IActionResult Index()
    {
        return View(_produto);
    }

    [HttpGet] //anotação de pegar
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost] //anotação de enviar | qdo não coloca a anotação, o defaul é [HttpGet]
    public IActionResult Create(Produto produto) //recebe os dados do formulário
    {
        if (ModelState.IsValid)
        {
            //ternário: se o valor de _clienteId>0 então some +1 a _clienteId, se não tem, o _clienteID é 1
            produto.ProdutoId = _produto.Count > 0 ? _produto.Max(c => c.ProdutoId) + 1 : 1;
            /*
             if(_cliente.Count>0){
            _cliente.ClienteId = _cliente.Max() +1;
            }else{
            _cliente.ClienteID = 1
             */
            _produto.Add(produto);
        }

        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var produto = _produto.FirstOrDefault(c => c.ProdutoId == id);

        if (produto == null)
        {
            return NotFound();
        }
        _produto.Remove(produto);

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var produto = _produto.FirstOrDefault(c => c.ProdutoId == id);
        if (produto == null)
        {
            return NotFound();
        }

        return View(produto);
    }



    [HttpPost]
    public IActionResult Edit(Produto produto)
    {
        if (ModelState.IsValid)
        {
            var existingProduto = _produto.FirstOrDefault(c => c.ProdutoId == produto.ProdutoId);
            if (existingProduto != null)
            {
                existingProduto.NomeProduto = produto.NomeProduto;
                existingProduto.Valor = produto.Valor;
                existingProduto.Estoque = produto.Estoque;
            }
            return RedirectToAction("Index");
        }
        return View(produto);
    }

}