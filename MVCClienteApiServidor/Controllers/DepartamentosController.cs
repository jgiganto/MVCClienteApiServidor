using MVCClienteApiServidor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCClienteApiServidor.Controllers
{
    public class DepartamentosController : Controller
    {
        ModeloDepartamentos modelo;

        public DepartamentosController()
        {
            this.modelo = new ModeloDepartamentos();
        }

        // GET: Departamentos
        public async Task<ActionResult> Index()
        {
            List<Departamento> departamentos =
                await modelo.GetDepartamentos();
            return View(departamentos);
        }

        public async Task<ActionResult> Details(int id)
        {
            Departamento dept =
                await modelo.BuscarDepartamento(id);
            return View(dept);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Departamento dept)
        {
            await modelo.InsertarDepartamento(dept.Numero, dept.Nombre
                , dept.Localidad);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            Departamento dept =
                await modelo.BuscarDepartamento(id);
            return View(dept);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Departamento dept)
        {
            await modelo.ModificarDepartamento(dept.Numero
                , dept.Nombre, dept.Localidad);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            await modelo.EliminarDepartamento(id);
            return RedirectToAction("Index");
        }
    }

}