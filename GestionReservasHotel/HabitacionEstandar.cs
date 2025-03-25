using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionReservasHotel
{
    public class HabitacionEstandar : Reserva
    {
        public decimal TarifaFija { get; set; }

        public HabitacionEstandar(string nombre, int numeroHabitacion, DateTime fecha, int duracion, decimal tarifa)
            : base(nombre, numeroHabitacion, fecha, duracion)
        {
            if (tarifa <= 0) throw new ArgumentException("La tarifa debe ser mayor a 0.");
            TarifaFija = tarifa;
        }

        public override decimal CalcularCostoTotal()
        {
            return TarifaFija * DuracionEstadia;
        }
    }
}
