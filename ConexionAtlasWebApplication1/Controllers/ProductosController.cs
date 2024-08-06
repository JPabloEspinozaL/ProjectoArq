using Microsoft.AspNetCore.Mvc;
using Zapateria.Models;
using Zapateria.Services;
using System.Collections.Generic;

namespace Zapateria.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ProductoService _productoService;

        public ProductosController(ProductoService productoService)
        {
            _productoService = productoService;
        }

        public IActionResult Index()
        {
            var productos = _productoService.Get();
            return View(productos);
        }

        public IActionResult Details(string id)
        {
            var producto = _productoService.Get(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _productoService.Create(producto);
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        public IActionResult Edit(string id)
        {
            var producto = _productoService.Get(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Producto productoIn)
        {
            if (id != productoIn.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _productoService.Update(id, productoIn);
                return RedirectToAction(nameof(Index));
            }
            return View(productoIn);
        }

        public IActionResult Delete(string id)
        {
            var producto = _productoService.Get(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var producto = _productoService.Get(id);
            if (producto == null)
            {
                return NotFound();
            }

            _productoService.Remove(producto.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
