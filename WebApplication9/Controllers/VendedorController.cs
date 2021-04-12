using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class VendedorController : Controller
    {
        private readonly Contexto _contexto;

        public VendedorController(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.dbVendedor.ToListAsync());
        }

        [HttpGet]
        public IActionResult NovoVendedor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NovoVendedor(Vendedor vendedor)
        {
            await _contexto.dbVendedor.AddAsync(vendedor);
            await _contexto.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> AtualizarVendedor(Guid vendedorID)
        {
            Vendedor vendedor = await _contexto.dbVendedor.FindAsync(vendedorID);
            return View(vendedor);
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarVendedor(Vendedor vendedor)
        {
            _contexto.dbVendedor.Update(vendedor);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirVendedor(Guid vendedorID)
        {
            Vendedor vendedor = await _contexto.dbVendedor.FindAsync(vendedorID);
            _contexto.dbVendedor.Remove(vendedor);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ListarClientes(Guid vendedorID)
        {
            return RedirectToAction("Index", "Cliente", new { vendedorID = vendedorID });
        }

    }
}
