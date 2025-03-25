using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionReservasHotel
{
    public static class ReservaFactory
    {
        public static Reserva CrearReserva(string tipo, string nombre, int numeroHabitacion, DateTime fecha, int duracion, decimal tarifa)
        {
            if (tipo == "Estandar")
            {
                return new HabitacionEstandar(nombre, numeroHabitacion, fecha, duracion, tarifa);
            }
            else if (tipo == "VIP")
            {
                return new HabitacionVIP(nombre, numeroHabitacion, fecha, duracion, tarifa);
            }
            else
            {
                throw new ArgumentException("Tipo de habitación no válido.");
            }
        }
    }
}
