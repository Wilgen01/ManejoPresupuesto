using Dapper;
using ManejoPresupuesto.Models;
using ManejoPresupuesto.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace ManejoPresupuesto.Controllers
{
    public class TiposCuentasController : Controller
    {
        private readonly IRepositorioTiposCuentas repositorioTiposCuentas;

        public TiposCuentasController(IRepositorioTiposCuentas repositorioTiposCuentas)
        {
            this.repositorioTiposCuentas = repositorioTiposCuentas;
        }

        public async Task<IActionResult> Index()
        {
            var usuarioId = 1;
            var tiposCuentas = await repositorioTiposCuentas.Obtener(usuarioId);
            return View(tiposCuentas);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(TipoCuenta tipoCuenta)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoCuenta);
            }

            tipoCuenta.UsuarioId = 1;
            var existeTipoCuenta = await repositorioTiposCuentas.Existe(tipoCuenta.Nombre, tipoCuenta.UsuarioId);

            if (existeTipoCuenta)
            {
                ModelState.AddModelError(nameof(tipoCuenta.Nombre), $"El nombre '{tipoCuenta.Nombre}' ya existe.");
                return View(tipoCuenta);
            }

            await repositorioTiposCuentas.Crear(tipoCuenta);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> VerificarTipoCuentaExiste(string nombre)
        {
            var usuarioId = 1;
            var existeTipoCuenta = await repositorioTiposCuentas.Existe(nombre, usuarioId);

            if (existeTipoCuenta)
            {
                return Json($"el nombre '{nombre}' ya existe.");
            }

            return Json(true);

        }
    }
}
