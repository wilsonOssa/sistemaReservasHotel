using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionReservasHotel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbTipo.Items.Add("Estandar");
            cmbTipo.Items.Add("VIP");
            cmbTipo.SelectedIndex = 0; // Seleccionar "Estandar" por defecto
        }   

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 1️⃣ Obtener los valores ingresados por el usuario
                string tipo = cmbTipo.Text;
                string nombre = txtNombre.Text;
                int numHabitacion = (int)nudNumHabitacion.Value;
                DateTime fecha = dtpFecha.Value;
                int duracion = (int)nudDuracion.Value;
                decimal tarifa = 100m; // Se podría pedir al usuario

                // 2️⃣ Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("El nombre del cliente es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 3️⃣ Crear la reserva con el Factory
                Reserva reserva = ReservaFactory.CrearReserva(tipo, nombre, numHabitacion, fecha, duracion, tarifa);

                // 4️⃣ Agregar la reserva a la lista del Singleton
                GestorReservas.Instancia.AgregarReserva(reserva);

                // 5️⃣ Mostrar la reserva en la lista de la interfaz
                listBoxReservas.Items.Add($"{nombre} - Hab. {numHabitacion} - {tipo} - {duracion} noches - ${reserva.CalcularCostoTotal()}");

                // 6️⃣ Mensaje de éxito
                MessageBox.Show("Reserva registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
