using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_GUI_BancoUTP
{
    public partial class Form6 : Form
    {
        private double Precio;
        public Form6(int pos)
        {
            InitializeComponent();
            txtMatricula.MaxLength = 10;
            comboBox1.Items.Add("Cuota Anual por Cuatrimestre - $3500");
            comboBox1.Items.Add("Pago Constancia de Estudios - $250");
            comboBox1.Items.Add("Pago de Biblioteca - $150");
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = comboBox1.SelectedIndex;
            switch (num)
            {
                case 0:
                    Precio = 3500.00;
                    break;
                case 1:
                    Precio = 250.00;
                    break;
                case 2:
                    Precio = 150.00;
                    break;
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            string Matricula = txtMatricula.Text.Trim();

            if (string.IsNullOrEmpty(Matricula))
            {
                MessageBox.Show("Debe llenar todos los campos.");
                return;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecciona un tipo de pago.");
                return;
            }

            // Obtener el saldo del usuario actual
            double saldoActual = Usuarios.UsuarioActual.ConsultarSaldo();

            if (saldoActual >= Precio)
            {
                // Registrar la transacción
                Usuarios.UsuarioActual.RetirarSaldo(Precio);
                Usuarios.UsuarioActual.RegistrarTransaccion(-Precio, "Pago de servicio: " + comboBox1.Text);

                // Mensaje de pago exitoso
                MessageBox.Show($"Pago exitoso!\n" +
                                $"Ha seleccionado: {comboBox1.Text}\n" +
                                $"Ha pagado el total de: ${Precio}\n" +
                                $"Para la matrícula: {Matricula}");

                // Limpiar campos después del pago
                txtMatricula.Clear();
                comboBox1.SelectedIndex = -1; // Reiniciar el ComboBox
            }
            else
            {
                MessageBox.Show("No tienes saldo suficiente para pagar.");
            }
        }

    }
}
