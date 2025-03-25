using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionReservasHotel
{
    public class GestorReservas
    {
        private static GestorReservas instancia;
        private List<Reserva> reservas = new List<Reserva>();

        private GestorReservas() { }  // Constructor privado para Singleton

        public static GestorReservas Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new GestorReservas();
                }
                return instancia;
            }
        }

        public void AgregarReserva(Reserva reserva)
        {
            foreach (var r in reservas)
            {
                if (r.NumeroHabitacion == reserva.NumeroHabitacion && r.FechaReserva == reserva.FechaReserva)
                {
                    throw new Exception("Ya existe una reserva para esta habitación en la misma fecha.");
                }
            }
            reservas.Add(reserva);
        }

        public List<Reserva> ObtenerReservas()
        {
            return reservas;
        }
    }
}
