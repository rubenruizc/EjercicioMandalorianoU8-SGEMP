using EjercicioMandalorianoU8_SGEMP.Models.BL;
using EjercicioMandalorianoU8_SGEMP.Models.ENT;

namespace EjercicioMandalorianoU8_SGEMP.Models.VM
{
    public class clsVistaMisionesVM: clsMisionENT
    {
        public List<clsMisionENT> misiones { get; }

        public clsVistaMisionesVM()
        {
            misiones = clsObtenerMisionesBL.obtenerMisionesBL();
            // Verifica que 'misiones' no sea nulo

        }
    }

}
