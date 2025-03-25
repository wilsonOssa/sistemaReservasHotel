using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionReservasHotel
{
    public abstract class Reserva  // Clase base
    {
        public string NombreCliente { get; set; }
        public int NumeroHabitacion { get; set; }
        public DateTime FechaReserva { get; set; }
        public int DuracionEstadia { get; set; }  // Número de noches

        public Reserva(string nombre, int numeroHabitacion, DateTime fecha, int duracion)
        {
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre del cliente es obligatorio.");
            if (duracion < 1) throw new ArgumentException("La duración de la estancia debe ser mayor a 1 noche.");

            NombreCliente = nombre;
            NumeroHabitacion = numeroHabitacion;
            FechaReserva = fecha;
            DuracionEstadia = duracion;
        }

        public abstract decimal CalcularCostoTotal();  // Método a sobrescribir en clases hijas
    }
}