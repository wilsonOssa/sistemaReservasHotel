using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionReservasHotel
{
    public class HabitacionVIP : Reserva
    {
        public decimal TarifaBase { get; set; }
        private const decimal DescuentoVIP = 0.2m;  // 20% de descuento si >5 noches

        public HabitacionVIP(string nombre, int numeroHabitacion, DateTime fecha, int duracion, decimal tarifa)
            : base(nombre, numeroHabitacion, fecha, duracion)
        {
            if (tarifa <= 0) throw new ArgumentException("La tarifa debe ser mayor a 0.");
            TarifaBase = tarifa;
        }

        public override decimal CalcularCostoTotal()
        {
            decimal costo = TarifaBase * DuracionEstadia;
            if (DuracionEstadia > 5)
            {
                costo -= costo * DescuentoVIP; // Aplica el 20% de descuento
            }
            return costo;
        }
    }
}
