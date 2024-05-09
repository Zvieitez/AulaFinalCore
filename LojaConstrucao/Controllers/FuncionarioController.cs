using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using LojaConstrucao.Models;

namespace LojaConstrucao.Controllers
{
    public class FuncionarioController : Controller
    {
        private static List<Funcionario> _funcionario = new List<Funcionario>()
        {

        new Funcionario { FuncionarioId= 1, NomeFuncionario="Zandra" },
            new Funcionario { FuncionarioId= 2, NomeFuncionario="Lucas" },
                new Funcionario { FuncionarioId= 3, NomeFuncionario="Lêda" }
        };
                 

        public IActionResult Index()
        {
            return View(_funcionario);
        }

        [HttpGet] //anotação de pegar
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //anotação de enviar | qdo não coloca a anotação, o defaul é [HttpGet]
        public IActionResult Create(Funcionario funcionario) //recebe os dados do formulário
        {
            if (ModelState.IsValid)
            {
                //ternário: se o valor de _clienteId>0 então some +1 a _clienteId, se não tem, o _clienteID é 1
                funcionario.FuncionarioId = _funcionario.Count > 0 ? _funcionario.Max(f => f.FuncionarioId) + 1 : 1;
                /*
                 if(_cliente.Count>0){
                _cliente.ClienteId = _cliente.Max() +1;
                }else{
                _cliente.ClienteID = 1
                 */
                _funcionario.Add(funcionario);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var funcionario = _funcionario.FirstOrDefault(f => f.FuncionarioId == id);

            if (funcionario == null)
            {
                return NotFound();
            }
            _funcionario.Remove(funcionario);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var funcionario = _funcionario.FirstOrDefault(f => f.FuncionarioId == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }



        [HttpPost]
        public IActionResult Edit(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                var existingFuncionario = _funcionario.FirstOrDefault(f => f.FuncionarioId == funcionario.FuncionarioId);
                if (existingFuncionario != null)
                {
                    existingFuncionario.NomeFuncionario = funcionario.NomeFuncionario;
                   
                }
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }

    }
}