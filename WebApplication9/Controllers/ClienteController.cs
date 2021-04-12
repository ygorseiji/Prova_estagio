using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class ClienteController : Controller
    {
        private readonly Contexto _contexto;

        public ClienteController(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.dbCliente.ToListAsync());
        }

        [HttpGet]
        public IActionResult NovoCliente()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NovoCliente(Cliente cliente)
        {
            await _contexto.dbCliente.AddAsync(cliente);
            await _contexto.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> AtualizarCliente(Guid clienteID)
        {
            Cliente cliente = await _contexto.dbCliente.FindAsync(clienteID);
            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarCliente(Cliente cliente)
        {
            _contexto.dbCliente.Update(cliente);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirCliente(Guid clienteID)
        {
            Cliente cliente = await _contexto.dbCliente.FindAsync(clienteID);
            _contexto.dbCliente.Remove(cliente);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ListarCliente(Guid clienteID)
        {
            Cliente cliente = await _contexto.dbCliente.FindAsync(clienteID);
            _contexto.dbCliente.Remove(cliente);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Index(Guid vendedorID)
        {
            if (vendedorID == new Guid())
                return Index().Result;
            return View(await _contexto.dbCliente.Where(cliente => cliente.CDVEND == vendedorID).ToListAsync());
        }



    }
}
