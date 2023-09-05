using Microsoft.AspNetCore.Mvc;

using PRUEBA_BRAHAN_A_ACOSTA.Datos;
using PRUEBA_BRAHAN_A_ACOSTA.Models;

namespace PRUEBA_BRAHAN_A_ACOSTA.Controllers
{
    public class PacienteController : Controller
    {
        PacienteDatos _pacienteDatos = new PacienteDatos();
        public IActionResult Listar()
        {
            
            // VISTA DONDE MUESTRA LA LISTA DE PACIENTES
            var oLista = _pacienteDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            // METODO DONDE DEVUELVE LA VISTA
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(PacienteModel opaciente)
        {
            // METODO PARA GUARDAR EL OBJETO EN BD
            if (!ModelState.IsValid)
                return View();

            var respuesta = _pacienteDatos.Guardar(opaciente);

            if (respuesta)
                return RedirectToAction("Listar");
            else
            return View();
        }

        public IActionResult Editar(int Id)
        {
            var opaciente = _pacienteDatos.obtener(Id);
            return View(opaciente);
        }

        [HttpPost]
        public IActionResult Editar(PacienteModel opaciente)
        {
            // METODO PARA EDITAR EL OBJETO EN BD
            if (!ModelState.IsValid)
                return View();

            var respuesta = _pacienteDatos.Editar(opaciente);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int Id)
        {
            var opaciente = _pacienteDatos.obtener(Id);
            return View(opaciente);
        }

        [HttpPost]
        public IActionResult Eliminar(PacienteModel opaciente)
        {
            // METODO PARA ELIMINAR EL OBJETO EN BD

            var respuesta = _pacienteDatos.Eliminar(opaciente.Id);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
