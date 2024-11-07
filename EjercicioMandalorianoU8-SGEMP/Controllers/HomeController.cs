using EjercicioMandalorianoU8_SGEMP.Models;
using EjercicioMandalorianoU8_SGEMP.Models.BL;
using EjercicioMandalorianoU8_SGEMP.Models.VM;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EjercicioMandalorianoU8_SGEMP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {


            ActionResult resultado;

            

            try
            {
                
                var vistaModel = new clsVistaMisionesVM();
                resultado = View(vistaModel);

            }
            catch (Exception ex)
            {
                resultado = View("Error");
            }

            return resultado;
        }

        [HttpPost]
        public IActionResult Index(clsVistaMisionesVM vistaModel)
        {
            IActionResult resultado;

            

            try
            {
                //Comprobar la excepcion

                //throw new Exception();
                
                // Obtener la misión basada en el id seleccionado
                var misionSeleccionada = clsObtenerMisionesBL.obtenerMisionByIDBL(vistaModel.id);

                // Actualizar el ViewModel con la misión seleccionada
                vistaModel.nombre = misionSeleccionada.nombre;
                vistaModel.descripcion = misionSeleccionada.descripcion;
                vistaModel.recompensa = misionSeleccionada.recompensa;

                resultado = View(vistaModel);
            }
            catch (Exception ex)
            {
                resultado = View("Error");
            }


            return resultado;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}