using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using LojaConstrucao.Models;

namespace LojaConstrucao.Controllers;

public class ClienteController : Controller
{

    //  PV = prefixed variable - "_clientes" é uma variável estática que simula um banco de dados temporário na memória para este exemplo.
    //  Ele é uma lista de clientes que é inicializada com alguns dados de exemplo no código do controlador.
    private static List<Cliente> _cliente = new List<Cliente>()
    {

        new Cliente { ClienteId= 1, NomeCliente="Juan" },
            new Cliente { ClienteId= 2, NomeCliente="Marcia" },
                new Cliente { ClienteId= 3, NomeCliente="Israel" },
                    new Cliente { ClienteId= 4, NomeCliente="Pedro" }
   };

    public IActionResult Index()
    {
        return View(_cliente);
    }

    [HttpGet] //anotação de pegar
    public IActionResult Create()
    {

        return View();
    }

    [HttpPost] //anotação de enviar | qdo não coloca a anotação, o defaul é [HttpGet]
    public IActionResult Create(Cliente cliente) //recebe os dados do formulário
    {
        if (ModelState.IsValid)
        {
            //ternário: se o valor de _clienteId>0 então some +1 a _clienteId, se não tem, o _clienteID é 1
            cliente.ClienteId = _cliente.Count > 0 ? _cliente.Max(c => c.ClienteId) + 1 : 1;
            /*
             if(_cliente.Count>0){
            _cliente.ClienteId = _cliente.Max() +1;
            }else{
            _cliente.ClienteID = 1
             */
            _cliente.Add(cliente);
        }

        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var cliente = _cliente.FirstOrDefault(c => c.ClienteId == id);

        if (cliente == null)
        {
            return NotFound();
        }
        _cliente.Remove(cliente);

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var cliente = _cliente.FirstOrDefault(c => c.ClienteId == id);
        if (cliente == null)
        {
            return NotFound();
        }

        return View(cliente);
    }



    [HttpPost]
    public IActionResult Edit(Cliente cliente)
    {
        if (ModelState.IsValid)
        {
            var existingCliente = _cliente.FirstOrDefault(c => c.ClienteId == cliente.ClienteId);
            if (existingCliente != null)
            {
                existingCliente.NomeCliente = cliente.NomeCliente;
                existingCliente.Email = cliente.Email;
            }
            return RedirectToAction("Index");
        }
        return View(cliente);
    }

    public IActionResult Detalhes(int id)
    {
        var cliente = _cliente.FirstOrDefault(c => c.ClienteId == id);
        if (cliente == null)
        
            return NotFound();

            return View(cliente);

        }
    }
