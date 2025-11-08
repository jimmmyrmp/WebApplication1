using GestionExpedientes.Data;
using GestionExpedientes.Models;
using Microsoft.AspNetCore.Mvc;
using GestionExpedientes.Models;
using System.Linq;

namespace GestionExpedientes.Controllers
{
    public class ReportesController : Controller
    {
        private readonly GestionExpedientesContext _context;

        public ReportesController(GestionExpedientesContext context)
        {
            _context = context;
        }

        public IActionResult PromediosPorAlumno()
        {
            var promedios = _context.Alumnos
                .Where(a => a.Expedientes.Count > 0)
                .Select(a => new PromedioPorAlumno
                {
                    Nombre = a.Nombre,
                    Apellido = a.Apellido,
                    Promedio = a.Expedientes.Average(e => e.NotaFinal)
                })
                .ToList();

            return View(promedios);
        }
    }
}